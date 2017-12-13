using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;
using TakeHomeAssignment.Models;
using System.Data.Entity.Validation;
using System.Web;


namespace TakeHomeAssignment.Controllers
{
    public class PersonsAPIController : ApiController
    {
        private IPersonApp _personApp;

        public PersonsAPIController(IPersonApp person)
        {
            _personApp = person;
        }

        [Route("Persons")]
        public List<Person> GetAllPersons()
        {
            return _personApp.GetAllPersons();
        }

        [Route("Persons/{value}")]
        [HttpGet]
        public List<Person> FindPersons(string value)
        {
            var persons = _personApp.FindPersons(value);
            return persons;
        }
    }
}