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
    public class SkillsController : Controller
    {
        SailorDbContext db = new SailorDbContext();
        // GET: Skills
        public ActionResult Index(int page = 1)
        {
            var items = db.Skills_TBL.ToList().ToPagedList(page, 6);
            return View(items);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var item = from i in db.Skills_TBL where i.SkillsID == id select i;

            return View(item.FirstOrDefault());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Skills_TBL st)
        {
            if (ModelState.IsValid)
            {
                var item = db.Skills_TBL.Where(x => x.SkillsID == st.SkillsID).FirstOrDefault();
                item.SkillsName = st.SkillsName;
                item.SkillPercent = st.SkillPercent;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(st);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Skills_TBL st)
        {
            if(ModelState.IsValid)
            {
                db.Skills_TBL.Add(st);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(st);
           
        }
        public ActionResult Delete(int id)
        {
            var item = from i in db.Skills_TBL where i.SkillsID == id select i;
            db.Skills_TBL.Remove(item.FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}