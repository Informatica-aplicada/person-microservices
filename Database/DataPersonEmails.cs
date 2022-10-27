using apiPersonaNet.Models;
using apiPersonaNet.StoredProcedures;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

using System.Runtime.InteropServices.ComTypes;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

using Microsoft.AspNetCore.Cors;

namespace apiPersonaNet.Database
{
    public class DataPersonEmails
    {
        public DataPersonEmails() { }

        public List<PersonEmails> List(){
            var list = new List<PersonEmails>();
            var conn = new DBConnection();
            using (var sqlconn = new SqlConnection(conn.getConnection())){
                sqlconn.Open();
                Console.WriteLine("Conection to DB:" + sqlconn.State);
                SqlCommand cmd = new SqlCommand(ProceduresPersonEmails.spa_findPerson, sqlconn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var res = cmd.ExecuteReader())
                {
                    while (res.Read())
                    {
                        PersonEmails tmp = new PersonEmails();
                        tmp.BusinessEntityID = Convert.ToInt32(res["BusinessEntityID"]);
                        tmp.Name = res["Name"].ToString();

                        list.Add(tmp);
                    }
                }
            }
            return list;
        }

        public List<Email> getEmails(int BusinessEntityID){
            var list = new List<Email>();
            var conn = new DBConnection();
            using (var sqlconn = new SqlConnection(conn.getConnection())){
                sqlconn.Open();
                Console.WriteLine("Conection to DB:" + sqlconn.State);
                SqlCommand cmd = new SqlCommand(ProceduresPersonEmails.spa_getEmailPerson, sqlconn);
                cmd.Parameters.AddWithValue("@BusinessEntityID", BusinessEntityID);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var res = cmd.ExecuteReader())
                {
                    while (res.Read())
                    {
                        Email emails = new Email();
                        tmp.EmailAddressID = Convert.ToInt32(res["EmailAddressID"]);
                        tmp.EmailAddress = res["EmailAddress"].ToString;

                        list.Add(emails);
                    }
                }
            }
            return list;
        }

        public bool Add (Email email, int BusinessEntityID, int Action){

             var conn = new DBConnection();
                using (var sqlconn = new SqlConnection(conn.getConnection()))
                {
                    sqlconn.Open();
                    var cmd = new SqlCommand(ProceduresPersonEmails.spa_actionsEmails, sqlconn);
                    cmd.Parameters.AddWithValue("@BusinessEntityID", data.BusinessEntityID);
                    cmd.Parameters.AddWithValue("@EmailAddressID", data.EmailAddressID);
                    cmd.Parameters.AddWithValue("@EmailAddress", data.EmailAddress);
                    cmd.Parameters.AddWithValue("@OptionAction", data.@OptionAction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
            return true;

        }

        public bool Update (Email email, int BusinessEntityID, int Action){

             var conn = new DBConnection();
                using (var sqlconn = new SqlConnection(conn.getConnection()))
                {
                    sqlconn.Open();
                    var cmd = new SqlCommand(ProceduresPersonEmails.spa_actionsEmails, sqlconn);
                    cmd.Parameters.AddWithValue("@BusinessEntityID", data.BusinessEntityID);
                    cmd.Parameters.AddWithValue("@EmailAddressID", data.EmailAddressID);
                    cmd.Parameters.AddWithValue("@EmailAddress", data.EmailAddress);
                    cmd.Parameters.AddWithValue("@OptionAction", data.@OptionAction);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
            return true;

        }

        public bool Delete(Email email, int BusinessEntityID, int Action)
        {
            var conn = new DBConnection();
            using (var sqlconn = new SqlConnection(conn.getConnection()))
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand(ProceduresPersonEmails.spa_actionsEmails, sqlconn);
                cmd.Parameters.AddWithValue("@BusinessEntityID", BusinessEntityID);
                cmd.Parameters.AddWithValue("@EmailAddressID", data.EmailAddressID);
                cmd.Parameters.AddWithValue("@EmailAddress", data.EmailAddress);
                cmd.Parameters.AddWithValue("@OptionAction", data.@OptionAction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            return true;
        }

    }
}
