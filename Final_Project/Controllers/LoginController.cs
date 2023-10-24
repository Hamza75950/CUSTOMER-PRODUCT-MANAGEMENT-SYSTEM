using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Final_Project.Models;

namespace Final_Project.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //khttps://labpys.com/how-to-create-login-page-using-asp-net-core-mvc-c-with-database/

        //private readonly Login _loginUser;

        //public LoginController(Login loguser)
        //{
        //    _loginUser = loguser;
        //}

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string passcode)
         {
            var issuccess = username;  //_loginUser.AuthenticateUser(username, passcode);


            if (issuccess.Length != null)
            {
                ViewBag.username = string.Format("Successfully logged-in", username);

                TempData["username"] = "Ahmed";
                return RedirectToAction("Dashboard","Home");
            }
            else
            {
                ViewBag.username = string.Format("Login Failed ", username);
                return View();
            }
        }
    }
}