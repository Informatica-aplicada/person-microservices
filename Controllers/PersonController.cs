using System.Data;
using System.Data.SqlClient;
using apiPersonaNet.Models;
using apiPersonaNet.Services;
using ApiPersonEmail.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace apiPersonaNet.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly string cadenaSQL;
        PersonServices services = new PersonServices();
        public PersonController(IConfiguration config){
            cadenaSQL = config.GetConnectionString("ConnectionString");
        }

        [HttpPost("list/{id}")]
       public ActionResult<TopPerson> GetEmail(int id)
        {
            return Listar().Single(x => x.BusinessEntityID == id);
        }

        [HttpGet]
        [Route("list")]
        public List<TopPerson> Listar()
        {
            List<TopPerson> lista = new List<TopPerson>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("person.sp_List_Person_Top100_FE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new TopPerson()
                            {
                                BusinessEntityID = Convert.ToInt32(rd["BusinessEntityID"]),
                                FirstName = rd["FirstName"].ToString(),
                                LastName = rd["LastName"].ToString()
                            });
                        }
                    }
                }
                return lista;
            }
            catch(Exception ex)
            {
                return lista;
            }
        }

        [HttpGet("{listId}")]

        public IActionResult Obtener(int listId)
        {
            List<EmailPerson> lista = new List<EmailPerson>();
            EmailPerson purchase = new EmailPerson();

            try
            {

                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("person.sp_get_email_fe", conexion);
                    cmd.Parameters.AddWithValue("id", listId);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new EmailPerson()
                            {
                                EmailAddress = rd["EmailAddress"].ToString()

                            });
                        }
                    }


                }

                purchase = lista.Where(item => item.BusinessEntityID == listId).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, response = lista });
            }
        }

        [HttpPost("ids")]
        public List<PersonInfo> ListByYear([FromBody] int[] ids)
        {
            Console.WriteLine("ingreso peticion");
            Console.WriteLine(JsonConvert.SerializeObject(ids));
            return services.getPersonList(ids);
        }

        [HttpPost("auth")]
        public string Auth([FromBody] LoginCredentials auth)
        {
            UserModel um =  services.auth(auth);
            var json_auth = JsonConvert.SerializeObject(um);
            return json_auth;
            
        }

        [HttpGet("/")]
        public string index()
        {
            string info = "Api person online";
            return info;
        }
    }
}
