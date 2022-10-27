using apiPersonaNet.Database;
using apiPersonaNet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace apiPersonaNet.Services
{
    public class PersonServices:IPerson

    {
        private readonly string cadenaSQL;
        public PersonServices(IConfiguration config){
            cadenaSQL = config.GetConnectionString("ConnectionString");
        }

        DataPerson dp = new DataPerson();

        public List<PersonInfo>  getPersonList(int[] ids){
            return dp.List(ids);
        }

        public UserModel auth(LoginCredentials auth){

            return dp.auth(auth);
        }

        public void saveEmail([FromBody] EmailPerson person)
        {
            using (var conexion = new SqlConnection(cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("sp_Save_Email_PersonFe", conexion);
                cmd.Parameters.AddWithValue("BusinessEntityID", person.businessEntityID);
                cmd.Parameters.AddWithValue("EmailAddressID", person.emailAddressID);
                cmd.Parameters.AddWithValue("EmailAddress", person.emailAddress);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
        }

        public void editEmail([FromBody] EmailPerson person)
        {
            using (var conexion = new SqlConnection(cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("person.sp_Edit_Email_PersonFe", conexion);
                
                cmd.Parameters.AddWithValue("BusinessEntityID", person.businessEntityID==0? DBNull.Value : person.businessEntityID);
                cmd.Parameters.AddWithValue("EmailAddressID", person.emailAddressID == 0 ? DBNull.Value : person.emailAddressID);
                cmd.Parameters.AddWithValue("EmailAddress", person.emailAddress is null ? DBNull.Value : person.emailAddress);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
        }

        public void deleteEmail(int id)
        {
            using(var conexion = new SqlConnection(cadenaSQL)){
                conexion.Open();
                var cmd = new SqlCommand("person.sp_Delete_Email_PersonFe", conexion);

                cmd.Parameters.AddWithValue("EmailAddressID", id);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
        }
    }
}