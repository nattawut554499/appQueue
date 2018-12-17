using AppointmentV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppointmentV2.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: Home
        public ActionResult calendar()
        {
 
            //var today = DateTime.Now;
            //cEvents events = new cEvents();
            //events.Subject = "second eSubject";
            //events.Description = "second no maybe third Description what event you wanna do";
            //events.Start = today;
            //events.End = null;
            //events.ThemeColor = "green";
            //events.IsFullDay = true;

            //db.tbEvents.Add(events);
            //db.SaveChanges();

            return View();
        }

        public ActionResult GetEvents()
        {
            using(ConnectionString db = new ConnectionString())
            {
                var events = db.tbEvents.ToList();
                return new JsonResult{ Data = events,JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        public ActionResult SaveEvent(cEvents ce)
        {
            var status = false; 
            using (ConnectionString db = new ConnectionString())
            {
                // update the event
                if (ce.EventID > 0)
                {
                    var v = db.tbEvents.Where(a => a.EventID == ce.EventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = ce.Subject;
                        v.Description = ce.Description;
                        v.Start = ce.Start;
                        v.End = ce.End;
                        v.ThemeColor = ce.ThemeColor;
                        v.IsFullDay = ce.IsFullDay;
                    }
                }
                else
                {
                    db.tbEvents.Add(ce);
                }
                db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public ActionResult DeleteEvent(int EventID)
        {
            var status = false;
            using (ConnectionString db = new ConnectionString())
            {
                var v = db.tbEvents.Where(a => a.EventID == EventID).FirstOrDefault();
                if (v != null)
                {
                    db.tbEvents.Remove(v);
                    db.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}