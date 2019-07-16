using Commands;
using Commands.Messages;
using Models;
using Moq;
using Persistence;
using Xunit;

namespace People.Tests
{
    public class when_only_a_last_name_is_provided
    {
        public AddPersonHandler Subject;
        public Mock<IStorage> Storage;

        public when_only_a_last_name_is_provided()
        {
            Storage = new Mock<IStorage>();

            Subject = new AddPersonHandler(Storage.Object);

            Subject.Handle(new AddPerson
            {
                LastName = "Jones"
            });
        }

        [Fact]
        public void person_is_created()
        {
            Storage.Verify(s => s.Add(It.Is<Person>(p => p.LastName == "Jones")));
        }
    }
}