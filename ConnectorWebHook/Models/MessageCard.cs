using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectorWebHook.Models
{
    public class MessageCard : IWebHookPayload
    {
        public string @type { get; set; }
        public string @context { get; set; }
        public string themeColor { get; set; }
        public string summary { get; set; }
        public List<Section> sections { get; set; } = new List<Section>();
        public List<PotentialAction> potentialAction { get; set; } = new List<PotentialAction>();

    }
}
