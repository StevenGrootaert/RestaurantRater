using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        // GET: Restuarant/Edit/{id}
        // get an id from the user
        // find a rest by that id
        // handle if the id in null
        // if the rest doesn't exist
        // return the rest and the view
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _db.Restaurants.Find(id); // Restuarant Object called restuarnt set equal to a snapshot/calling our database(db called restuarants)then call that find method pass in restuarnt by an {id}
            if (restaurant == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound); // why not just say return HttpNotFound ??
            }
            return View();
        }


        // POST: Restuarant/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restuarant)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(restuarant).State = EntityState.Modified; // Access the state property find entry min 27:30 in video ... apply only modied rows in database
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restuarant);
        }
    }
}