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
    public class PageIdentityController : Controller
    {
        SailorDbContext db = new SailorDbContext();
        // GET: PageIdentity
        public ActionResult Index()
        {
            var items = from i in db.PageIdentity_TBL select i;
            return View(items.FirstOrDefault());
        }

        [HttpGet]
        public ActionResult Edit(int? id=1)
        {
            var item = from i in db.PageIdentity_TBL select i;
            if (db.PageIdentity_TBL.Any(x => x.PId == id))
            {
                item = from i in db.PageIdentity_TBL where i.PId == id select i;
            }
            return View(item.FirstOrDefault());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PageIdentity_TBL pt,HttpPostedFileBase LogoURL)
        {
           
                if (ModelState.IsValid)
                {
                    var item = (from i in db.PageIdentity_TBL where i.PId == pt.PId select i).FirstOrDefault();
                    if(LogoURL != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath(pt.LogoURL)))
                        {
                            System.IO.File.Delete(Server.MapPath(pt.LogoURL));
                        }
                       
                        WebImage img = new WebImage(LogoURL.InputStream);
                        FileInfo imgInfo = new FileInfo(LogoURL.FileName);
                        string logoName = LogoURL.FileName;
                          img.Resize(300, 300);
                        img.Save("~/Uploads/PageIdentity/"+logoName);
                        item.LogoURL = "/Uploads/PageIdentity/"+ logoName;

                    }
            
                    item.MetaAuthor = pt.MetaAuthor;
                    item.MetaDescription = pt.MetaDescription;
                    item.MetaKeywords = pt.MetaKeywords;
                    item.PageTitle = pt.PageTitle;
    
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            
            

                return View(pt);
            
        }
        public ActionResult Details(int id)
        {
            var item = (from i in db.PageIdentity_TBL where i.PId==id select i).FirstOrDefault();

            return View(item);
        }
    }
}