﻿using IcepayRestClient.Classes.Refund;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcepayRestClient
{
    public class Refund : ServiceBase
    {
        public Refund(int merchantID, string merchantSecret) : base(merchantID, merchantSecret) { }

        public RequestRefundResponse Checkout(RequestRefundRequest request)
        {
            return IcepayRestClient.Classes.RestClient.SendAndReceive<RequestRefundRequest, RequestRefundResponse>("Refund", "RequestRefund", request, this.MerchantID, this.MerchantSecret);
        }

        public CancelRefundResponse Checkout(CancelRefundRequest request)
        {
            return IcepayRestClient.Classes.RestClient.SendAndReceive<CancelRefundRequest, CancelRefundResponse>("Refund", "CancelRefund", request, this.MerchantID, this.MerchantSecret);
        }

        public GetPaymentRefundsResponse Checkout(GetPaymentRefundsRequest request)
        {
            return IcepayRestClient.Classes.RestClient.SendAndReceive<GetPaymentRefundsRequest, GetPaymentRefundsResponse>("Refund", "GetPaymentRefunds", request, this.MerchantID, this.MerchantSecret);
        }
    }
}
