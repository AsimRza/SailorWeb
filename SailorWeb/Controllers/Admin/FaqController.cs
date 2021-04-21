
using SailorWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace SailorWeb.Controllers.Admin
{
    public class FaqController : Controller
    {
        SailorDbContext db = new SailorDbContext();
        // GET: Faq
        public ActionResult Index(int page = 1)
        {
            var items = (from item in db.Faq_TBL select item).ToList().ToPagedList(page, 6);
            return View(items);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var items=from item in db.Faq_TBL select item;
            if(db.Faq_TBL.Any(x=>x.FaqId==id))
              items = from item in db.Faq_TBL where item.FaqId==id select item;

            return View(items.FirstOrDefault());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Faq_TBL ft)
        {
            if (ModelState.IsValid)
            {
                var item = (from i in db.Faq_TBL where i.FaqId == ft.FaqId select i).FirstOrDefault() ;
                item.FaqHeader = ft.FaqHeader;
                item.FaqDescription = ft.FaqDescription;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ft);
        }
        public ActionResult Details(int? id)
        {
            var item = (from i in db.Faq_TBL where i.FaqId == id select i).FirstOrDefault();

            return View(item);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Faq_TBL ft)
        {
            if (ModelState.IsValid)
            {
                db.Faq_TBL.Add(ft);
                db.SaveChanges();
               return RedirectToAction("Index");
            }
            return View(ft);
        }
        public ActionResult Delete(int id)
        {
            var item = from i in db.Faq_TBL where i.FaqId==id select i;

            db.Faq_TBL.Remove(item.FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}