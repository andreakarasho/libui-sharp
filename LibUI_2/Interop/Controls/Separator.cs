using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace LibUI.Interop
{
    internal partial class NativeMethods
    {
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiNewHorizontalSeparator")]
        public static extern IntPtr NewHorizontalSeparator();

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiNewVerticalSeparator")]
        public static extern IntPtr NewVerticalSeparator();
    }
}
