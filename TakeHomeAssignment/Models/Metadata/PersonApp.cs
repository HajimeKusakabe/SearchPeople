using System;
using System.Collections.Generic;
using System.Linq;

namespace TakeHomeAssignment.Models.Metadata
{
    public class PersonApp : IDisposable, IPersonApp
    {
        private ApplicationDBEntities db = new ApplicationDBEntities();

        public List<Person> GetAllPersons()
        {
            var persons = db.Persons.OrderBy(a => a.FirstName).ThenBy(a => a.LastName);
            return persons.ToList();
        }

        public List<Person> FindPersons(string input)
        {
            var persons = db.Persons.Where(a => a.FirstName.Contains(input) || a.LastName.Contains(input))
                .OrderBy(a => a.FirstName).ThenBy(a => a.LastName);
            return persons.ToList();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}