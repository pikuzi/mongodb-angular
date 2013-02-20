using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using NUnit.Framework;

namespace Tests.Intergration
{
    public class BaseMongoIntergrationTest
    {
        [TearDown]
        public void TearDown()
        {
            var database = ContainerSpecification.Resolve<MongoDatabase>();
            database.Drop();
        }
    }
}
