﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcepayRestClient.Classes.Refund
{
    public class RequestRefundRequest : Base
    {
        public int PaymentID { get; set; }
        public int RefundAmount { get; set; }
        public string RefundCurrency { get; set; }
    }

    public class RequestRefundResponse : Base
    {
        public int RefundID { get; set; }
        public int PaymentID { get; set; }
        public int RefundAmount { get; set; }
        public int RemainingRefundAmount { get; set; }
        public string RefundCurrency { get; set; }
    }
}
