using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Huhu.Models;
namespace Huhu.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {

        AD25Team26Entities db = new AD25Team26Entities();
        // GET: Admin/Auth
        public ActionResult Login()
        {


            Session["password-incorrect"] = false;
            Session["user-not-found"] = false;

            return View();
        }
        [HttpPost]
        public ActionResult Login(string user,string password)
        {
            var taikhoan = db.Accounts.FirstOrDefault(u => u.Username.Equals(user));
            if (taikhoan != null)
            {
                if (taikhoan.Password.Equals(password))
                {
                    Session["user-fullname"] = taikhoan.Full_Name;
                    Session["user-id"] = taikhoan.ID;
                    Session["user-role"] = taikhoan.Role;
                    return RedirectToAction("Index", "Properties");
                }
                else
                {
                    Session["password-incorrect"] = true;
                    return View();
                }
            }
            Session["user-not-found"] = true;

            return View();
        }

        public ActionResult Logout()
        {
            Session["user-fullname"] = null;
            Session["user-id"] = null;
            return RedirectToAction("Login");
        }




    }
}