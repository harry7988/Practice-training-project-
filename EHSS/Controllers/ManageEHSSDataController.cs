using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EHSS.Models;
using EHSS.ViewModel;
using System.Data.Entity.SqlServer;

namespace EHSS.Controllers
{
    public class ManageEHSSDataController : Controller
    {
        HESSLocalDBEntities db = new HESSLocalDBEntities();

        // GET: ManageEHSSData
        public ActionResult Index(FormCollection form)
        {
            var r = (from e in db.EHSSData select e).ToList();

            if (!string.IsNullOrEmpty(form["EHSSStatus"]))
            {
                r = r.Where(a => a.EHSSStatus == form["EHSSStatus"]).ToList();
            }

            if (!string.IsNullOrEmpty(form["ProductName"]))
            {
                r = r.Where(c => c.ProductName == form["ProductName"]).ToList();
            }

            if (!string.IsNullOrEmpty(form["ProductCode"]))
            {
                r = r.Where(c => c.ProductCode == form["ProductCode"]).ToList();
            }

            if (!string.IsNullOrEmpty(form["PhysicalState"]))
            {
                r = r.Where(c => c.PhysicalState == form["PhysicalState"]).ToList();
            }

            if (!string.IsNullOrEmpty(form["HazardType"]))
            {
                r = r.Where(c => c.HazardType.HazardTypeDesc == form["HazardType"]).ToList();
            }

            if (!string.IsNullOrEmpty(form["DOTDescription"]))
            {
                r = r.Where(c => c.DOTDescription == form["DOTDescription"]).ToList();
            }

            if (!string.IsNullOrEmpty(form["UNNumber"]))
            {
                r = r.Where(c => c.UNNumber == form["UNNumber"]).ToList();
            }

            if (!string.IsNullOrEmpty(form["Expirein"]))
            {
                r = r.Where(c => c.ExpiringInDays == int.Parse(form["Expirein"])).ToList();
            }

            EHSSDataManageListViewModel ehssListViewModel = new EHSSDataManageListViewModel();
            ehssListViewModel.EHSSDatas = new List<EHSSData>();
            ehssListViewModel.EHSSDatas = r;
            ehssListViewModel.HazardType = new List<SelectListItem>();
            ehssListViewModel.HazardType.Add(new SelectListItem { Text = "explosives", Value = "explosives" });
            ehssListViewModel.HazardType.Add(new SelectListItem { Text = "compressed", Value = "compressed" });
            ehssListViewModel.HazardType.Add(new SelectListItem { Text = "flammable", Value = "flammable" });
            ehssListViewModel.HazardType.Add(new SelectListItem { Text = "oxidizing", Value = "oxidizing" });
            ehssListViewModel.HazardType.Add(new SelectListItem { Text = "poisons", Value = "poisons" });
            ehssListViewModel.HazardType.Add(new SelectListItem { Text = "radioactive", Value = "radioactive" });
            ehssListViewModel.HazardType.Add(new SelectListItem { Text = "corrosives", Value = "corrosives" });
            ehssListViewModel.HazardType.Add(new SelectListItem { Text = "miscellaneous", Value = "miscellaneous" });
            ehssListViewModel.PhysicalState = new List<SelectListItem>();
            ehssListViewModel.PhysicalState.Add(new SelectListItem { Text = "Solid", Value = "Solid" });
            ehssListViewModel.PhysicalState.Add(new SelectListItem { Text = "Liquid", Value = "Liquid" });
            ehssListViewModel.PhysicalState.Add(new SelectListItem { Text = "Powder", Value = "Powder" });
            ehssListViewModel.Status = new List<SelectListItem>();
            ehssListViewModel.Status.Add(new SelectListItem { Text= "Approved" ,Value= "Approved" });
            ehssListViewModel.Status.Add(new SelectListItem { Text= "Draft" ,Value= "Draft" });
            return View(ehssListViewModel);

        }

