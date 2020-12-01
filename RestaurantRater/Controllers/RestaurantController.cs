using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant/INDEX method (URL will say Restaurant)
        public ActionResult Index()
        {
            return View();
        }
    }
}