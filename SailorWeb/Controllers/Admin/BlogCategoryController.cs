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
    public class BlogCategoryController : Controller
    {
        SailorDbContext db = new SailorDbContext();
        // GET: BlogCategory
        public ActionResult Index(int page =1)
        {
            var item = db.BlogCategory_TBL.ToList().ToPagedList(page,6);
            return View(item);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BlogCategory_TBL bct)
        {
            if(ModelState.IsValid)
            {
                db.BlogCategory_TBL.Add(bct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var item = from i in db.BlogCategory_TBL where i.CategoryId==id select i;
            return View(item.FirstOrDefault());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BlogCategory_TBL bct)
        {
            if (ModelState.IsValid)
            {
                var item = (from i in db.BlogCategory_TBL where i.CategoryId == bct.CategoryId select i).FirstOrDefault();
                item.Name = bct.Name;
                item.Description = bct.Name;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}