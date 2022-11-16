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

        [HttpGet]
        public List<PersonEmails> List()
        {
            return services.getPersonEmailsList();
        }

        [HttpGet("{BusinessEntityID}")]
        public List<Email> ListEmails([FromRoute] int BusinessEntityID)
        {
            return services.getEmailsList(BusinessEntityID);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Email data)
        {

            Console.WriteLine(data.businessEntityID);
            Console.WriteLine(data.emailAddressID);
            Console.WriteLine(data.emailAddress);
            Console.WriteLine(data.optionAction);

            bool response = services.Action(data);

            if (response)
            {
                return StatusCode(StatusCodes.Status200OK, new { result = "add" });
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { result = "ERROR!" });
            }
        }

        // [HttpPut]
        // public IActionResult Update([FromBody] PersonEmails data, int action)
        // {
        //     return StatusCode(StatusCodes.Status200OK, new { result = "update" });
        // }

        // [HttpDelete("{BusinessEntityID}")]
        // public IActionResult Delete([FromBody] int BusinessEntityID)
        // {
        //     return StatusCode(StatusCodes.Status200OK, new { result = "delete" });
        // }

    }
}