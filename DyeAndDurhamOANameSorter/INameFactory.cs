using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyeAndDurhamOANameSorter
{
    public interface INameFactory
    {
        IName ProduceName();
    }
}
