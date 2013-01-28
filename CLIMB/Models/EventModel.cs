using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CLIMB.Models
{
    public class EventModel
    {
        [Display(Name = "Key")]
        public int _Event_key { get; set; }
        [Display(Name = "ParentKey")]
        public int _ParentEvent_key { get; set; }
        [Display(Name = "TypeKey")]
        public int _EventType_key { get; set; }
        [Display(Name = "EventID")]
        public string EventID { get; set; }
        [Display(Name = "EventName")]
        public string EventName { get; set; }
        [Display(Name = "Projected Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime ProjectedDate { get; set; }
        [UIHint("DateTime")]
        [Display(Name = "Actual Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime ActualDate { get; set; }
        [Display(Name = "Workgroup Key")]
        public int _Workgroup_key { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Date Created")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }
        [Display(Name = "Date Modified")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateModified { get; set; }
        public IEnumerable<SelectListItem> EventTypeSelectList { get; set; }
    }
}