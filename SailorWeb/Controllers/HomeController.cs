using SailorWeb.Models;
using SailorWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace SailorWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        SailorDbContext db = new SailorDbContext();
        public ActionResult Index()
        {
            var items = from i in db.Contact_TBL select i ;

            return View(items.ToList());
        }
  
    }
}