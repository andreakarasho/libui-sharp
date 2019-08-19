using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibUI.Interop
{
    internal partial class NativeMethods
    {
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiImageAppend")]
        public static extern void ImageAppend(IntPtr image, byte[] pixels, int pixelWidth, int pixelHeight, int byteStride);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiFreeImage")]
        public static extern void FreeImage(IntPtr image);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiNewImage")]
        public static extern IntPtr NewImage(double width, double height);
    }
}
