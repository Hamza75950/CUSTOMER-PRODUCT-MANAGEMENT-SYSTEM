using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace Final_Project.Models
{
    public class GetProductDB
    {
        string cs = ConfigurationSettings.AppSettings["DBCon"].ToString();
        public List<GetProduct> getProducts()
        {
            List<GetProduct> ProductList = new List<GetProduct>();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("sp_GetProduct",con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                GetProduct pro = new GetProduct();
                pro.fb_ID = dr.GetValue(0).ToString();
                pro.fabric_name = dr.GetValue(1).ToString();
                ProductList.Add(pro);
            }

            con.Close();


            return ProductList;
        }

        public bool AddProduct(GetProduct prr)
        {
            
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd1 = new SqlCommand("sp_count_product", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@fb_ID", prr.fb_ID);
            con.Open();
            SqlDataReader dr = cmd1.ExecuteReader();
            dr.Read();
            int j = Convert.ToInt32(dr.GetValue(0).ToString());
            con.Close();
            if (j == 0)
            {
                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("sp_add_product", con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fb_ID", prr.fb_ID);
                cmd.Parameters.AddWithValue("@fabric_name", prr.fabric_name);
                con1.Open();
                int i = cmd.ExecuteNonQuery();

                con1.Close();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                

            }
            else
            {
                return false;
            }
            



           
        }


        public bool UpdateProduct(GetProduct prr)
        {

           
                SqlConnection con1 = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("sp_update_product", con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fb_ID", prr.fb_ID);
                cmd.Parameters.AddWithValue("@fabric_name", prr.fabric_name);
                con1.Open();
                int i = cmd.ExecuteNonQuery();

                con1.Close();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

        }



        public bool DeleteProduct(string id)
        {


            SqlConnection con1 = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("sp_delete_product", con1);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fb_ID", id);
            con1.Open();
            int i = cmd.ExecuteNonQuery();

            con1.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}