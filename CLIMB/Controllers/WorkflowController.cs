using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web;
using System.Web.Mvc;
using CLIMB.Models;
using CLIMB.DataAccess;

namespace CLIMB.Controllers
{
    public class WorkflowController : Controller
    {
        //
        // GET: /WorkflowDetail/
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Index()
        {
            var eventDB = new EventDB();
            return View(eventDB.GetEvents());
        }

        [HttpPost] 
        public ActionResult Create(string eventType)
        {
            try
            {
                int eventKey=0;
                switch (eventType)
                {
                    case "matingEvent":
                        eventKey = 1;
                        break;
                    case "weanEvent":
                        eventKey = 2;
                        break;
                    case "shipEvent":
                        eventKey = 3;
                        break;
                }
                var eventDB = new EventDB();
                EventModel event_ = new EventModel();
                event_._EventType_key = eventKey;
                event_.ActualDate = DateTime.Now;
                event_.CreatedBy="admin";
                event_.DateCreated=DateTime.Now;
                event_.DateModified=DateTime.Now;
                event_.EventID="M1";
                event_.EventName = eventType;
                event_.ModifiedBy = "admin";
                event_.ProjectedDate=DateTime.Now;

                eventDB.Create(event_);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public string Events()
        {
            var eventDB = new EventDB();
            IEnumerable<EventModel> events = eventDB.GetEvents();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(events);
        }
    }
}
