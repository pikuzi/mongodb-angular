using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faker.Generators;
using NUnit.Framework;
using Web.Domain;

namespace Tests.Unit.Domain
{
    [TestFixture]
    public class ProductTests
    {
        private Product _product;
        private Review _review;
        private string _title, _description, _reviewTitle, _reviewContent, _reviewAuthor;
        private double _cost;
        private int _reviewScore;

        [SetUp]
        public void SetUp()
        {
            _title = Strings.GenerateAlphaNumericString();
            _description = Strings.GenerateAlphaNumericString();
            _cost = Numbers.Double();
            _reviewTitle = Strings.GenerateAlphaNumericString();
            _reviewContent = Strings.GenerateAlphaNumericString();
            _reviewAuthor = Names.FullName();
            _reviewScore = Numbers.Int(1, 5);
            
            _review = new Review(_reviewAuthor, _reviewTitle, _reviewContent, _reviewScore);
            _product = new Product(_title, _description, _cost);
        }

        [Test]
        public void CtorSetsTitle()
        {
            Assert.That(_product.Title, Is.EqualTo(_title));
        }

        [Test]
        public void CtorSetsDesciption()
        {
            Assert.That(_product.Description, Is.EqualTo(_description));
        }

        [Test]
        public void CtorSetsCost()
        {
            Assert.That(_product.Cost, Is.EqualTo(_cost));
        }

        [Test]
        public void ReviewCtorSetsTitle()
        {
            Assert.That(_review.Title, Is.EqualTo(_reviewTitle));
        }

        [Test]
        public void ReviewCtorSetsContent()
        {
            Assert.That(_review.Content, Is.EqualTo(_reviewContent));
        }

        [Test]
        public void ReviewCtorSetsAuthor()
        {
            Assert.That(_review.Author, Is.EqualTo(_reviewAuthor));
        }

        [Test]
        public void ReviewCtorSetsScore()
        {
            Assert.That(_review.Score, Is.EqualTo(_reviewScore));
        }

        [Test]
        public void GivenAProductWithNoReviewsWhenAReviewIsAddedThenTheProductHasOneReview()
        {
            _product.AddReview(_review);
            Assert.That(_product.Reviews.Count(), Is.EqualTo(1));
        }
    }
}
