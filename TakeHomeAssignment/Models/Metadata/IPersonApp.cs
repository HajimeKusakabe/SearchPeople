using System.Collections.Generic;

namespace TakeHomeAssignment.Models
{
    public interface IPersonApp
    {
        List<Person> GetAllPersons();
        List<Person> FindPersons(string input);
    }
}