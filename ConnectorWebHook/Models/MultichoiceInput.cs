using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectorWebHook.Models
{
    public class MultichoiceInput : Input
    {
        public MultichoiceInput()
        {
            this.type = "MultichoiceInput";
        }
        public string isMultiSelect { get; set; }
        public List<MultichoiceInputChoice> choices { get; set; } = new List<MultichoiceInputChoice>();
    }
}
