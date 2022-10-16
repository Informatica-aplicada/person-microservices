using apiPersonaNet.Database;
using apiPersonaNet.Models;

namespace apiPersonaNet.Services
{
    public class PersonServices : IPerson
    {
        public PersonServices() { }

        DataPerson dp = new DataPerson();

        public List<PersonInfo> getPersonList(int[] ids)
        {
            return dp.List(ids);
        }

        public List<PersonInfo> getAllThePeople()
        {
            return dp.ListInformationG();
        }

        public UserModel auth(LoginCredentials auth)
        {

            return dp.auth(auth);

        }
    }
}