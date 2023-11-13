using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.Security;
using Final_Project.DB;
using Final_Project.Models;
using BussinessLogic.UserMangment;

namespace Final_Project.Controllers
{

    public class LoginController : Controller
    {
        UserLogin obj_Login = new UserLogin();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string User_id, string Password)
        {
            DataTable dt_data = new DataTable();
            dt_data = obj_Login.user_login(User_id, Password);
            if (dt_data.Rows.Count > 0)
            {
                ViewBag.username = string.Format("Successfully logged-in", User_id);
                FormsAuthentication.SetAuthCookie(User_id, false);
                Session["Users_id"] = User_id;
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                ViewBag.username = string.Format("Login Failed ", User_id);
                return View();
            }
        }
      
    }
}