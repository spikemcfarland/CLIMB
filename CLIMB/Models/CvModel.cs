using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CLIMB.Models
{
    public class MaterialTypeModel
    {
        public int _MaterialType_key { get; set; }
        public string MaterialType { get; set; }
        public int IsActive { get; set; }
        public int IsDefault { get; set; }
        public int _Workgroup_key { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string ModifiedBy { get; set; }
        public string DateModified { get; set; }
        public IEnumerable<SelectListItem> MaterialTypeSelectList { get; set; }
    }
    public class EventTypeModel
    {
        public int _EventType_key { get; set; }
        public string EventType { get; set; }
        public int IsActive { get; set; }
        public int IsDefault { get; set; }
        public int _Workgroup_key { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string ModifiedBy { get; set; }
        public string DateModified { get; set; }
        public IEnumerable<SelectListItem> EventTypeSelectList { get; set; }
    }

}