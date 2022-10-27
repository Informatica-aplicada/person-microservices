using apiPersonaNet.Models;
using apiPersonaNet.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace apiPersonaNet.Controllers
{
    [Route("email")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        EmailServices services = new EmailServices();

        [HttpGet("{id}")]
        public List<EmailModel> GetListEmails([FromRoute] int id){
            return services.getEmails(id);
        }

        [HttpGet]
        public List<PersonInfo> GetListPerson()
        {
            return services.getPersons();
        }

        [HttpPost]
        public bool guardar([FromBody] List<EmailModel> emails) {


            return services.saveChangesEmail(emails);
        }
    }
}