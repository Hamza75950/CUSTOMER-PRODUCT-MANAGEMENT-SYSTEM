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
                TempData["username"] = "Ahmed";
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                ViewBag.username = string.Format("Login Failed ", User_id);
                return View();
            }
        }


        //DataTable ExecuteProcedure(string sUserName, string sPassword)
        //{

        //    List<Company> studentlist = new List<Company>();
        //    SqlConnection con = new SqlConnection(DB.DBConn);
        //    con.Open();
        //    DataTable dtData = new DataTable();
        //    sqlCmd = new SqlCommand("sp_userlogin", con);
        //    sqlCmd.CommandType = CommandType.StoredProcedure;
        //    sqlCmd.Parameters.AddWithValue("@p_userid", sUserName);
        //    sqlCmd.Parameters.AddWithValue("@p_password", sPassword);
        //    SqlDataAdapter sqlSda = new SqlDataAdapter(sqlCmd);
        //    sqlSda.Fill(dtData);
        //    sqlCmd.ExecuteNonQuery();
        //    con.Close();

        //    return dtData;
        //}
    }
}