﻿
namespace IcepayRestClient.Classes.Refund
{
    public class CancelRefundRequest : Base
    {
        public int RefundID { get; set; }
        public int PaymentID { get; set; }
    }

    public class CancelRefundResponse : Base { }
}
