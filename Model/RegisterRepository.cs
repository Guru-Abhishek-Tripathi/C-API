using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRegister.Model
{
    public class RegisterRepository
    {
        private string connectionString;
        public RegisterRepository()
        {
            connectionString = "Server=103.21.58.5;Database=Abhishek_Test;Uid=Abhishek;Pwd=Passwordreg.123;";
        }
        //public IDbConnection Connnection
        //{
        //    get
        //    {
        //        return new SqlConnection(connectionString);
        //    }
        //}
        public int Add(Register reg)
        {
            int reader;
            string sQuery;
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                sQuery = $"INSERT INTO Register (Name, CompanyName, Address, Pincode, Phone, Email, GSTN, Pan, Aadhaar, ServiceNeeded, Details, Comments) VALUES("+reg.Name+","+reg.CompanyName+","+ reg.Address+","+ reg.Pincode +","+ reg.Phone+","+ reg.Email+","+reg.GSTN+","+ reg.Pan+","+ reg.Aadhaar+","+ reg.ServiceNeeded+","+ reg.Details+","+ reg.Comments+");";
                con.Open();
                var command = con.CreateCommand();
                command.CommandText = sQuery;
                reader = command.ExecuteNonQuery();
            }
            return reader;
        }

        public IEnumerable<Register> GetAll()
        {
            List<Register> reg = new List<Register>();
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from Register", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Register regg = new Register();
                    regg.Aadhaar = reader["Aadhaar"].ToString();
                    regg.GSTN = reader["GSTN"].ToString();
                    regg.Name = reader["Name"].ToString();
                    regg.Pan = reader["Pan"].ToString();
                    regg.Phone = reader["Phone"].ToString();
                    regg.Pincode = reader["Pincode"].ToString();
                    regg.ServiceNeeded = reader["ServiceNeeded"].ToString();
                    regg.Address = reader["Address"].ToString();
                    regg.Comments = reader["Comments"].ToString();
                    regg.CompanyName = reader["CompanyName"].ToString();
                    regg.Details = reader["Details"].ToString();
                    regg.Email = reader["Email"].ToString();

                    reg.Add(regg);
                }
            }
            return reg;
        }
    }
}
