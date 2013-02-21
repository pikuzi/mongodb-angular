using System.Linq;
using Faker.Generators;
using MongoDB.Driver;
using NUnit.Framework;
using Web.Data.Extensions;
using Web.Data.Interface;
using Web.Domain;

namespace Tests.Intergration.Data.Products
{
    [TestFixture]
    public class MongoWritableRepositoryTests : BaseMongoIntergrationTest
    {
        private IWritableRepository<Product> _productRepository;
        private MongoDatabase _database;
        private string _collectionName;
        private MongoCollection<Product> _collection;
        private Product _product;
            
        [SetUp]
        public void SetUp()
        {
            _product = new Product("Test", "A product created during an intergration test", 19.99);
            _productRepository = ContainerSpecification.Resolve<IWritableRepository<Product>>();
            _database = ContainerSpecification.Resolve<MongoDatabase>();
            _collectionName = typeof (Product).Name.ToLower();

            _collection = _database.GetCollection<Product>(_collectionName);
        }

        [Test]
        public void GivenAProductWhenThatProductIsSavedThenThatProductShouldBeRetrivable()
        {
            _productRepository.Save(_product);
            var persitedProduct = _collection.Get(_product.Id);

            Assert.That(persitedProduct.Id, Is.EqualTo(_product.Id));
        }

        [Test]
        public void GivenAnExistingProductWhenDeleteIsCalledThenThatProductShouldBeNoLongerRetrievable()
        {
            _collection.Save(_product);

            _productRepository.Delete(_product);
            var deletedProduct = _collection.Get(_product.Id);

            Assert.That(deletedProduct, Is.Null);
        }

        [Test]
        public void GivenANewProductWhenTheProductHasAReviewThenTheReviewIsPersisted()
        {
            var review = new Review(Names.FullName(), Strings.GenerateAlphaNumericString(), Strings.GenerateAlphaNumericString(maxLength: 1000), Numbers.Int(1, 5));
            _product.AddReview(review);

            _productRepository.Save(_product);

            var persitedProduct = _collection.Get(_product.Id);

            Assert.That(persitedProduct.Reviews.First().Author, Is.EqualTo(review.Author));
        }

        [Test]
        public void GivenAnExistingProductWhenTheProductHasAReviewThenTheReviewIsPersisted()
        {
            _productRepository.Save(_product);

            var review = new Review(Names.FullName(), Strings.GenerateAlphaNumericString(), Strings.GenerateAlphaNumericString(maxLength: 1000), Numbers.Int(1, 5));
            _product.AddReview(review);

            _productRepository.Save(_product);

            var persitedProduct = _collection.Get(_product.Id);

            Assert.That(persitedProduct.Reviews.First().Author, Is.EqualTo(review.Author));
        }
    }
}
