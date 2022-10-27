using apiPersonaNet.Models;
using Microsoft.AspNetCore.Mvc;

public interface IPerson
{
    List<PersonInfo>  getPersonList(int[] ids);
    UserModel auth(LoginCredentials auth);

    void saveEmail([FromBody] EmailPerson person);

    void editEmail([FromBody] EmailPerson person);

    void deleteEmail(int id);

}