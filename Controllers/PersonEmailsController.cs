using apiPersonaNet.Models;
using apiPersonaNet.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace apiPersonaNet.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonEmailsController : ControllerBase
    {
        PersonEmailsServices services = new PersonEmailsServices();

        [HttpPost()]
        public List<PersonEmails> ListPersonEmails()
        {
            Console.WriteLine(JsonConvert.SerializeObject());
            return services.getPersonEmailsList();
        }

        [HttpPost("BusinessEntityID")]
        public List<String> ListEmails([FromBody] int BusinessEntityID)
        {
            Console.WriteLine(JsonConvert.SerializeObject(BusinessEntityID));
            return services.getEmailsList(BusinessEntityID);
        }

    }
}
