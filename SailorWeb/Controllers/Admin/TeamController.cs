using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SailorWeb.Models.Model;
using PagedList;
using PagedList.Mvc;
using System.Web.Helpers;
using System.IO;

namespace SailorWeb.Controllers.Admin
{
    public class TeamController : Controller
    {
        SailorDbContext db = new SailorDbContext();
        // GET: Team
        public ActionResult Index(int page=1)
        {
            var item = (from i in db.Team_TBL select i).ToList().ToPagedList(page,5);
            return View(item);
        }
        public ActionResult Details(int? id=1)
        {
            var item = from i in db.Team_TBL where i.TeamId == id select i;
            return View(item.FirstOrDefault());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Team_TBL tt, HttpPostedFileBase ATeamImage)
        {
            if (ModelState.IsValid)
            {
                if (ATeamImage != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(tt.TeamImg)))
                    {
                        System.IO.File.Delete(Server.MapPath(tt.TeamImg));
                    }
                    WebImage img = new WebImage(ATeamImage.InputStream);
                    img.Resize(300, 300);
                    FileInfo imgInfo = new FileInfo(ATeamImage.FileName);
                    string imgName = ATeamImage.FileName;
                    img.Save("~/Uploads/Team/"+imgName);
                    tt.TeamImg = "/Uploads/Team/" + imgName;
                }
                db.Team_TBL.Add(tt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tt);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var item = (from i in db.Team_TBL where i.TeamId==id select i).FirstOrDefault();
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Team_TBL tt,HttpPostedFileBase ATeamImage) 
        {
            if (ModelState.IsValid)
            {
                var item = (from i in db.Team_TBL where i.TeamId == tt.TeamId select i).FirstOrDefault();
                if (ATeamImage!=null)
                {
                    if (System.IO.File.Exists(Server.MapPath(tt.TeamImg)))
                    {
                        System.IO.File.Delete(Server.MapPath(tt.TeamImg));
                    }
                    WebImage img = new WebImage(ATeamImage.InputStream);
                    FileInfo fileInfo = new FileInfo(ATeamImage.FileName);
                    img.Resize(300, 300);
                    string imgName = ATeamImage.FileName;
                    img.Save("~/Uploads/Team/" + imgName);
                    item.TeamImg = "/Uploads/Team/" + imgName;
                }
                item.TeamName = tt.TeamName;
                item.TeamPosition = tt.TeamPosition;
                item.TeamDescription = tt.TeamDescription;
                item.Facebook = tt.Facebook;
                item.Instagram = tt.Instagram;
                item.Linkedin = tt.Linkedin;
                item.Twitter = tt.Twitter;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tt);

        }
        public ActionResult Delete(int id)
        {
            var item = from i in db.Team_TBL where i.TeamId == id select i;
            db.Team_TBL.Remove(item.FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}