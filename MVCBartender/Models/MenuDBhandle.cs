using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MVCBartender.Models
{
    public class MenuDBhandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["patronconn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW VOLUNTEER *********************
        public bool AddMenu(MenuModel mmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("InsertMenu", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CustomerDrink", mmodel.CustomerDrink);
            cmd.Parameters.AddWithValue("@CustomerDrinkPrice", mmodel.CustomerDrinkPrice);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        // ********** VIEW VOLUNTEER DETAILS ********************
        public List<MenuModel> GetMenu()
        {
            connection();
            List<MenuModel> menulist = new List<MenuModel>();

            SqlCommand cmd = new SqlCommand("GetMenu", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                menulist.Add(
                    new MenuModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        CustomerDrink = Convert.ToString(dr["CustomerDrink"]),
                        CustomerDrinkPrice = Convert.ToDecimal(dr["CustomerDrinkPrice"])
                    });
            }
            return menulist;
        }
    }
}