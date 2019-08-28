using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectorWebHook.Models
{
    public class PotentialAction
    {
        public string @type { get; set; }
        public string name { get; set; }
        public List<Input> inputs { get; set; } = new List<Input>();
        public List<Action> actions { get; set; } = new List<Action>();
    }
}
