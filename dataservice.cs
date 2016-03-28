using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class dataservice
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        public void InsertNewUser(pservice P)
        {
            cmd = new SqlCommand("InsertNewUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fname", P.FirstName);
            cmd.Parameters.AddWithValue("@Lname", P.LastName);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UadateUser(pservice P)
        {
            cmd = new SqlCommand("UadateUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UID", P.UserID);
            cmd.Parameters.AddWithValue("@Fname", P.FirstName);
            cmd.Parameters.AddWithValue("@Lname", P.LastName);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteUser(pservice P)
        {
            cmd = new SqlCommand("DeleteUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UID", P.UserID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable GEtAllUSers()
        {
            da = new SqlDataAdapter("GEtAllUSers",con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}