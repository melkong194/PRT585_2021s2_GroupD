﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business
{
    public abstract class StandardResultObject
    {
        public StandardResultObject()
        {
            success = false;
            userMessage = string.Empty;
            internalMessage = string.Empty;
            exception = null;
        }
        public bool success { get; set; }
        public string userMessage { get; set; }
        internal string internalMessage { get; set; } 
        internal Exception exception { get; set; } 
    }
}
