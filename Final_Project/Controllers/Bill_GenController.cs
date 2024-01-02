using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Project.DataBase;
using System.Data.SqlClient;

namespace Final_Project.Controllers
{

    public class Bill_GenController : Controller
    {
        DAL _DAL = new DAL();

        public ActionResult index()
        {
            
            return View();
        }   
         
        public List<Bill_Payment> BindCompany()
        {
            DataTable dt = ExecuteProcedure("Comp","","",0,"","",0,"",0,"","");
            dt.Dispose();
            return CompBind(dt);
          
        }
        
        // GET: Bill_Gen/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bill_Gen/Create
        
        public ActionResult Create()
        {
            List<Bill_Payment> userList = BindCompany();
            return View(userList);
            
        }

        // POST: Bill_Gen/Create
        [HttpPost]
        public ActionResult Create(Bill_Payment Bill)
        {
            try
            {
                DataTable dtdata = null;
                List<Bill_Payment> userList = BindCompany();
                
                dtdata = ExecuteProcedure("Bill",Bill.Company_Name ,Bill.Del_Challan, Bill.weight, Bill.Colour, Bill.fabric_name, Bill.Fab_Rate, Bill.Rolls, Bill.Amount, Bill.Date);
                return View(userList);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Bill_Gen/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bill_Gen/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bill_Gen/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bill_Gen/Delete/5
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
        public List<Bill_Payment> Fill_table()
        {
            List<Bill_Payment> BillList = new List<Bill_Payment>();

            DataTable dtdata = null;
            dtdata = ExecuteProcedure("FetchData");

            foreach (DataRow dr in dtdata.Rows)
            {
                BillList.Add(
                    new Bill_Payment
                    {
                        Date = Convert.ToString(dr["Date"]),
                        Del_Challan = Convert.ToString(dr["Del_Challan"]),
                        Company_Name = Convert.ToString(dr["Company_Name"]),
                        Rolls = Convert.ToString(dr["Rolls"]),
                        weight = Convert.ToDouble(dr["weight"]),
                        Colour = Convert.ToString(dr["Colour"]),
                        fabric_name = Convert.ToString(dr["fabric_name"]),
                        Fab_Rate = Convert.ToDouble(dr["Fab_Rate"]),
                        Total_Amount = Convert.ToDouble(dr["Total_Amount"])


                    }); ;
            }
            return BillList;
        }
            private List<Bill_Payment> CompBind(DataTable dataTable)
        {
            List<Bill_Payment> Comp_list = new List<Bill_Payment>();

            foreach (DataRow row in dataTable.Rows)
            {
                Bill_Payment Comp = new Bill_Payment
                {
                    Company_Code = Convert.ToInt32(row["Company_Code"]),
                    Company_Name = row["Company_Name"].ToString()
                };

                Comp_list.Add(Comp);
            }
            dataTable.Dispose();
           
            return Comp_list;
        }

 

        DataTable ExecuteProcedure(string @ActionType, string @p_CompanyCode = "", string @p_challan_no = "", double @p_Weight = 0, string @p_Colour = "", string @p_fabric = "", double @p_rate = 0, string @p_roll = "",double @p_amount =0, string @p_d_date = "", string @p_totalamount = "")
        {
            string storedProcedureName = "sp_billPayment";
            object[] parameterValues = new object[] { @p_CompanyCode, @p_challan_no,@p_Weight,@p_Colour,@p_fabric,@p_rate,@p_roll,@p_amount,@p_d_date,@p_totalamount, Session["Users_id"].ToString(),"", @ActionType };
            _DAL.OpenConnection();
            _DAL.LoadSpParameters(storedProcedureName, parameterValues);
            DataTable dt_data = _DAL.GetDataTable();
            return dt_data;
        }

    }
}
