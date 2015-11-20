﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcepayRestClient.Classes.Refund
{
    public class CancelRefundRequest : Base
    {
        public int RefundID { get; set; }
        public int PaymentID { get; set; }
    }

    public class CancelRefundResponse : Base { }
}
