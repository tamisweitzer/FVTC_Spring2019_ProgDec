using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSS.ProgDec.BL;
using TSS.ProgDec.MVCUI.ViewModels;

namespace TSS.ProgDec.MVCUI.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Create(string returnurl)
        {
            ViewBag.ReturnUrl = returnurl;
            return View();
        }

        public ActionResult Logout ()
        {
            HttpContext.Session["user"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user, string returnurl)
        {
            ViewResult result = View(user);
            try
            {
                ViewBag.ReturnUrl = returnurl;

                if (user.Login())
                {
                    HttpContext.Session["user"] = user;
                    //return RedirectToAction("Index", "ProgDec");
                    return Redirect(returnurl);
                }

                ViewBag.Message = "Sorry. Login failed";
                return result;
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(user);                
            }
        }
    }
}