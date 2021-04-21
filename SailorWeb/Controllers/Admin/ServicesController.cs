using SailorWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SailorWeb.Controllers.Admin
{
    public class ServicesController : Controller
    {
        SailorDbContext db = new SailorDbContext();
        // GET: Services
        public ActionResult Index()
        {
            var items = from i in db.Services_TBL select i;
            return View(items.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Services_TBL st)
        {
            if (ModelState.IsValid)
            {
                db.Services_TBL.Add(st);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(st);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var item = from i in db.Services_TBL where i.ServiceId==id select i;
            return View(item.FirstOrDefault());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Services_TBL st)
        {
          
            if (ModelState.IsValid)
            {
                if (db.Services_TBL.Any(x => x.ServiceId == st.ServiceId))
                {
                    ValidateRequest = false;
                    var items = (from i in db.Services_TBL where i.ServiceId==st.ServiceId select i).FirstOrDefault();
                    items.ServiceName = st.ServiceName;
                    items.ServiceIcon = st.ServiceIcon;
                    items.ServiceDescription = st.ServiceDescription.Trim();
                    db.SaveChanges();
                }
                
                return RedirectToAction("Index");
            }
            return View(st);
        }
        public ActionResult Details(int? id)
        {
            if (db.Services_TBL.Any(x => x.ServiceId == id))
            {
                var items = from i in db.Services_TBL where i.ServiceId==id select i;

                return View(items.FirstOrDefault());
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            if (db.Services_TBL.Any(x => x.ServiceId == id))
            {
                var item = from i in db.Services_TBL where i.ServiceId==id select i;
                db.Services_TBL.Remove(item.FirstOrDefault());
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}