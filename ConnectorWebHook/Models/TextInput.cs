using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectorWebHook.Models
{
    public class TextInput : Input
    {
        public TextInput()
        {
            this.type = "TextInput";
        }
        public bool isMultiline { get; set; }
    }
}
