using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MVCBartender.Models
{
    public class PatronDBhandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["PatronConn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW VOLUNTEER *********************
        public bool AddPatron(PatronModel pmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("InsertPatron", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CustomerName", pmodel.CustomerName);
            cmd.Parameters.AddWithValue("@CustomerDrinkName", pmodel.CustomerDrinkName);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW VOLUNTEER DETAILS ********************
        public List<PatronModel> GetPatron()
        {
            connection();
            List<PatronModel> patronlist = new List<PatronModel>();

            SqlCommand cmd = new SqlCommand("GetPatron", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                patronlist.Add(
                    new PatronModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        CustomerName = Convert.ToString(dr["CustomerName"]),
                        CustomerDrinkName = Convert.ToString(dr["CustomerDrinkName"])
                    });
            }
            return patronlist;
        }

        // ***************** UPDATE STUDENT DETAILS *********************
        public bool UpdatePatronDetails(PatronModel pmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdatePatronDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PId", pmodel.Id);
            cmd.Parameters.AddWithValue("@CustomerName", pmodel.CustomerName);
            cmd.Parameters.AddWithValue("@CustomerDrinkName", pmodel.CustomerDrinkName);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE STUDENT DETAILS *******************
        public bool DeletePatron(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeletePatron", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PId", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}