        public ActionResult Creat()
        {
            EHSSDataManageListViewModel ehssListViewModel = new EHSSDataManageListViewModel();
            ehssListViewModel.HazardType = new List<SelectListItem>();
            ehssListViewModel.HazardType.Add(new SelectListItem { Text = "explosives", Value = "explosives" });
            ehssListViewModel.HazardType.Add(new SelectListItem { Text = "compressed", Value = "compressed" });
            ehssListViewModel.HazardType.Add(new SelectListItem { Text = "flammable", Value = "flammable" });
            ehssListViewModel.HazardType.Add(new SelectListItem { Text = "oxidizing", Value = "oxidizing" });
            ehssListViewModel.HazardType.Add(new SelectListItem { Text = "poisons", Value = "poisons" });
            ehssListViewModel.HazardType.Add(new SelectListItem { Text = "radioactive", Value = "radioactive" });
            ehssListViewModel.HazardType.Add(new SelectListItem { Text = "corrosives", Value = "corrosives" });
            ehssListViewModel.HazardType.Add(new SelectListItem { Text = "miscellaneous", Value = "miscellaneous" });
            ehssListViewModel.PhysicalState = new List<SelectListItem>();
            ehssListViewModel.PhysicalState.Add(new SelectListItem { Text = "Solid", Value = "Solid" });
            ehssListViewModel.PhysicalState.Add(new SelectListItem { Text = "Liquid", Value = "Liquid" });
            ehssListViewModel.PhysicalState.Add(new SelectListItem { Text = "Powder", Value = "Powder" });
            ehssListViewModel.Status = new List<SelectListItem>();
            ehssListViewModel.Status.Add(new SelectListItem { Text = "Approved", Value = "Approved" });
            ehssListViewModel.Status.Add(new SelectListItem { Text = "Draft", Value = "Draft" });
            return View(ehssListViewModel);
        }

        [HttpPost]
        public ActionResult DoCreat(EHSSData data)
        {
            if (ModelState.IsValid)
            {
                data.EHSSDataID = ((from id in db.EHSSData select id).Count() + 1).ToString();
                data.CreateDate = DateTime.Now;
                data.AuthorID = (from a in db.EHSSUser where a.LoginName == User.Identity.Name select a.EHSSUserID).FirstOrDefault();
                data.EHSSStatus = "Draft";

                db.EHSSData.Add(data);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                EHSSDataManageListViewModel ehssListViewModel = new EHSSDataManageListViewModel();
                ehssListViewModel.HazardType = new List<SelectListItem>();
                ehssListViewModel.HazardType.Add(new SelectListItem { Text = "explosives", Value = "explosives" });
                ehssListViewModel.HazardType.Add(new SelectListItem { Text = "compressed", Value = "compressed" });
                ehssListViewModel.HazardType.Add(new SelectListItem { Text = "flammable", Value = "flammable" });
                ehssListViewModel.HazardType.Add(new SelectListItem { Text = "oxidizing", Value = "oxidizing" });
                ehssListViewModel.HazardType.Add(new SelectListItem { Text = "poisons", Value = "poisons" });
                ehssListViewModel.HazardType.Add(new SelectListItem { Text = "radioactive", Value = "radioactive" });
                ehssListViewModel.HazardType.Add(new SelectListItem { Text = "corrosives", Value = "corrosives" });
                ehssListViewModel.HazardType.Add(new SelectListItem { Text = "miscellaneous", Value = "miscellaneous" });
                ehssListViewModel.PhysicalState = new List<SelectListItem>();
                ehssListViewModel.PhysicalState.Add(new SelectListItem { Text = "Solid", Value = "Solid" });
                ehssListViewModel.PhysicalState.Add(new SelectListItem { Text = "Liquid", Value = "Liquid" });
                ehssListViewModel.PhysicalState.Add(new SelectListItem { Text = "Powder", Value = "Powder" });
                ehssListViewModel.Status = new List<SelectListItem>();
                ehssListViewModel.Status.Add(new SelectListItem { Text = "Approved", Value = "Approved" });
                ehssListViewModel.Status.Add(new SelectListItem { Text = "Draft", Value = "Draft" });
                
                return View("Creat", ehssListViewModel);
            }
        }

        
    }
}