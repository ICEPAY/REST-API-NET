﻿
namespace IcepayRestClient.Classes.Payment
{
    public class VaultCheckoutRequest:CheckoutRequest
    {
        public string ConsumerID { get; set; }
    }

    public class VaultCheckoutResponse : CheckoutResponse { }
}
