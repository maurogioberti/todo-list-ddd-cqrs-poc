using NUnit.Framework;
using Poc.TaskHub.Eai;

namespace Poc.TaskHub.Business.Tests.Adapters
{
    [TestFixture]
    public class TaskAdapterTests
    {
        [Test]
        public void GetAll_Should_Return_NonEmpty_Collection()
        {
            // Arrange
            var adapter = new TaskAdapter();

            // Act
            var tasks = adapter.GetAll();

            // Assert
            Assert.That(tasks, Is.Not.Empty);
        }
    }
}