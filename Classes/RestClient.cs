﻿using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace IcepayRestClient.Classes
{
    public class RestClient
    {
        protected const string BaseUrl = "https://connect.icepay.com/webservice/api/v1/";

        public static TResponse SendAndReceive<TRequest, TResponse>(string service, string operation, TRequest request, int merchantID, string merchantSecret)
            where TRequest : Base, new()
            where TResponse : Base, new()
        {
            //make full URL
            var url = BaseUrl + service + "/" + operation;

            //serialize JSON without any whitespace
            var jsonSerializerSettings = new JsonSerializerSettings { Formatting = Newtonsoft.Json.Formatting.None, NullValueHandling = NullValueHandling.Ignore, Culture = System.Globalization.CultureInfo.InvariantCulture };
            var rawJson = JsonConvert.SerializeObject(request, Formatting.None, jsonSerializerSettings);

            //calculate checksum
            var signString = url + "POST" + merchantID.ToString() + merchantSecret + rawJson;
            var checksum = Sha256(signString);

            //initiate request
            var webrequest = HttpWebRequest.CreateHttp(url);
            webrequest.Method = "POST";
            webrequest.ContentType = "application/json";
            //add merchant ID and checksum to headers
            webrequest.Headers.Add("MerchantID", merchantID.ToString());
            webrequest.Headers.Add("Checksum", checksum);

            //send request
            var requestStream = webrequest.GetRequestStream();
            var writer = new StreamWriter(requestStream);
            writer.Write(rawJson);
            writer.Flush();

            //receive response
            TResponse response = null;
            string rawResponse = string.Empty;
            WebResponse webresponse = null;
            try
            {
                webresponse = webrequest.GetResponse();
            }
            catch (WebException ex)
            {
                webresponse = ex.Response;
            }
            var responseStream = webresponse.GetResponseStream();
            var reader = new StreamReader(responseStream);
            rawResponse = reader.ReadToEnd();

            response = JsonConvert.DeserializeObject<TResponse>(rawResponse);

            //verify response checksum
            //always require presence of a checksum header
            if (!string.IsNullOrWhiteSpace(webresponse.Headers["Checksum"]))
            {
                var responseChecksum = webresponse.Headers["Checksum"];
                var responseSignString = webresponse.ResponseUri.AbsoluteUri + "POST" + merchantID.ToString() + merchantSecret + rawResponse;
                var responseVerificationChecksum = Sha256(responseSignString);
                if (!responseChecksum.Equals(responseVerificationChecksum, System.StringComparison.InvariantCultureIgnoreCase))
                {
                    if (string.IsNullOrWhiteSpace(response.Message))
                    {
                        response = new TResponse { Message = "Authentication error: the checksum was incorrect. Verify your secret code." };
                    }
                    response = new TResponse { Message = response.Message };
                }
            }
            else
            {
                //if no checksum header was present in the response, the most likely cause is that the sender ID was invalid
                //return only the response message and regard the response as failed
                if (string.IsNullOrWhiteSpace(response.Message))
                {
                    response = new TResponse { Message = "Authentication error: no checksum found. Verify your merchant ID." };
                }
                response = new TResponse { Message = response.Message };
            }

            //close streams
            writer.Dispose();
            reader.Dispose();
            webresponse.Dispose();

            return response;
        }

        protected static string Sha256(string signString)
        {
            byte[] hash;
            var sha2 = new SHA256Managed();
            hash = sha2.ComputeHash(System.Text.Encoding.UTF8.GetBytes(signString));

            StringBuilder sb = new StringBuilder(40);
            foreach (byte b in hash)
            {
                sb.AppendFormat("{0:x2}", b);
            }
            return sb.ToString();
        }
    }
}
