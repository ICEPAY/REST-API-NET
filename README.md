# REST-API-NET
REST API client for .NET developers

After registering for an account with ICEPAY, you receive an e-mail with your 5-digit merchant ID and 40-digit secret code.
To use the REST API client, first create a Payment object with your merchant ID and secret:

IcepayRestClient.Payment restPayment = new IcepayRestClient.Payment(12345, "AbCdEfGhIjKlMnOpQrStUvWxYz1234567890AbCd");

To retrieve a list of payment methods available to your merchant account, call the GetMyPaymentMethods method:

IcepayRestClient.Classes.Payment.GetMyPaymentMethodsResponse getMyPaymentMethodsResponse = restPayment.GetMyPaymentMethods();

It returns a response with an array of PaymentMethod objects. Each of these contain the payment method code and available issuer codes you'll need to perform a checkout.

Initiate a payment by calling the Checkout method:

IcepayRestClient.Classes.Payment.CheckoutResponse checkoutResponse = restPayment.Checkout(
  new IcepayRestClient.Classes.Payment.CheckoutRequest
            {
                Amount = 200, //amount in cents
                Country = "NL", //2 character ISO country code
                Currency = "EUR", //3 characther ISO currency code
                Description = "ICEPAY payment via REST API",
                EndUserIP = "127.0.0.1", //read the end user's IP address
                OrderID = "ORD0000001", //
                PaymentMethod = "IDEAL", //Payment method code
                Issuer = "ING", //Issuer code
                Language = "NL" //2 character ISO language code
            }
);
