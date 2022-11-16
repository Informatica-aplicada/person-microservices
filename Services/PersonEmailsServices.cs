using apiPersonaNet.Database;
using apiPersonaNet.Models;

namespace apiPersonaNet.Services
{
    public class PersonEmailsServices
    {
        public PersonEmailsServices(){}
        DataPersonEmails dp = new DataPersonEmails();
        public List<PersonEmails> getPersonEmailsList(){
            return dp.List();
        }
        public List<Email> getEmailsList(int BusinessEntityID){
            return dp.getEmails(BusinessEntityID);
        }
         public bool Action(Email email){
            return dp.Action(email);     
        }

        /*public bool Update(Email email, int BusinessEntityID, int Action){
            return dp.Update(email, BusinessEntityID, Action);     
        }

        public bool Delete(Email email, int BusinessEntityID, int Action) {
            return dp.Delete(email, BusinessEntityID, Action);
        }*/

    }
}
