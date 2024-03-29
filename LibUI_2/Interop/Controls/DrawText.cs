﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using LibUI.Drawing;

namespace LibUI.Interop
{
    internal partial class NativeMethods
    {
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiDrawText")]
        public static extern void DrawText(IntPtr context, double x, double y, IntPtr layout);
    }
}
