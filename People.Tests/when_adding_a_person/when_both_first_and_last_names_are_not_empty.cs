using Commands;
using Commands.Messages;
using FluentAssertions;
using Models;
using Moq;
using Persistence;
using Xunit;

namespace People.Tests
{
    public class when_both_first_and_last_names_are_not_empty
    {
        public AddPersonHandler Subject;
        public Mock<IStorage> Storage;
        public Person Result;
        private const string FirstName = "Bob";
        private const string LastName = "Jones";

        public when_both_first_and_last_names_are_not_empty()
        {
            Storage = new Mock<IStorage>();

            Storage.Setup(s => s.Add(It.IsAny<Person>())).Callback((Person p) => { Result = p; });

            Subject = new AddPersonHandler(Storage.Object);

            Subject.Handle(new AddPerson
            {
                FirstName = FirstName,
                LastName = LastName
            });
        }

        [Fact]
        public void person_is_created()
        {
            Storage.Verify(s => s.Add(It.IsAny<Person>()));
        }

        [Fact]
        public void person_first_name_is_set()
        {
            Result.FirstName.Should().Be(FirstName);
        }

        [Fact]
        public void person_last_name_is_set()
        {
            Result.LastName.Should().Be(LastName);
        }
    }
}