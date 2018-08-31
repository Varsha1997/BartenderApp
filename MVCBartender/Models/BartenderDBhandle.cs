using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MVCBartender.Models
{
    public class BartenderDBhandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["patronconn"].ToString();
            con = new SqlConnection(constring);
        }


        // ********** VIEW VOLUNTEER DETAILS ********************
        public List<BartenderModel> GetBartender()
        {
            connection();
            List<BartenderModel> bartenderlist = new List<BartenderModel>();

            SqlCommand cmd = new SqlCommand("BartenderView", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                bartenderlist.Add(
                    new BartenderModel
                    {
                        CustomerName = Convert.ToString(dr["CustomerName"]),
                        CustomerDrinkName = Convert.ToString(dr["CustomerDrinkName"]),
                        CustomerDrinkPrice = Convert.ToDecimal(dr["CustomerDrinkPrice"])
                    });
            }
            return bartenderlist;
        }

    }
}