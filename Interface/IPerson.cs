using apiPersonaNet.Models;

public interface IPerson
{
    List<PersonInfo> getPersonList(int[] ids);

    List<PersonInfo> getAllThePeople();

    PersonInfo getPerson(int id);

    void deletePerson(int id);

    void addPerson(PersonInfo person);

    void updatePerson(PersonInfo person);

    UserModel auth(LoginCredentials auth);

}