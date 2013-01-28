using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CLIMB.Models
{
    public class MaterialModel
    {
        [Display(Name = "Key")]
        public int _Material_key { get; set; }
        [Display(Name = "Type")]
        public int _MaterialType_key { get; set; }
        [Display(Name = "ID")]
        public string MaterialID { get; set; }
        [Display(Name = "Name")]
        public string MaterialName { get; set; }
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
        public IEnumerable<SelectListItem> MaterialTypeSelectList { get; set; }
    }

    
}