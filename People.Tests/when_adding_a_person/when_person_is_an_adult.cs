using System;
using Commands;
using Commands.Messages;
using Models;
using Moq;
using Persistence;
using Xunit;

namespace People.Tests
{
    public class when_person_is_an_adult
    {
        public Mock<IStorage> Storage;
        public AddPersonHandler Subject;
        private readonly DateTime _dateOfBirth;

        public when_person_is_an_adult()
        {
            Storage = new Mock<IStorage>();

            Subject = new AddPersonHandler(Storage.Object);

            _dateOfBirth = DateTime.Now.AddYears(-21);

            Subject.Handle(new AddPerson
            {
                DateOfBirth = _dateOfBirth
            });
        }

        [Fact]
        public void person_is_created()
        {
            Storage.Verify(s => s.Add(It.Is<Person>(p => p.DateOfBirth == _dateOfBirth)));
        }
    }
}