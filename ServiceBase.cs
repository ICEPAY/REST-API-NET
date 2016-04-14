﻿namespace IcepayRestClient
{
    public abstract class ServiceBase
    {
        public int MerchantID { get; set; }
        public string MerchantSecret { get; set; }

        public ServiceBase(int merchantID, string merchantSecret)
        {
            this.MerchantID = merchantID;
            this.MerchantSecret = merchantSecret;
        }
    }
}
