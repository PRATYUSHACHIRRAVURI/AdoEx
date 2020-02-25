using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AdoEx.Models
{
    public class User
    {
        public int ID{ set; get; }
        public string Name{ set; get; }
        public string Email{ set; get; }

        SqlConnection con = new SqlConnection("Data Source=EPINHYDW014D;Integrated Security=true;Initial Catalog=Student");
        SqlCommand cmd = new SqlCommand();

        //Creating function to insert details
        public string InsertRegDetails(User obj)
        {
            cmd.CommandText = "Insert into UserTable(Name,Email) values('" + obj.Name + "','" + obj.Email + "')";
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "Success";


        }
        public List<User> ViewRegistrations()
        {
            cmd.CommandText = "Select * from UserTable";
            cmd.Connection = con;
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            List<User> ht = new List<User>();

            while (sdr.Read())
            {
                ht.Add(new User { ID = Convert.ToInt32(sdr["ID"]), Name = sdr["Name"].ToString(), Email = sdr["Email"].ToString() });
            }
            return ht;
        }
        public void ViewRegistrationsUsingDataSet()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM UserTable", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "User1");
            con.Close();
            foreach (DataRow row in ds.Tables[0].Rows)
            { Debug.WriteLine(string.Format("Name: {0} , Email: {1}", row["Name"], row["Email"])); }

        }
    }
}
       
    