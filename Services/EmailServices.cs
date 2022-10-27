using apiPersonaNet.Database;
using apiPersonaNet.Models;

namespace apiPersonaNet.Services
{
    public class EmailServices
    {

        DataPerson dp = new DataPerson();

        public List<EmailModel>  getEmails(int id){
            return dp.getEmails(id);
        }

        public List<PersonInfo>  getPersons(){
            return dp.getPerson();
        }

        public bool  saveChangesEmail(List<EmailModel> emails)
        {
            return dp.saveChanges(emails);
        }
    }
}