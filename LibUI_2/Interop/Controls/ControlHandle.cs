﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

/*namespace LibUI.Interop
{
    public class ControlHandle : SafeHandle
    {
        public ControlHandle() : base(IntPtr.Zero, true)
        {
        }

        public ControlHandle(IntPtr intPtr) : base(intPtr, true)
        {
            
        }

        protected override bool ReleaseHandle()
        {
            // TODO it always return true on *nix.
            NativeMethods.ControlDestroy(this);
            this.handle = IntPtr.Zero;
            return Marshal.GetLastWin32Error() == 0;
        }

        public override bool IsInvalid => handle == IntPtr.Zero;
    }
}
*/