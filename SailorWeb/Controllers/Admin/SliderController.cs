using SailorWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SailorWeb.Controllers.Admin
{
    public class SliderController : Controller
    {
        SailorDbContext db = new SailorDbContext();
        // GET: Slider
        public ActionResult Index()
        {
            var item = db.Slider_TBL.ToList();
            return View(item);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var item = from i in db.Slider_TBL where i.SliderId==id select i;
            return View(item.FirstOrDefault());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Slider_TBL st,HttpPostedFileBase ImageURL)
        {
            if (ModelState.IsValid)
            {
                var item = (from i in db.Slider_TBL where i.SliderId == st.SliderId select i).FirstOrDefault();
                if (ImageURL != null)
                {
                    if(System.IO.File.Exists(Server.MapPath(st.ImageURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(st.ImageURL));
                    }
                    WebImage img = new WebImage(ImageURL.InputStream);
                    img.Resize(1990, 800,true,true);
                    FileInfo imgInfo =new FileInfo(ImageURL.FileName);
                    string imgName =ImageURL.FileName;
                    img.Save("~/Uploads/Slider/" +imgName);
                    item.ImageURL = "/Uploads/Slider/" + imgName;
                }
                item.SliderHeader = st.SliderHeader;
                item.Description = st.Description;
                item.ButtonText = st.ButtonText;
                item.ButtonURL = st.ButtonURL;
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
        public ActionResult Create(Slider_TBL st,HttpPostedFileBase ImageURL)
        {
            if(ModelState.IsValid)
            {
                if (ImageURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(st.ImageURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(st.ImageURL));
                    }
                    WebImage img = new WebImage(ImageURL.InputStream);
                    img.Resize(1990, 800, true, true);
                    FileInfo imgInfo = new FileInfo(ImageURL.FileName);
                    string imgName = ImageURL.FileName;
                    img.Save("~/Uploads/Slider/" + imgName);
                    st.ImageURL= "/Uploads/Slider/" + imgName;
                }
                db.Slider_TBL.Add(st);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var item = from i in db.Slider_TBL where i.SliderId==id select i;
            db.Slider_TBL.Remove(item.FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var item = from i in db.Slider_TBL where i.SliderId==id select i;

            return View(item.FirstOrDefault());
        }
    }
}