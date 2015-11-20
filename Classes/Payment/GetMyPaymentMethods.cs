﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcepayRestClient.Classes.Payment
{
    public class GetMyPaymentMethodsRequest : Base { }

    public class GetMyPaymentMethodsResponse : Base
    {
        public PaymentMethod[] PaymentMethods { get; set; }
    }

    public class PaymentMethod
    {
        public string PaymentMethodCode { get; set; }
        public string Description { get; set; }
        public Issuer[] Issuers { get; set; }
    }

    public class Issuer
    {
        public string IssuerKeyword { get; set; }
        public string Description { get; set; }
        public Country[] Countries { get; set; }
    }

    public class Country
    {
        public string CountryCode { get; set; }
        public string Currency { get; set; }
        public int MinimumAmount { get; set; }
        public int MaximumAmount { get; set; }
    }
}
