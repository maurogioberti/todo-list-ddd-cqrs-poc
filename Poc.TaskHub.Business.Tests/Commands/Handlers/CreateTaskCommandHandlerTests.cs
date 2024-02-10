using AutoFixture;
using Moq;
using NUnit.Framework;
using Poc.TaskHub.Business.Commands;
using Poc.TaskHub.Business.Commands.Handlers;
using Poc.TaskHub.Business.Mappers;
using Poc.TaskHub.Eai.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Poc.TaskHub.Business.Tests.Commands.Handlers
{
    [TestFixture]
    public class CreateTaskCommandHandlerTests
    {
        private class CreateTaskCommandHandlerBuilder
        {
            private Mock<ITaskAdapter> _taskAdapterMock;
            public Mock<ITaskAdapter> TaskAdapterMock => _taskAdapterMock ??= new Mock<ITaskAdapter>();

            public CreateTaskCommandHandler Build()
            {
                return new CreateTaskCommandHandler(TaskAdapterMock.Object, new TaskMapper());
            }
        }

        private readonly Fixture _fixture = new Fixture();

        [Test]
        public void Handle_Invalid_Command_Should_Throw_ValidationException()
        {
            // Arrange
            var builder = new CreateTaskCommandHandlerBuilder();
            var invalidCommand = _fixture.Build<CreateTaskCommand>().With(x => x.Content, string.Empty).Create();
            var handler = builder.Build();

            // Act & Assert
            Assert.That(() => handler.Handle(invalidCommand), Throws.InstanceOf<ValidationException>());
        }

        [Test]
        public void Handle_Valid_Command_Should_Return_Created_Task()
        {
            // Arrange
            var taskDomain = _fixture.Create<Domain.Task>();
            var builder = new CreateTaskCommandHandlerBuilder();
            var validCommand = _fixture.Create<CreateTaskCommand>();
            var handler = builder.Build();

            builder.TaskAdapterMock.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>())).Returns(taskDomain);

            // Act
            var result = handler.Handle(validCommand);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(taskDomain.Id));
        }
    }
}