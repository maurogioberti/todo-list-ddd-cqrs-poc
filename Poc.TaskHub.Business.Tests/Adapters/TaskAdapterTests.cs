using AutoFixture;
using NUnit.Framework;
using Poc.TaskHub.Eai;
using Poc.TaskHub.Eai.Abstractions;

namespace Poc.TaskHub.Business.Tests.Adapters
{
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
    }
}