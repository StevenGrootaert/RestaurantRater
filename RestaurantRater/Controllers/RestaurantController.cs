using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Restaurants.Add(restaurant);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        // GET: Restaurant/Delete/{id}
        public ActionResult Delete(int? id) // int with ? makes the int 'nullable'
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurant/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Restaurant restaurant = _db.Restaurants.Find(id); // find the restaurant in the database
            _db.Restaurants.Remove(restaurant); // remove the restuarant in the database
            _db.SaveChanges(); // save the changes (_field is just a snapshot of the current Database)
            return RedirectToAction("Index"); // return to the index page after deletion
        }
    }
}