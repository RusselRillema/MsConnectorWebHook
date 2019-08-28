using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectorWebHook.Models
{
    public class Action
    {
        public string @type { get; set; }
        public string name { get; set; }
        public string target { get; set; }
    }
}
