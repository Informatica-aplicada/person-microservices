using apiPersonaNet.Models;
using apiPersonaNet.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace apiPersonaNet.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IPerson services;

        public PersonController(IPerson services)
        {
            this.services = services;
        }
        //PersonServices services = new PersonServices();

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
            UserModel um = services.auth(auth);
            var json_auth = JsonConvert.SerializeObject(um);
            return json_auth;

        }

        [HttpPost("list")]
        public List<PersonInfo> generalInfo([FromBody] int[] ids)
        {
            return services.getAllThePeople();

        }

        [HttpPost("searchPersonById")]
        public PersonInfo searchPersonById([FromBody] int id)
        {
  
            return services.getPerson(id);

        }

        [HttpDelete("deleteP")]
        public bool deletePerson([FromBody] int id)
        {
            Console.WriteLine("SIppppp suppp");
           services.deletePerson(id);

           return true;
        }

        [HttpPost("addPerson")]
        public bool insertPerson([FromBody] PersonInfo person)
        {
            Console.WriteLine(person.FirstName);
           services.addPerson(person);

           return true;
        }

        [HttpPut("updatePerson")]
        public bool updatePerson([FromBody] PersonInfo person)
        {
            Console.WriteLine(person.FirstName);
           services.updatePerson(person);

           return true;
        }


        [HttpGet("/")]
        public string index()
        {
            string info = "Api person online";
            return info;
        }
    }
}
