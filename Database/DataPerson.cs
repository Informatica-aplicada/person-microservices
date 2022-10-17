using apiPersonaNet.Models;
using apiPersonaNet.StoredProcedures;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace apiPersonaNet.Database
{
    public class DataPerson
    {
        public DataPerson() { }

        public List<PersonInfo> List(int[] year)
        {
            var json_ids = JsonConvert.SerializeObject(year);
            var list = new List<PersonInfo>();
            var conn = new DBConnection();
            using (var sqlconn = new SqlConnection(conn.getConnection()))
            {
                sqlconn.Open();
                Console.WriteLine("Coneccion a base de datos:" + sqlconn.State);
                SqlCommand cmd = new SqlCommand(Procedures.person_sales_list, sqlconn);
                cmd.Parameters.AddWithValue("id", json_ids);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var res = cmd.ExecuteReader())
                {
                    while (res.Read())
                    {
                        PersonInfo tmp = new PersonInfo();
                        tmp.BusinessEntityID = Convert.ToInt32(res["BusinessEntityID"]);
                        tmp.FirstName = res["FirstName"].ToString();
                        tmp.LastName = res["LastName"].ToString();

                        list.Add(tmp);
                    }
                }
            }
            return list;
        }

        //Lista de sales1


        //End sales1



        public List<PersonInfo> ListInformationG()
        {

            var list = new List<PersonInfo>();
            var conn = new DBConnection();
            using (var sqlconn = new SqlConnection(conn.getConnection()))
            {
                sqlconn.Open();
                Console.WriteLine("Conexion a base de datos:" + sqlconn.State);
                SqlCommand cmd = new SqlCommand(Procedures.sp_list_person, sqlconn);

                cmd.CommandType = CommandType.StoredProcedure;
                using (var res = cmd.ExecuteReader())
                {
                    while (res.Read())
                    {
                        Console.WriteLine("nea");
                        PersonInfo tmp = new PersonInfo();
                        tmp.BusinessEntityID = Convert.ToInt32(res["BusinessEntityID"]);
                        tmp.PersonType = res["PersonType"].ToString();
                        tmp.NameStyle = Convert.ToInt32(res["NameStyle"]);
                        tmp.Title = res["Title"].ToString();
                        tmp.FirstName = res["FirstName"].ToString();
                        tmp.LastName = res["LastName"].ToString();
                        tmp.MiddleName = res["MiddleName"].ToString();
                        tmp.Suffix = "" + res["Suffix"].ToString();
                        tmp.EmailPromotion = Convert.ToInt32(res["EmailPromotion"]);

                        list.Add(tmp);
                    }
                }
            }
            return list;
        }


        public PersonInfo GetPerson(int id)
        {

            PersonInfo tmp = new PersonInfo();
            var conn = new DBConnection();
            using (var sqlconn = new SqlConnection(conn.getConnection()))
            {
                sqlconn.Open();

                SqlCommand cmd = new SqlCommand(Procedures.showPerson, sqlconn);
                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var res = cmd.ExecuteReader())
                {
                    while (res.Read())
                    {

                        tmp.BusinessEntityID = Convert.ToInt32(res["BusinessEntityID"]);
                        tmp.PersonType = res["PersonType"].ToString();
                        tmp.NameStyle = Convert.ToInt32(res["NameStyle"]);
                        tmp.Title = res["Title"].ToString();
                        tmp.FirstName = res["FirstName"].ToString();
                        tmp.LastName = res["LastName"].ToString();
                        tmp.MiddleName = res["MiddleName"].ToString();
                        tmp.Suffix = "" + res["Suffix"].ToString();
                        tmp.EmailPromotion = Convert.ToInt32(res["EmailPromotion"]);

                    }
                }

            }

            return tmp;
        }

        public void deletePerson(int id)
        {
            var conn = new DBConnection();
            using (var sqlconn = new SqlConnection(conn.getConnection()))
            {
                sqlconn.Open();

                SqlCommand cmd = new SqlCommand(Procedures.delete_person, sqlconn);
                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();

            }

        }

        public void addPerson(PersonInfo objeto)
        {

            var conn = new DBConnection();
            using (var sqlconn = new SqlConnection(conn.getConnection()))
            {
                sqlconn.Open();

                SqlCommand cmd = new SqlCommand(Procedures.sp_insert_person, sqlconn);
                cmd.Parameters.AddWithValue("PersonType", objeto.PersonType);
                cmd.Parameters.AddWithValue("NameStyle", objeto.NameStyle);
                cmd.Parameters.AddWithValue("Title", objeto.Title);
                cmd.Parameters.AddWithValue("FirstName", objeto.FirstName);
                cmd.Parameters.AddWithValue("LastName", objeto.LastName);
                cmd.Parameters.AddWithValue("MiddleName", objeto.MiddleName);
                cmd.Parameters.AddWithValue("Suffix", objeto.Suffix);
                cmd.Parameters.AddWithValue("EmailPromotion", objeto.EmailPromotion);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();


            }

        }
        public void updatePerson(PersonInfo objeto)
        {

            var conn = new DBConnection();
            using (var sqlconn = new SqlConnection(conn.getConnection()))
            {
                sqlconn.Open();

                SqlCommand cmd = new SqlCommand(Procedures.sp_update_person, sqlconn);
                cmd.Parameters.AddWithValue("@BusinessEntityID", objeto.BusinessEntityID);
                cmd.Parameters.AddWithValue("PersonType", objeto.PersonType);
                cmd.Parameters.AddWithValue("NameStyle", objeto.NameStyle);
                cmd.Parameters.AddWithValue("Title", objeto.Title);
                cmd.Parameters.AddWithValue("FirstName", objeto.FirstName);
                cmd.Parameters.AddWithValue("LastName", objeto.LastName);
                cmd.Parameters.AddWithValue("MiddleName", objeto.MiddleName);
                cmd.Parameters.AddWithValue("Suffix", objeto.Suffix);
                cmd.Parameters.AddWithValue("EmailPromotion", objeto.EmailPromotion);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();


            }

        }


        public UserModel auth(LoginCredentials auth)
        {

            UserModel userTemp = new UserModel();
            var json_auth = JsonConvert.SerializeObject(auth);

            var conn = new DBConnection();

            using (var sqlconn = new SqlConnection(conn.getConnection()))
            {
                sqlconn.Open();
                Console.WriteLine(sqlconn.State);
                SqlCommand cmd = new SqlCommand(Procedures.auth, sqlconn);
                cmd.Parameters.AddWithValue("user_information", json_auth);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var res = cmd.ExecuteReader())
                {
                    while (res.Read())
                    {
                        userTemp.BusinessEntityID = Convert.ToInt32(res["BusinessEntityID"]);
                        userTemp.FirstName = res["FirstName"].ToString();
                        userTemp.LastName = res["LastName"].ToString();
                        userTemp.PasswordHash = res["PasswordHash"].ToString();
                        userTemp.EmailAddress = res["EmailAddress"].ToString();

                    }
                }
            }

            return userTemp;

        }
    }
}