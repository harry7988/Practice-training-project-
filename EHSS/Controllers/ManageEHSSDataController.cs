using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EHSS.Models;
using EHSS.ViewModel;
using System.Data.Entity.SqlServer;
using System.Data.Entity;

namespace EHSS.Controllers
{
    [Authorize]
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

        public ActionResult Edit(string EHSSDataID)
        {
            var obj = from a in db.EHSSData
                      where a.EHSSDataID == EHSSDataID
                      select a;

            EHSSDataEditViewModel eHSSDataEditViewModel = new EHSSDataEditViewModel();
            eHSSDataEditViewModel.EHSSDataItem = obj.FirstOrDefault();
            eHSSDataEditViewModel.HazardType = new List<SelectListItem>();
            eHSSDataEditViewModel.HazardType = new List<SelectListItem>();
            eHSSDataEditViewModel.HazardType.Add(new SelectListItem { Text = "explosives", Value = "explosives" });
            eHSSDataEditViewModel.HazardType.Add(new SelectListItem { Text = "compressed", Value = "compressed" });
            eHSSDataEditViewModel.HazardType.Add(new SelectListItem { Text = "flammable", Value = "flammable" });
            eHSSDataEditViewModel.HazardType.Add(new SelectListItem { Text = "oxidizing", Value = "oxidizing" });
            eHSSDataEditViewModel.HazardType.Add(new SelectListItem { Text = "poisons", Value = "poisons" });
            eHSSDataEditViewModel.HazardType.Add(new SelectListItem { Text = "radioactive", Value = "radioactive" });
            eHSSDataEditViewModel.HazardType.Add(new SelectListItem { Text = "corrosives", Value = "corrosives" });
            eHSSDataEditViewModel.HazardType.Add(new SelectListItem { Text = "miscellaneous", Value = "miscellaneous" });
            eHSSDataEditViewModel.PhysicalState = new List<SelectListItem>();
            eHSSDataEditViewModel.PhysicalState.Add(new SelectListItem { Text = "Solid", Value = "Solid" });
            eHSSDataEditViewModel.PhysicalState.Add(new SelectListItem { Text = "Liquid", Value = "Liquid" });
            eHSSDataEditViewModel.PhysicalState.Add(new SelectListItem { Text = "Powder", Value = "Powder" });
            eHSSDataEditViewModel.Status = new List<SelectListItem>();
            eHSSDataEditViewModel.Status.Add(new SelectListItem { Text = "Approved", Value = "Approved" });
            eHSSDataEditViewModel.Status.Add(new SelectListItem { Text = "Draft", Value = "Draft" });
            return View(eHSSDataEditViewModel);
        }
        
        /// <summary>
        /// 编辑数据（未添加数据验证）
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DoEdit(EHSSDataEditViewModel data)
        {
            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                EHSSData EHSSDataitem = db.EHSSData.Find(data.EHSSDataItem.EHSSDataID);
                EHSSDataitem.DOTDescription = data.EHSSDataItem.DOTDescription;
                EHSSDataitem.ExpiringInDays = data.EHSSDataItem.ExpiringInDays;
                EHSSDataitem.HazardTypeCode = data.EHSSDataItem.HazardTypeCode;
                EHSSDataitem.PhysicalState = data.EHSSDataItem.PhysicalState;
                EHSSDataitem.ProductCode = data.EHSSDataItem.ProductCode;
                EHSSDataitem.ProductName = data.EHSSDataItem.ProductName;
                EHSSDataitem.UNNumber = data.EHSSDataItem.UNNumber;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            //var errors2 = ModelState.Values.SelectMany(v => v.Errors);
            ModelState.AddModelError("e1", "修改失败");
            return RedirectToAction("Edit");
        }

        /// <summary>
        /// 显示批准界面
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult Approve(FormCollection form)
        {
            var r = db.EHSSData.Where(a => a.EHSSStatus == "Draft").ToList();

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
            ehssListViewModel.Status.Add(new SelectListItem { Text = "Approved", Value = "Approved" });
            ehssListViewModel.Status.Add(new SelectListItem { Text = "Draft", Value = "Draft" });
            return View(ehssListViewModel);
        }

        /// <summary>
        /// 设置属性为批准
        /// </summary>
        /// <param name="EHSSDataID"></param>
        /// <returns></returns>
        public ActionResult DoApprove(string EHSSDataID)
        {
            var obj = db.EHSSData.Where(a => a.EHSSDataID == EHSSDataID).FirstOrDefault();
            obj.EHSSStatus = "Approved";
            db.SaveChanges();
            return RedirectToAction("Approve", "ManageEHSSData");
        }


    }
}