﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibUI
{
    public enum Modifiers
    {
        Ctrl = 1 << 0,
        Alt = 1 << 1,
        Shift = 1 << 2,
        Super = 1 << 3,
    }
}
