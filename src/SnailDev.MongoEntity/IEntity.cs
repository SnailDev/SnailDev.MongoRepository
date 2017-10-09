using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailDev.MongoEntity
{
    /// <summary>
    /// entity
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IEntity<TKey>
    {
        /// <summary>
        /// primary key
        /// </summary>
        TKey ID { get; set; }
    }
}
