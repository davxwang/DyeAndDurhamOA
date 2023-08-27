﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyeAndDurhamOANameSorter
{
    /// <summary>
    /// Interface for NameSorters. 
    /// ICollection used for flexibility.
    /// </summary>
    public interface INameSorter
    {
        void Add(IName name);
        void Remove(IName name);
        void Clear();
        void Replace(ICollection<IName> names);
        ICollection<IName> GetResult();
    }
}
