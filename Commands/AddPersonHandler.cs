using System;
using System.Linq;
using Commands.Messages;
using Models;
using Persistence;

namespace Commands
{
    public class AddPersonHandler
    {
        private readonly IStorage _storage;

        public AddPersonHandler(IStorage storage)
        {
            _storage = storage;
        }

        public void Handle(AddPerson command)
        {
            if (IsValid(command))
            {
                _storage.Add(new Person
                {
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    DateOfBirth = command.DateOfBirth
                });
            }
            else
            {
                throw new ArgumentNullException("Bah!");
            }
        }

        private bool IsValid(AddPerson command)
        {
            return (!string.IsNullOrEmpty(command.FirstName) || !string.IsNullOrEmpty(command.LastName)) &&
                   (DateTime.Now.Year - command.DateOfBirth.Year) >= 18;
        }
    }
}