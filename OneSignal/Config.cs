using System;
using System.Collections.Generic;
using System.Text;

namespace OneSignal
{
    public class Config
    {
        public OneSignal Signal { get; set; }
    }

    public class OneSignal
    {
        public string AppId { get; set; }
        public string RESTKey { get; set; }
    }
}
