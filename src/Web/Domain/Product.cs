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
    }
}