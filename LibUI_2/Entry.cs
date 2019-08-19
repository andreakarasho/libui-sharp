using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibUI.Interop;

namespace LibUI
{
    public class Entry : EntryBase
    {
        public enum Types : byte
        {
            Basic,
            Password,
            Search
        }

        public Entry() : base(Types.Basic)
        {
        }
    }

    public class PasswordEntry : EntryBase
    {
        public PasswordEntry() : base(Entry.Types.Password)
        {
        }
    }

    public class SearchEntry : EntryBase
    {
        public SearchEntry() : base(Entry.Types.Search)
        {
        }
    }
}
