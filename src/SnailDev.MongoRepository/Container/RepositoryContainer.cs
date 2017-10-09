using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailDev.MongoRepository
{
    /// <summary>
    /// 容器
    /// </summary>
    public static class RepositoryContainer
    {
        /// <summary>
        /// 
        /// </summary>
        public static ConcurrentDictionary<string, Lazy<object>> Instances { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        static RepositoryContainer()
        {
            Instances = new ConcurrentDictionary<string, Lazy<object>>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="service"></param>
        public static void Register<T>(T service)
            where T : IMongoRepository
        {
            var t = typeof(T);
            var lazy = new Lazy<object>(() => service);

            Instances.AddOrUpdate(GetKey(t), lazy, (x, y) => lazy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Register<T>()
            where T : IMongoRepository, new()
        {
            var t = typeof(T);
            var lazy = new Lazy<object>(() => new T());

            Instances.AddOrUpdate(GetKey(t), lazy, (x, y) => lazy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="function"></param>
        public static void Register<T>(Func<object> function)
            where T : IMongoRepository
        {
            var t = typeof(T);
            var lazy = new Lazy<object>(function);

            Instances.AddOrUpdate(GetKey(t), lazy, (x, y) => lazy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
            where T : IMongoRepository
        {
            var t = typeof(T);
            var k = GetKey(t);

            Lazy<object> repository;
            if (Instances.TryGetValue(k, out repository))
            {
                return (T)repository.Value;
            }
            else
            {
                throw new Exception($"this repository({k}) is not register");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private static string GetKey(Type t)
        {
            return t.FullName;
        }

    }
}
