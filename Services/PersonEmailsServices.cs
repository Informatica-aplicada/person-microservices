using apiPersonaNet.Database;
using apiPersonaNet.Models;

namespace apiPersonaNet.Services
{
    public class PersonEmailsServices:IPersonEmails
    {
        public PersonEmailsServices(){}

        DataPersonEmails dp = new DataPersonEmails();

        public List<PersonEmails> getPersonEmailsList(){
            return dp.List();
        }

        public List<String> getEmailsList(int BusinessEntityID){
            return dp.List(BusinessEntityID);
        }

    }
}