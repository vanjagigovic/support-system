using SUPORT_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SUPORT_SYSTEM.Controllers
{
    public class HomeController : Controller
    {

        MainLogic.MainLogic Logic = null;

        public HomeController()
        {

            Logic = new MainLogic.MainLogic();



        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public JsonResult CreateComments(string comment, int ID_ticket)
        {
            Logic.CreateComments(comment, ID_ticket);

            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetComments(int ID_ticket)
        {
            SUPPORT_SYSTEMEntities DB = new SUPPORT_SYSTEMEntities();

            var comment = DB.comments.Where(x => x.ID_ticket == ID_ticket).Select(s => new { s.ID_ticket, s.username, s.ID_parent, s.ID_comments, s.comment1, s.posted_on }).ToList();

            return Json(comment, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Replay(string comment, int ID_ticket, int ID_parent)
        {
            Logic.Replay(comment, ID_ticket, ID_parent);
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public JsonResult AllReplay(int ID_ticket)
        {
            try
            {
                SUPPORT_SYSTEMEntities DB = new SUPPORT_SYSTEMEntities();
                var replay = DB.comments.Where(x => x.ID_ticket==ID_ticket  && x.ID_parent != null).Select(s => new { s.comment1, s.posted_on, s.ID_user, s.ID_comments, s.ID_parent, s.username}).ToArray();
                return Json(replay, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
        }
    }
}