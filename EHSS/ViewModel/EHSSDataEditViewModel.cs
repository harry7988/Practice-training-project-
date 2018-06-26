using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EHSS.Models;

namespace EHSS.ViewModel
{
    public class EHSSDataEditViewModel
    {
        public List<SelectListItem> PhysicalState { get; set; }
        public List<SelectListItem> HazardType { get; set; }
        public List<SelectListItem> Status { get; set; }
        public EHSSData EHSSDataItem { get; set; }
    }
}