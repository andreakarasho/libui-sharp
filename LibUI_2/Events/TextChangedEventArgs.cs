using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibUI.Events
{
    public class TextChangedEventArgs : EventArgs
    {
        public string Text { get; internal set; }
    }
}
