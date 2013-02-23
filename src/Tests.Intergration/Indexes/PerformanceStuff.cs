using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Faker.Generators;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using NUnit.Framework;
using Web.Infrastructure.DataStore;

namespace Tests.Intergration.Indexes
{
    [TestFixture]
    public class PerformanceStuff
    {
        private MongoDatabase _database;
        private string _collectionName;
        private string _databaseName;
        private MongoCollection<Product> _collection;

        [SetUp]
        public void SetUp()
        {
            _databaseName = ConfigurationManager.ConnectionStrings["mongodb"].ProviderName;
            _collectionName = typeof(Product).Name.ToLower();

            //Doing this by hand instead of container spec
            var server = MongoServerFactory.Build();
            server.DropDatabase(_databaseName);
            _database = server.GetDatabase(_databaseName);

            _collection = _database.GetCollection<Product>(_collectionName);
            _collection.Drop();

            PopulateCollectionWithRandomProducts(100000);
        }

        [Test]
        public void InsertOneHundredThousandAndSelectTopFiveWithoutIndex()
        {
            var start = DateTime.Now;
            var mostExpensiveProducts = _collection.AsQueryable().OrderByDescending(p => p.Cost).Take(5).ToList();

            var difference = DateTime.Now - start;

            Console.WriteLine("Top 5 query without an index took approx {0} milliseconds", difference.TotalMilliseconds);
            Assert.That(mostExpensiveProducts.Count, Is.EqualTo(5));
        }

        [Test]
        public void InsertOneHundredThousandAndSelectTopFiveWithIndexApplied()
        {
            _collection.EnsureIndex(new IndexKeysBuilder().Descending("Cost"));

            var start = DateTime.Now;
            var mostExpensiveProducts = _collection.AsQueryable().OrderByDescending(p => p.Cost).Take(5).ToList();
            
            var difference = DateTime.Now - start;

            Console.WriteLine("Top 5 query without an index took approx {0} milliseconds", difference.TotalMilliseconds);
            Assert.That(mostExpensiveProducts.Count, Is.EqualTo(5));
        }

        private void PopulateCollectionWithRandomProducts(int count)
        {
            var start = DateTime.Now;
            Console.WriteLine("Starting insert of {0} random products at {1}", count, start.ToShortTimeString());

            while (count > 0)
            {
                var product = new Product(Strings.GenerateAlphaNumericString(5, 25), Strings.GenerateAlphaNumericString(10, 250), Numbers.Double(max: 5000000));
                _collection.Save(product);
                count--;
            }

            var difference = DateTime.Now - start;
            Console.WriteLine("Finshed insert, took {0} milliseconds", difference.TotalMilliseconds);
        }
    }
}
