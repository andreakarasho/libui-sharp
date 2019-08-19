using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibUI.Interface;
using LibUI.Interop;
using LibUI.Utils;

namespace LibUI.Drawing
{
    public class FontFamilies
    {
        public IntPtr handle;

        public FontFamilies()
        {
            handle = NativeMethods.DrawListFontFamilies();
        }

        public int Count
        {
            get { return NativeMethods.DrawFontFamiliesNumFamilies(handle); }
        }

        public string this[int index]
        {
            get { return StringUtil.GetString(NativeMethods.DrawFontFamiliesFamily(handle, index)); }
        }

        public void Free()
        {
            NativeMethods.DrawFreeFontFamilies(handle);
        }
    }
}
