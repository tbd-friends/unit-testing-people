using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commands;
using Commands.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace PersonsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly AddPersonHandler _handler;

        public PersonsController(IStorage storage)
        {
            _handler = new AddPersonHandler(storage);
        }

        [Route("add")]
        public void AddPerson([FromBody] PersonInputModel model)
        {
            _handler.Handle(new AddPerson
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth
            });
        }
    }

    public class PersonInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}