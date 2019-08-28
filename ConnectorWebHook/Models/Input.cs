using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectorWebHook.Models
{
    public class Input
    {
        public string @type { get; internal set; }
        public string id { get; set; }
        public string title { get; set; }
    }
}
