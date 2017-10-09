using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailDev.MongoEntity
{
    /// <summary>
    /// logical deletion constraint
    /// </summary>
    public interface IVirtualDel
    {
        /// <summary>
        /// is logical deletion
        /// </summary>
        bool IsDel { get; set; }
    }
}
