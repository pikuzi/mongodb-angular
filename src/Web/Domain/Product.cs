using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Domain
{
    public class Product : AggregateRoot
    {
        protected Product() { }

        public Product(string title, string description, double cost)
        {
            Title = title;
            Description = description;
            Cost = cost;
        }

        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public double Cost { get; protected set; }

        private List<Review> _reviews = new List<Review>();
        public IEnumerable<Review> Reviews
        {
            get { return _reviews; }
            protected set { _reviews = value.ToList(); }
        } 

        public void AddReview(Review review)
        {
            _reviews.Add(review);
        }
    }

    public class Review
    {
        protected Review() { }

        public Review(string author, string title, string content, int score)
        {
            Author = author;
            Title = title;
            Content = content;
            Score = score;
        }

        public string Author { get; protected set; }
        public string Title { get; protected set; }
        public string Content { get; protected set; }
        public int Score { get; protected set; }
    }
}