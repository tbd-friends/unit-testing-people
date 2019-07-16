using System;
using Commands;
using Commands.Messages;
using Models;
using Moq;
using Persistence;
using Xunit;

namespace People.Tests
{
    public class when_person_is_not_an_adult
    {
        public Mock<IStorage> Storage;
        public AddPersonHandler Subject;

        public when_person_is_not_an_adult()
        {
            Storage = new Mock<IStorage>();

            Subject = new AddPersonHandler(Storage.Object);

            Subject.Handle(new AddPerson
            {
                DateOfBirth = DateTime.Now.AddYears(-15)
            });
        }

        [Fact]
        public void person_is_not_created()
        {
            Storage.Verify(s => s.Add(It.IsAny<Person>()), Times.Never);
        }
    }
}