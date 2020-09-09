using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class FamilyBusinessLayer
    {

        public IEnumerable<FamilyMember> FamilyMembers
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

                List<FamilyMember> familyMembers = new List<FamilyMember>();
                using (SqlConnection Con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DisplayFamily", Con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    Con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        FamilyMember familyMember = new FamilyMember();
                        familyMember.id = Convert.ToInt32(rdr["id"]);
                        familyMember.Name = rdr["Name"].ToString();
                        familyMember.Gender = rdr["Gender"].ToString();
                        familyMember.City = rdr["City"].ToString();
                        familyMember.Mobileno = rdr["Mobileno"].ToString();
                        familyMember.DateoOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);

                        familyMembers.Add(familyMember);
                    }
                }

                return familyMembers;
            }


        }

        public void AddFamilyMember(FamilyMember familymem)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spInsertFmly", Con);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter paraName = new SqlParameter();
                paraName.ParameterName = "@Name";
                paraName.Value = familymem.Name;
                cmd.Parameters.Add(paraName);

                SqlParameter paraGender = new SqlParameter();
                paraGender.ParameterName = "@Gender";
                paraGender.Value = familymem.Gender;
                cmd.Parameters.Add(paraGender);

                SqlParameter paraCity = new SqlParameter();
                paraCity.ParameterName = "@City";
                paraCity.Value = familymem.City;
                cmd.Parameters.Add(paraCity);

                SqlParameter paraMobileno = new SqlParameter();
                paraMobileno.ParameterName = "@Mobileno";
                paraMobileno.Value = familymem.Mobileno;
                cmd.Parameters.Add(paraMobileno);

                SqlParameter paraDob = new SqlParameter();
                paraDob.ParameterName = "@DateOfBirth";
                paraDob.Value = familymem.DateoOfBirth;
                cmd.Parameters.Add(paraDob);


                Con.Open();
                cmd.ExecuteNonQuery();


            }


        }

        public void EditFamily(FamilyMember Fme)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spEditFmly", Con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paraId = new SqlParameter();
                paraId.ParameterName = "@id";
                paraId.Value = Fme.id;
                cmd.Parameters.Add(paraId);


                SqlParameter paraName = new SqlParameter();
                paraName.ParameterName = "@Name";
                paraName.Value = Fme.Name;
                cmd.Parameters.Add(paraName);

                SqlParameter paraGender = new SqlParameter();
                paraGender.ParameterName = "@Gender";
                paraGender.Value = Fme.Gender;
                cmd.Parameters.Add(paraGender);

                SqlParameter paraCity = new SqlParameter();
                paraCity.ParameterName = "@City";
                paraCity.Value = Fme.City;
                cmd.Parameters.Add(paraCity);

                SqlParameter paraMobileno = new SqlParameter();
                paraMobileno.ParameterName = "@Mobileno";
                paraMobileno.Value = Fme.Mobileno;
                cmd.Parameters.Add(paraMobileno);

                SqlParameter paraDob = new SqlParameter();
                paraDob.ParameterName = "@DateOfBirth";
                paraDob.Value = Fme.DateoOfBirth;
                cmd.Parameters.Add(paraDob);


                Con.Open();
                cmd.ExecuteNonQuery();


            }

        }


        public void DeleteFamily(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

            using (SqlConnection Con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteFmly", Con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paraId = new SqlParameter();
                paraId.ParameterName = "@id";
                paraId.Value = id;
                cmd.Parameters.Add(paraId);

                Con.Open();
                cmd.ExecuteNonQuery();


            }

        }
    }
}
