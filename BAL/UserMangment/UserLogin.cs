using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussinessLogic.UserMangment
{

   public class UserLogin
    {
        DAL _DAL = new DAL();

        public DataTable user_login(string p_userid, string p_password)
        {
            string storedProcedureName = "sp_userlogin";
            object[] parameterValues = new object[] { p_userid, p_password };

            _DAL.OpenConnection();
         

          _DAL.LoadSpParameters(storedProcedureName, parameterValues);
           DataTable dt_data =  _DAL.GetDataTable();

            return dt_data;
        }
    }
}
