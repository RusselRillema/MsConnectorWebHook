using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectorWebHook.Models
{
    public class Section
    {
        public string activityTitle { get; set; }
        public string activitySubtitle { get; set; }
        public string activityImage { get; set; }
        public List<Fact> facts { get; set; } = new List<Fact>();
        public bool markdown { get; set; }
    }
}
