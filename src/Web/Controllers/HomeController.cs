using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly MongoDatabase _database;

        public HomeController(MongoDatabase database)
        {
            _database = database;
        }

        public ActionResult Index()
        {
            return Content(_database.Name);
        }
    }
}
