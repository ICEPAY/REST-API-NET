﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcepayRestClient.Classes.Refund
{
    public class GetPaymentRefundsRequest : Base
    {
        public int PaymentID { get; set; }
    }

    public class GetPaymentRefundsResponse : Base
    {
        public Refund[] Refunds { get; set; }
    }

    public class Refund
    {
        public int RefundID { get; set; }
        public int RefundAmount { get; set; }
        public string RefundCurrency { get; set; }
        public string DateCreated { get; set; }
        public string Status { get; set; }
    }
}
