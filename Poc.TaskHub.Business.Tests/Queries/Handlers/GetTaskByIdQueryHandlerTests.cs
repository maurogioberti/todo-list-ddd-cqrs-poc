using AutoFixture;
using Moq;
using NUnit.Framework;
using Poc.TaskHub.Business.Mappers;
using Poc.TaskHub.Business.Queries;
using Poc.TaskHub.Business.Queries.Handlers;
using Poc.TaskHub.Eai.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Poc.TaskHub.Business.Tests.Queries.Handlers
{

    [TestFixture]
    public class GetTaskByIdQueryHandlerTests
    {
        private class GetTaskByIdQueryHandlerBuilder
        {
            private Mock<ITaskAdapter> _taskAdapterMock;
            public Mock<ITaskAdapter> TaskAdapterMock => _taskAdapterMock ??= new Mock<ITaskAdapter>();

            public GetTaskByIdQueryHandler Build()
            {
                return new GetTaskByIdQueryHandler(TaskAdapterMock.Object, new TaskMapper());
            }
        }

        private readonly Fixture _fixture = new();

        [TestCase(0)]
        [TestCase(-1)]
        public void Handle_Invalid_Id_Should_Throw_ValidationException(int invalidId)
        {
            // Arrange
            var builder = new GetTaskByIdQueryHandlerBuilder();
            var invalidQuery = new GetTaskByIdQuery(invalidId);

            var handler = builder.Build();

            // Act & Assert
            Assert.That(() => handler.Handle(invalidQuery), Throws.InstanceOf<ValidationException>());
        }

        [Test]
        public void Handle_Valid_Id_Task_Not_Found_Should_Return_Null()
        {
            // Arrange
            var builder = new GetTaskByIdQueryHandlerBuilder();
            var query = new GetTaskByIdQuery(_fixture.Create<int>());

            var handler = builder.Build();

            builder.TaskAdapterMock.Setup(x => x.Get(It.IsAny<int>())).Returns((Domain.Task)null);

            // Act
            var result = handler.Handle(query);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Handle_Valid_Id_Task_Found_Should_Return_Mapped_TaskDto()
        {
            // Arrange
            var taskDomain = _fixture.Create<Domain.Task>();
            var builder = new GetTaskByIdQueryHandlerBuilder();
            var handler = builder.Build();
            var query = new GetTaskByIdQuery(taskDomain.Id);

            builder.TaskAdapterMock.Setup(x => x.Get(It.IsAny<int>())).Returns(taskDomain);

            // Act
            var result = handler.Handle(query);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(taskDomain.Id));
        }
    }
}