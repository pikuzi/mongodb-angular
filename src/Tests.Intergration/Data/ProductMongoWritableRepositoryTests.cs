using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using NUnit.Framework;
using Web.Data.Interface;
using Web.Domain;

namespace Tests.Intergration.Data
{
    [TestFixture]
    public class ProductMongoWritableRepositoryTests
    {
        private IWritableRepository<Product> _productRepository;
        private MongoDatabase _database;
        private string _collectionName;
        private MongoCollection<Product> _collection;
            
        [SetUp]
        public void SetUp()
        {
            _productRepository = ContainerSpecification.Resolve<IWritableRepository<Product>>();
            _database = ContainerSpecification.Resolve<MongoDatabase>();
            _collectionName = typeof (Product).Name.ToLower();

            _collection = _database.GetCollection<Product>(_collectionName);
        }

        [Test]
        public void GivenAProductWhenThatProductIsSavedThenThatProductShouldBeRetrivableDirectly()
        {
            var product = new Product("Test", "A product created during an intergration test", (decimal)19.99);

            _productRepository.Save(product);

            var query = Query.EQ("_id", product.Id);
            var persitedProduct = _collection.FindOne(query);

            Assert.That(persitedProduct.Id, Is.EqualTo(product.Id));
        }
    }
}
