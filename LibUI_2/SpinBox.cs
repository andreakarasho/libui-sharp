﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibUI.Interface;
using LibUI.Interop;

namespace LibUI
{
    public class SpinBox : Control
    {
        public event EventHandler ValueChanged;

        private int _value;
        public int Value
        {
            get
            {
                _value = NativeMethods.SpinBoxValue(handle);
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    NativeMethods.SpinBoxSetValue(handle, value);
                    _value = value;
                }
            }
        }

        public SpinBox(int min, int max)
        {
            handle = NativeMethods.NewSpinBox(min, max);
            InitializeEvents();
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        protected sealed override void InitializeEvents()
        {
            NativeMethods.SpinBoxOnChanged(handle, (box, data) =>
            {
                OnValueChanged(EventArgs.Empty);
            }, IntPtr.Zero);
        }
    }
}
