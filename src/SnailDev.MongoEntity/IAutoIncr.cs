using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailDev.MongoEntity
{
    /// <summary>
    /// entity has increment primary key
    /// </summary>
    public interface IAutoIncr
    {

    }

    /// <summary>
    /// entity has increment primary key
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IAutoIncr<TKey> : IAutoIncr, IEntity<TKey>
    {

    }
}
