using apiPersonaNet.Models;

public interface IPerson
{
    List<PersonInfo>  getPersonList(int[] ids);

     public List<PersonInfo> getAllThePeople();

    UserModel auth(LoginCredentials auth);

}