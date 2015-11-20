﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcepayRestClient.Classes
{
    public abstract class Base
    {
        public string Timestamp
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss");
            }
        }

        /// <summary>
        /// In case of errors, this field will contain the error description.
        /// </summary>
        public string Message { get; set; }
    }
}
