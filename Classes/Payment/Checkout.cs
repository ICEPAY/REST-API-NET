﻿
namespace IcepayRestClient.Classes.Payment
{
    public class CheckoutRequest : Base
    {
        public int Amount { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string EndUserIP { get; set; }
        public string Issuer { get; set; }
        public string Language { get; set; }
        public string OrderID { get; set; }
        public string PaymentMethod { get; set; }
        public string Reference { get; set; }
        public string URLCompleted { get; set; }
        public string URLError { get; set; }
    }

    public class CheckoutResponse : Base
    {
        public int Amount { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string EndUserIP { get; set; }
        public string Issuer { get; set; }
        public string Language { get; set; }
        public string OrderID { get; set; }
        public int PaymentID { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentScreenURL { get; set; }
        public string ProviderTransactionID { get; set; }
        public string Reference { get; set; }
        public string TestMode { get; set; }
        public string URLCompleted { get; set; }
        public string URLError { get; set; }
    }
}
