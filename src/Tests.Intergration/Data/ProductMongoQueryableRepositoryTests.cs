﻿using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using NUnit.Framework;
using Web.Data.Interface;
using Web.Domain;

namespace Tests.Intergration.Data
{
    public class ProductMongoQueryableRepositoryTests : BaseMongoIntergrationTest
    {
        private IQueryableRepository<Product> _productRepository;
        private MongoDatabase _database;
        private string _collectionName;
        private MongoCollection<Product> _collection;

        [SetUp]
        public void SetUp()
        {
            _productRepository = ContainerSpecification.Resolve<IQueryableRepository<Product>>();
            _database = ContainerSpecification.Resolve<MongoDatabase>();
            _collectionName = typeof(Product).Name.ToLower();

            _collection = _database.GetCollection<Product>(_collectionName);
        }

        [Test]
        public void GivenThreeProductsWhenTwoOfThoseProductsHaveCostHigherThanTwentyThenQueryingForProductsWithACostHigherThenTwentyShouldReturnTwoOfTheThreeProducts()
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
