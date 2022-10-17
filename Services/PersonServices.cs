using apiPersonaNet.Database;
using apiPersonaNet.Models;

namespace apiPersonaNet.Services
{
    public class PersonServices:IPerson
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

        public PersonInfo getPerson(int id)
        {
            return dp.GetPerson(id);
        }

        public void deletePerson(int id)
        {
            dp.deletePerson(id);
        }

        public void addPerson(PersonInfo person)
        {
            dp.addPerson(person);
        }

        public void updatePerson(PersonInfo person)
        {
            dp.updatePerson(person);
        }

        public UserModel auth(LoginCredentials auth)
        {

            return dp.auth(auth);

        }
    }
}