using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using NUnit.Framework;
using Web.Data.Extensions;
using Web.Data.Interface;
using Web.Domain;

namespace Tests.Intergration.Data
{
    [TestFixture]
    public class ProductMongoWritableRepositoryTests : BaseMongoIntergrationTest
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
        public void GivenAProductWhenThatProductIsSavedThenThatProductShouldBeRetrivable()
        {
            var product = new Product("Test", "A product created during an intergration test", 19.99);
            _productRepository.Save(product);
            var persitedProduct = _collection.Get(product.Id);

            Assert.That(persitedProduct.Id, Is.EqualTo(product.Id));
        }

        [Test]
        public void GivenAnExistingProductWhenDeleteIsCalledThenThatProductShouldBeNoLongerRetrievable()
        {
            var product = new Product("Test", "A product created during an intergration test", 19.99);
            _collection.Save(product);

            _productRepository.Delete(product);
            var deletedProduct = _collection.Get(product.Id);

            Assert.That(deletedProduct, Is.Null);
        }
    }
}
