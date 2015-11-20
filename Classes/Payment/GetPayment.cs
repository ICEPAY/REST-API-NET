﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcepayRestClient.Classes.Payment
{
    public class GetPaymentRequest :Base
    {
        public int PaymentID { get; set; }
    }

    public class GetPaymentResponse : Base
    {
        public int PaymentID { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string ConsumerName { get; set; }
        public string ConsumerAccountNumber { get; set; }
        public string ConsumerAddress { get; set; }
        public string ConsumerHouseNumber { get; set; }
        public string ConsumerCity { get; set; }
        public string ConsumerCountry { get; set; }
        public string ConsumerEmail { get; set; }
        public string ConsumerPhoneNumber { get; set; }
        public string ConsumerIPAddress { get; set; }
        public string Issuer { get; set; }
        public string OrderID { get; set; }
        public string OrderTime { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentTime { get; set; }
        public string Reference { get; set; }
        public string Status { get; set; }
        public string StatusCode { get; set; }
        public string TestMode { get; set; }
    }
}
