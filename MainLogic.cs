using SUPORT_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SUPORT_SYSTEM.MainLogic
{
    public class MainLogic
    {
        SUPPORT_SYSTEMEntities DB = new SUPPORT_SYSTEMEntities();

        public MainLogic()
        {
            DB = new SUPPORT_SYSTEMEntities();
        }

        public void CreateComments(string comment, int ID_ticket)
        {
            var newComment = new comment
            {
                comment1 = comment,
                ID_ticket = ID_ticket,
                posted_on = DateTime.Now,
                username = HttpContext.Current.User.Identity.Name
            };

            DB.comments.Add(newComment);
            DB.SaveChanges();
        }
        public void Replay(string comment, int ID_ticket, int ID_parent)
        {
            var newReplay = new comment
            {
                comment1 = comment,
                ID_ticket = ID_ticket,
                ID_parent = ID_parent,
                posted_on = DateTime.Now,
                username = HttpContext.Current.User.Identity.Name
            };
            DB.comments.Add(newReplay);
            DB.SaveChanges();
        }
    }
}
