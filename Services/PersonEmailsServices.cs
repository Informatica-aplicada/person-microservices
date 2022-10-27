using apiPersonaNet.Database;
using apiPersonaNet.Models;
using System;
using Microsoft.AspNetCore.Mvc;

namespace apiPersonaNet.Services
{
    public class PersonEmailsServices:IPersonEmails
    {
        public PersonEmailsServices(){}

        DataPersonEmails dp = new DataPersonEmails();

        public List<PersonEmails> getPersonEmailsList(){
            return dp.List();
        }

        public List<Email> getEmailsList(int BusinessEntityID){
            return dp.getEmails(BusinessEntityID);
        }

         public bool Add(Email email, int BusinessEntityID, int Action){
            return dp.Add(email, BusinessEntityID, Action);     
        }

        public bool Update(Email email, int BusinessEntityID, int Action){
            return dp.Update(email, BusinessEntityID, Action);     
        }

        public bool Delete(Email email, int BusinessEntityID, int Action) {
            return dp.Delete(email, BusinessEntityID, Action);
        }

    }
}
