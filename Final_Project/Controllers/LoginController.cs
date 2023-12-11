using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.Security;
using Final_Project.DB;
using Final_Project.Models;

using DataAccessLayer;

namespace Final_Project.Controllers
{

    public class LoginController : Controller
    {
        DAL _DAL = new DAL();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string User_id, string Password)
        {
            DataTable dt_data = new DataTable();
            dt_data = user_login(User_id, Password);
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



        public DataTable user_login(string p_userid, string p_password)
        {
            string storedProcedureName = "sp_userlogin";
            object[] parameterValues = new object[] { p_userid, p_password };

            _DAL.OpenConnection();


            _DAL.LoadSpParameters(storedProcedureName, parameterValues);
            DataTable dt_data = _DAL.GetDataTable();

            return dt_data;

        }
    }
}