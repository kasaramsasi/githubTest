using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class RegisterBusinessLayer
    {

        public void AddRegistredUser(Register register)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["csr"].ConnectionString;

            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spInsertRegistredUser", Con);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter paraName = new SqlParameter();
                paraName.ParameterName = "@Username";
                paraName.Value = register.Username;
                cmd.Parameters.Add(paraName);

                SqlParameter paraPassword = new SqlParameter();
                paraPassword.ParameterName = "@Password";
                paraPassword.Value = register.Password;
                cmd.Parameters.Add(paraPassword);
                Con.Open();
                cmd.ExecuteNonQuery();

            }
        }
    }
}
