using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : Controller
    {
        // we can't pull from the database without making a field..
        private RestaurantDbContext _db = new RestaurantDbContext();

        // GET: Restaurant/INDEX method (URL will say Restaurant)
        public ActionResult Index()
        {
            return View(_db.Restaurants.ToList()); // this (the whole list of restarants from the database) will pass into the view
        }
    }
}