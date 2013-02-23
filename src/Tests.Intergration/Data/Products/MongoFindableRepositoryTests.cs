using Data.Interface;
using Domain;
using MongoDB.Driver;
using NUnit.Framework;

namespace Tests.Intergration.Data.Products
{
    [TestFixture]
    public class MongoFindableRepositoryTests : BaseMongoIntergrationTest
    {
        private IFindableRepository<Product> _productRepository;
        private MongoDatabase _database;
        private string _collectionName;
        private MongoCollection<Product> _collection;

        [SetUp]
        public void SetUp()
        {
            _productRepository = ContainerSpecification.Resolve<IFindableRepository<Product>>();
            _database = ContainerSpecification.Resolve<MongoDatabase>();
            _collectionName = typeof(Product).Name.ToLower();

            _collection = _database.GetCollection<Product>(_collectionName);
        }

        [Test]
        public void GivenAProductWhenFindIsCalledThenTheExpectedProductShouldBeReturned()
        {
            var product = new Product("Test", "A product created during an intergration test", 19.99);
            _collection.Save(product);

            var persistedProduct = _productRepository.Find(product.Id);

            Assert.That(persistedProduct.Id, Is.EqualTo(product.Id));
        }
    }
}
