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
                        PersonEmails person = new PersonEmails();
                        person.BusinessEntityID = Convert.ToInt32(res["BusinessEntityID"]);
                        person.Name = res["Name"].ToString();

                        list.Add(person);
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
                        emails.EmailAddressID = Convert.ToInt32(res["EmailAddressID"]);
                        emails.EmailAddress = res["EmailAddress"].ToString();

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
                    cmd.Parameters.AddWithValue("@BusinessEntityID", BusinessEntityID);
                    cmd.Parameters.AddWithValue("@EmailAddressID", email.EmailAddressID);
                    cmd.Parameters.AddWithValue("@EmailAddress", email.EmailAddress);
                    cmd.Parameters.AddWithValue("@OptionAction", Action);
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
                    cmd.Parameters.AddWithValue("@BusinessEntityID", BusinessEntityID);
                    cmd.Parameters.AddWithValue("@EmailAddressID", email.EmailAddressID);
                    cmd.Parameters.AddWithValue("@EmailAddress", email.EmailAddress);
                    cmd.Parameters.AddWithValue("@OptionAction", Action);
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
                cmd.Parameters.AddWithValue("@EmailAddressID", email.EmailAddressID);
                cmd.Parameters.AddWithValue("@EmailAddress", email.EmailAddress);
                cmd.Parameters.AddWithValue("@OptionAction", Action);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            return true;
        }

    }
}
