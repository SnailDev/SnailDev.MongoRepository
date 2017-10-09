using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnailDev.MongoRepositoryTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailDev.MongoRepository.UnitTest
{
    [TestClass]
    public class MongoRepositoryTest
    {
        [TestMethod]
        public void Insert()
        {
            UserRep userRep = new UserRep();

            userRep.Insert(new User() { Name = "ggg" });
            userRep.Insert(new User() { Name = "BBB" });
            userRep.Insert(new User() { Name = "CCC" });

            var list = userRep.GetList(x => x.Name == "ggg").ToList();
            UserRep up = new UserRep();
            list = up.GetList(x => x.Name == "ggg").ToList();
            Assert.AreNotEqual(list.Count, 0);
        }
    }
}
