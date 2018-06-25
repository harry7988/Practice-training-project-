using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EHSS.Models;

namespace EHSS.ViewModel
{
    public class EHSSDataManageListViewModel
    {
        public List<EHSSData> EHSSDatas { get; set; }
        public List<SelectListItem> Status { get; set; }
        public List<SelectListItem> PhysicalState { get; set; }
        public List<SelectListItem> HazardType { get; set; }

    }
}