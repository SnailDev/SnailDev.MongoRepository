using MongoDB.Bson.Serialization.Attributes;
using SnailDev.MongoEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailDev.MongoRepositoryTests
{
    [BsonIgnoreExtraElements]
    public class User : IAutoIncr<long>
    {
        [BsonId]
        public long ID { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateTime { get; set; }

        public string Stamp { get; set; }

        public User()
        {
            CreateTime = DateTime.Now;
        }
    }
}
