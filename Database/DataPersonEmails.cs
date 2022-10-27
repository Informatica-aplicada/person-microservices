using apiPersonaNet.Models;
using apiPersonaNet.StoredProcedures;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

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
        public List<String> List(int BusinessEntityID){
            var list = new List<String>();
            var conn = new DBConnection();
            using (var sqlconn = new SqlConnection(conn.getConnection())){
                sqlconn.Open();
                Console.WriteLine("Conection to DB:" + sqlconn.State);
                SqlCommand cmd = new SqlCommand(ProceduresPersonEmails.spa_getEmailPerson, sqlconn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var res = cmd.ExecuteReader())
                {
                    while (res.Read())
                    {
                        String emails = new String();
                        emails = Convert.ToInt32(res["EmailAddress"]);

                        list.Add(emails);
                    }
                }
            }
            return list;
        }

        public void actionsEmails (int businessEntityID, int emailAddressID, 
        string emailAddress, int optionAction){


        }

    }
}