using SailorWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Web.Helpers;
using System.IO;

namespace SailorWeb.Controllers.Admin
{
    public class TestimonialsController : Controller
    {
        SailorDbContext db = new SailorDbContext();
        // GET: Testimonials
        public ActionResult Index(int page=1)
        {
            var items = (from i in db.Testimionals_TBL select i).ToList().ToPagedList(page,6);
            return View(items);
        }
        public ActionResult Details(int id)
        {
            var item = from i in db.Testimionals_TBL where i.TestimonialsId == id select i;
            return View(item.FirstOrDefault());
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var item = from i in db.Testimionals_TBL where i.TestimonialsId==id select i;
            return View(item.FirstOrDefault());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Testimionals_TBL tt,HttpPostedFileBase TestimImage)
        {
            if (ModelState.IsValid)
            {
                var item = (from i in db.Testimionals_TBL where i.TestimonialsId == tt.TestimonialsId select i).FirstOrDefault();
                if (ModelState.IsValid)
                {
                    if (TestimImage != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath(tt.ImageURL)))
                        {
                            System.IO.File.Delete(Server.MapPath(tt.ImageURL));
                        }
                        WebImage img = new WebImage(TestimImage.InputStream);
                        FileInfo fileInfo = new FileInfo(TestimImage.FileName);
                        img.Resize(300, 300);
                        string imgName = TestimImage.FileName;
                        img.Save("~/Uploads/Testimionals/" + imgName);
                        item.ImageURL = "/Uploads/Testimionals/" + imgName;
                    }
                }
                item.NameSurname = tt.NameSurname;
                item.TestimionalDescription = tt.TestimionalDescription;
                item.TestimonialJob = tt.TestimonialJob;
                
                db.SaveChanges();       
                return RedirectToAction("Index");
            }
            return View(tt);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Testimionals_TBL tt,HttpPostedFileBase ImageURL)
        {
            if (ModelState.IsValid)
            {
                if (ImageURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(tt.ImageURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(tt.ImageURL));
                    }
                    WebImage img = new WebImage(ImageURL.InputStream);
                    FileInfo fileInfo = new FileInfo(ImageURL.FileName);
                    img.Resize(300, 300);
                    string imgName = ImageURL.FileName;
                    img.Save("~/Uploads/Testimionals/" + imgName);
                    tt.ImageURL = "/Uploads/Testimionals/" + imgName;
                }
                db.Testimionals_TBL.Add(tt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tt);
        }
        public ActionResult Delete(int id)
        {
            var item = from i in db.Testimionals_TBL where i.TestimonialsId == id select i;
            db.Testimionals_TBL.Remove(item.FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}