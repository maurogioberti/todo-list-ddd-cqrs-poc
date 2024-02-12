using AutoFixture;
using NUnit.Framework;
using Poc.TaskHub.Eai.Abstractions;

namespace Poc.TaskHub.Eai.IntegrationTests.Adapters
{
    /// <summary>
    /// Integration tests for TaskAdapter focusing on the interaction between the TaskAdapter and the simulated data model.
    /// AutoFixture is used to mock data within the adapter implementation, located in the Poc.TaskHub.Eai.Adapters layer, aiming to test
    /// the integration logic of the adapter under controlled conditions. This ensures that the integration between components functions as expected,
    /// simulating responses from an external system or component, without the need for actual external dependencies in the testing environment.
    /// </summary>
    [TestFixture]
    public class TaskAdapterTests
    {
        private readonly ITaskAdapter _adapter = new TaskAdapter();
        private readonly Fixture _fixture = new();

        [Test]
        public void GetAll_Should_Return_NonEmpty_Collection()
        {
            // Arrange

            // Act
            var tasks = _adapter.GetAll();

            // Assert
            Assert.That(tasks, Is.Not.Empty);
        }

        [Test]
        public void Get_Should_Return_NonEmpty_Task()
        {
            // Arrange
            var id = _fixture.Create<int>();

            // Act
            var task = _adapter.Get(id);

            // Assert
            Assert.That(id, Is.EqualTo(task.Id));
        }

        [Test]
        public void Create_Should_Return_NonEmpty_Task()
        {
            // Arrange
            var description = _fixture.Create<string>();
            var content = _fixture.Create<string>();
            var isCompleted = _fixture.Create<bool>();

            // Act
            var task = _adapter.Create(description, content, isCompleted);

            // Assert
            Assert.That(task.Id, Is.GreaterThan(decimal.Zero));
            Assert.That(description, Is.EqualTo(task.Description));
            Assert.That(content, Is.EqualTo(task.Content));
            Assert.That(isCompleted, Is.EqualTo(task.IsCompleted));
        }
    }
}