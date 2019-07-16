using System;
using Commands;
using Commands.Messages;
using FluentAssertions;
using Moq;
using Persistence;
using Xunit;

namespace People.Tests
{
    public class when_no_details_are_provided
    {
        public AddPersonHandler Subject;
        public Mock<IStorage> Storage;

        public when_no_details_are_provided()
        {
            Storage = new Mock<IStorage>();

            Subject = new AddPersonHandler(Storage.Object);
        }

        [Fact]
        public void exception_is_thrown()
        {
            Action a = () =>
            {
                Subject.Handle(new AddPerson { });
            };

            a.Should().Throw<ArgumentNullException>();
        }
    }
}