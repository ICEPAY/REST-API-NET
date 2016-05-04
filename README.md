# REST-API-NET
REST API client for .NET developers

##Payment

After registering for an account with ICEPAY, you receive an e-mail with your 5-digit merchant ID and 40-digit secret code.
To use the REST API client, first create a Payment object with your merchant ID and secret:

`IcepayRestClient.Payment restPayment = new IcepayRestClient.Payment(12345, "AbCdEfGhIjKlMnOpQrStUvWxYz1234567890AbCd");`

To retrieve a list of payment methods available to your merchant account, call the GetMyPaymentMethods method:

`IcepayRestClient.Classes.Payment.GetMyPaymentMethodsResponse getMyPaymentMethodsResponse = restPayment.GetMyPaymentMethods();`

It returns a response with an array of PaymentMethod objects. Each of these contain the payment method code and available issuer codes you'll need to perform a checkout.

Initiate a payment by calling the Checkout method:

```IcepayRestClient.Classes.Payment.CheckoutResponse checkoutResponse = restPayment.Checkout(
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
);```

The checkout response contains a field PaymentScreenURL. This contains a URL to a payment confirmation screen, to which the end user must be redirected to complete the payment.
If the PaymentScreenURL is empty, an error has occurred.

##Retrieving payment status

After a payment is completed or expired, your webshop will receive a postback message with a status update. You can also manually retrieve the status of any payment you've done. To retrieve the status of a payment, call the GetPayment method:

````IcepayRestClient.Classes.Payment.GetPaymentResponse getPaymentResponse = restPayment.GetPayment(
  new IcepayRestClient.Classes.Payment.GetPaymentRequest
  {
    PaymentID = checkoutResponse.PaymentID //the PaymentID is returned in the CheckoutResponse
  }
);````

This response contains a field Status that identifies the current status of the payment:
OK    The payment was completed successfully
OPEN  The payment was started and is awaiting completion
ERR   The payment failed due to a decline or due to an error

##Refunding a payment

To refund a completed payment, you can use the Refund object:

````IcepayRestClient.Refund restRefund = new IcepayRestClient.Refund(12345, "AbCdEfGhIjKlMnOpQrStUvWxYz1234567890AbCd");
IcepayRestClient.Classes.Refund.RequestRefundResponse refundResponse = restRefund.Checkout(
  new IcepayRestClient.Classes.Refund.RequestRefundRequest
  {
    PaymentID = 123456789, //the PaymentID is returned in the CheckoutResponse
    RefundAmount = 100, //1 Euro in cents
    RefundCurrency = "EUR"
  }
);````

The response will contain the PaymentID if the refund was successful, otherwise the Message field will contain an error explanation.
The response also contains the RemainingRefundAmount. This is the part of the original paymnt amount that was not yet refunded and for which you can still issue refund requests. If the payment was fully refunded, the RemainingRefundAmount is 0.
