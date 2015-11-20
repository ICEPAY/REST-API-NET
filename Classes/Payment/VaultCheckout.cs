﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcepayRestClient.Classes.Payment
{
    public class VaultCheckoutRequest:CheckoutRequest
    {
        public string ConsumerID { get; set; }
    }

    public class VaultCheckoutResponse : CheckoutResponse { }
}
