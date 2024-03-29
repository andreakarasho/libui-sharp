﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibUI.Events
{
    public class DataEventArgs : EventArgs
    {
        public IntPtr Data { get; }

        public DataEventArgs(IntPtr data)
        {
            Data = data;
        }
    }
}
