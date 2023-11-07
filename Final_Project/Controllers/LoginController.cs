using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Final_Project.DB;
using Final_Project.Models;

namespace Final_Project.Controllers
{
    public class LoginController : Controller
    {
        DataBase DB = new DataBase();
        SqlCommand sqlCmd = null;
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string passcode)
         {
            var issuccess = ExecuteProcedure(username, passcode);


            if (issuccess != null)
            {
                ViewBag.username = string.Format("Successfully logged-in", username);
                FormsAuthentication.SetAuthCookie(username, false);
                TempData["username"] = "Ahmed";
                return RedirectToAction("Dashboard","Home");
            }
            else
            {
                ViewBag.username = string.Format("Login Failed ", username);
                return View();
            }
        }


        DataTable ExecuteProcedure(string sUserName, string sPassword)
        {

            List<Company> studentlist = new List<Company>();
            SqlConnection con = new SqlConnection(DB.DBConn);
            con.Open();
            DataTable dtData = new DataTable();
            sqlCmd = new SqlCommand("sp_userlogin", con);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@p_userid", sUserName);
            sqlCmd.Parameters.AddWithValue("@p_password", sPassword);
            SqlDataAdapter sqlSda = new SqlDataAdapter(sqlCmd);
            sqlSda.Fill(dtData);
            sqlCmd.ExecuteNonQuery();
            con.Close();

            return dtData;
        }
    }
}