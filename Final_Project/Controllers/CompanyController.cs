
using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Project.DataBase;
using System.Net;

namespace Final_Project.Controllers
{
    public class CompanyController : Controller
    {
        DAL _DAL = new DAL();
        SqlCommand sqlCmd = null;
        // GET: Copany
        public ActionResult Setup_Company()
        {
            return View(Companies());
        }

        // GET: Copany/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Copany/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Copany/Create
        [HttpPost]
        public ActionResult Create(Company CMP)
            {
           
            try
            {
                DataTable dtdata = null;
                dtdata = ExecuteProcedure("Submit",CMP.Company_Code, CMP.Company_Name, CMP.Company_Contact, CMP.Company_Address);
                return RedirectToAction("Setup_Company");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Copany/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(Companies().Find(smodel => smodel.Company_Code == id)) ;
        }

        // POST: Copany/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            
                return View();
            
        }

        // GET: Copany/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Copany/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }




        public List<Company> Companies()
        {
            List<Company> CompanyList = new List<Company>();

            DataTable dtdata = null;
            dtdata = ExecuteProcedure("FetchData", "", "", "");

            foreach (DataRow dr in dtdata.Rows)
            {
                CompanyList.Add(
                    new Company
                    {
                        Company_Code = Convert.ToString(dr["Company_Code"]),
                        Company_Name = Convert.ToString(dr["Company_Name"]),
                        Company_Contact = Convert.ToString(dr["mobile_no"]),
                        Company_Address = Convert.ToString(dr["Addresss"])
                    });
            }
            return CompanyList;

        }
        DataTable ExecuteProcedure(string sAction, string sCompanyCode, string sComapnyName = "", string sCellNum = "", string sAddres = "")
        {
            string storedProcedureName = "sp_Company";
            object[] parameterValues = new object[] {  sCompanyCode,sComapnyName ,sCellNum , sAddres, Session["Users_id"].ToString(), sAction };

            _DAL.OpenConnection();


            _DAL.LoadSpParameters(storedProcedureName, parameterValues);
            DataTable dt_data = _DAL.GetDataTable();

            return dt_data;
        }





    }
}
