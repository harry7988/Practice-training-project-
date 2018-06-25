using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EHSS.Models;
using System.Web.Security;

namespace EHSS.Controllers
{
    public class UserController : Controller
    {
        HESSLocalDBEntities db = new HESSLocalDBEntities();
        // GET: User
        /// <summary>
        /// 返回用户中心页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 展示登陆页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 验证登陆
        /// </summary>
        /// <param name="user"></param>
        /// <param name="btnLogin"></param>
        /// <returns></returns>
        public ActionResult DoLogin(EHSSUser user,string btnLogin)
        {
            if (ModelState.IsValid)
            {
                var ul = (from a in db.EHSSUser
                         where (a.LoginName==user.LoginName) && (a.LoginPassword == user.LoginPassword)
                         select a).Count();
                Response.Write(ul);
                if (ul>0)
                {
                    FormsAuthentication.SetAuthCookie(user.LoginName, false);
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginErrr2", "User match more then one");
                    return View("Login");
                }
            }
            else
            {
                ModelState.AddModelError("LoginErrr1", "Wrong username or password");
                return View("Login");
            }
        }
        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}