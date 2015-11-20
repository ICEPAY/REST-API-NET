﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcepayRestClient
{
    public abstract class ServiceBase
    {
        public int MerchantID { get; set; }
        public string MerchantSecret { get; set; }

        public ServiceBase(int merchantID, string merchantSecret)
        {
            this.MerchantID = merchantID;
            this.MerchantSecret=merchantSecret;
        }
    }
}
