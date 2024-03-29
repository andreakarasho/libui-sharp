﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibUI.Events;
using LibUI.Interface;
using LibUI.Interop;

namespace LibUI
{
    /// <summary>
    /// TODO: store some info.
    /// TODO: add some event.
    /// </summary>
    public abstract class Control : IDisposable
    {
        private IntPtr _handle;
        /// <summary>
        /// It stored a pointer to a control instance.
        /// </summary>
        protected internal IntPtr handle
        {
            get
            {
                return _handle;
            }
            protected set
            {
                _handle = value;
                ControlCaches[value] = this;
            }
        }

        public event EventHandler LocationChanged;

        public event EventHandler Resize;

        internal static Dictionary<IntPtr, Control> ControlCaches = new Dictionary<IntPtr, Control>();

        public Control Parent { get; internal set; }

        public int Index { get; protected internal set; }

        protected Control()
        {
            if (this is Window)
            {
                _visible = false;
            }
            else
            {
                _visible = true;
            }
        }

        protected virtual void InitializeEvents()
        {
            
        }

        protected virtual void InitializeData()
        {
            
        }

        protected internal bool Verify()
        {
            return this.handle != IntPtr.Zero;
        }

        /// <summary>
        /// The handle that this control is bound to.
        /// </summary>
        public UIntPtr Handle => NativeMethods.ControlHandle(this.handle);

        public virtual bool Enabled
        {
            get
            {
                return NativeMethods.ControlEnabled(this.handle);
            }
            set
            {
                if (value)
                {
                    NativeMethods.ControlEnable(this.handle);
                }
                else
                {
                    NativeMethods.ControlDisable(this.handle);
                }
            }
        }

        private bool _visible;
        public bool Visible
        {
            get
            {
                return NativeMethods.ControlVisible(this.handle);
            }
            set
            {
                if(_visible == value) return;
                if (value)
                {
                    NativeMethods.ControlShow(this.handle);
                }
                else
                {
                    NativeMethods.ControlHide(this.handle);
                }
                _visible = value;
            }
        }

        public bool TopLevel
        {
            get
            {
                if (Verify())
                {
                    return NativeMethods.ControlToplevel(this.handle);
                }
                return false;
            }
            /* TODO
            set
            {
                
            }
            */
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (handle != IntPtr.Zero)
            {
                Destroy();
            }
        }

        protected virtual void Destroy()
        {
            // TODO maybe store some info
            ControlCaches.Remove(handle);
            NativeMethods.ControlDestroy(handle);
        }

        public virtual void Show()
        {
            this.Visible = true;
        }

        public virtual void Hide()
        {
            this.Visible = false;
        }

        protected virtual void OnResize(EventArgs e)
        {
            Resize?.Invoke(this, e);
        }

        protected virtual void OnLocationChanged(EventArgs e)
        {
            LocationChanged?.Invoke(this, e);
        }

        protected internal virtual void DelayRender()
        {
            
        }
    }
}
