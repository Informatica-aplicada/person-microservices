using apiPersonaNet.Models;
using apiPersonaNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiPersonaNet.Controllers
{

    [Route("/emails")]
    [ApiController]
    public class PersonEmailsController : ControllerBase
    {
        PersonEmailsServices services = new PersonEmailsServices();

        [HttpGet()]
        public List<PersonEmails> List(){
            return services.getPersonEmailsList();
        }

        [HttpGet("{BusinessEntityID}")]
        public List<Email> ListEmails([FromBody] int BusinessEntityID){
            return services.getEmailsList(BusinessEntityID);
        }

        [HttpPost]
        public IActionResult Add([FromBody] PersonEmails data, int action){
             return StatusCode(StatusCodes.Status200OK, new { result = "add" });
        }

        [HttpPost]
        public IActionResult Update([FromBody] PersonEmails data, int action){
             return StatusCode(StatusCodes.Status200OK, new { result = "update" });
        }

        [HttpDelete("{BusinessEntityID}")]
        public IActionResult Delete([FromBody] int BusinessEntityID){
            return StatusCode(StatusCodes.Status200OK, new { result = "delete" });
        }

    }
}