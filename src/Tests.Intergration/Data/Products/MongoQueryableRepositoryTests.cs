using System.Linq;
using Data.Interface;
using Domain;
using MongoDB.Driver;
using NUnit.Framework;

namespace Tests.Intergration.Data.Products
{
    public class MongoQueryableRepositoryTests : BaseMongoIntergrationTest
    {
        private MongoCollection<Product> _collection;
        private string _collectionName;
        private MongoDatabase _database;
        private IQueryableRepository<Product> _productRepository;

        [SetUp]
        public void SetUp()
        {
            _productRepository = ContainerSpecification.Resolve<IQueryableRepository<Product>>();
            _database = ContainerSpecification.Resolve<MongoDatabase>();
            _collectionName = typeof (Product).Name.ToLower();

            _collection = _database.GetCollection<Product>(_collectionName);
        }

        [Test]
        public void GivenThreeProductsWhenTwoOfThoseProductsHaveCostHigherThanTwentyThenQueryingForProductsWithACostHigherThanTwentyShouldReturnTwoOfTheThreeProducts()
        {
            var productOne = new Product("Test", "A product created during an intergration test", 19.99);
            var productTwo = new Product("Test", "A product created during an intergration test", 100.00);
            var productThree = new Product("Test", "A product created during an intergration test", 20.01);

            _collection.Save(productOne);
            _collection.Save(productTwo);
            _collection.Save(productThree);

            var highPricedProducts = _productRepository.Query().Where(p => p.Cost > 20.00);

            Assert.That(highPricedProducts.Count(), Is.EqualTo(2));
        }
    }
}