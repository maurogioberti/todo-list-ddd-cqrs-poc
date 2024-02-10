using AutoFixture;
using Moq;
using NUnit.Framework;
using Poc.TaskHub.Business.Mappers;
using Poc.TaskHub.Business.Queries;
using Poc.TaskHub.Business.Queries.Handlers;
using Poc.TaskHub.Eai.Abstractions;

namespace Poc.TaskHub.Business.Tests.Queries.Handlers
{
    [TestFixture]
    public class GetAllTasksQueryHandlerTests
    {
        private class GetAllTasksQueryHandlerBuilder
        {
            private Mock<ITaskAdapter> _taskAdapterMock;
            public Mock<ITaskAdapter> TaskAdapterMock => _taskAdapterMock ??= new Mock<ITaskAdapter>();

            public GetAllTasksQueryHandler Build()
            {
                return new GetAllTasksQueryHandler(TaskAdapterMock.Object, new TaskMapper());
            }
        }

        private readonly Fixture _fixture = new();

        [Test]
        public void Handle_No_Tasks_Found_Should_Return_Empty_Collection()
        {
            // Arrange
            var builder = new GetAllTasksQueryHandlerBuilder();
            builder.TaskAdapterMock.Setup(a => a.GetAll()).Returns(Enumerable.Empty<Domain.Task>());

            // Act
            var handler = builder.Build();
            var result = handler.Handle(new GetAllTasksQuery());

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Handle_Valid_Id_Task_Not_Found_Should_Return_Null()
        {
            // Arrange
            var builder = new GetAllTasksQueryHandlerBuilder();
            var handler = builder.Build();

            builder.TaskAdapterMock.Setup(x => x.GetAll()).Returns((IEnumerable<Domain.Task>)null);

            // Act
            var result = handler.Handle(new GetAllTasksQuery());

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Handle_Tasks_Found_Should_Return_NonEmpty_Collection()
        {
            // Arrange
            var tasksDomain = _fixture.CreateMany<Domain.Task>(5);
            var builder = new GetAllTasksQueryHandlerBuilder();
            builder.TaskAdapterMock.Setup(a => a.GetAll()).Returns(tasksDomain);

            // Act
            var handler = builder.Build();
            var result = handler.Handle(new GetAllTasksQuery());

            // Assert
            Assert.That(result.Count(), Is.EqualTo(tasksDomain.Count()));
        }
    }
}