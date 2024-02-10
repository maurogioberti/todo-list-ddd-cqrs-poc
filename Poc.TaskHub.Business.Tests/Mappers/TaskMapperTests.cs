using AutoFixture;
using NUnit.Framework;
using Poc.TaskHub.Business.Dto;
using Poc.TaskHub.Business.Mappers;

namespace Poc.TaskHub.Business.Tests.Mappers
{
    [TestFixture]
    public class TaskMapperTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Test]
        public void Map_Dto_To_Domain_Should_Return_Correct_Mapping()
        {
            // Arrange
            var dto = _fixture.Create<TaskDto>();
            var mapper = new TaskMapper();

            // Act
            var domain = mapper.Map(dto);

            // Assert
            Assert.That(domain.Id, Is.EqualTo(dto.Id));
            Assert.That(domain.Description, Is.EqualTo(dto.Description));
            Assert.That(domain.Content, Is.EqualTo(dto.Content));
            Assert.That(domain.IsCompleted, Is.EqualTo(dto.IsCompleted));
        }

        [Test]
        public void Map_Domain_To_Dto_Should_Return_Correct_Mapping()
        {
            // Arrange
            var domain = _fixture.Create<Domain.Task>();
            var mapper = new TaskMapper();

            // Act
            var dto = mapper.Map(domain);

            // Assert
            Assert.That(dto.Id, Is.EqualTo(domain.Id));
            Assert.That(dto.Description, Is.EqualTo(domain.Description));
            Assert.That(dto.Content, Is.EqualTo(domain.Content));
            Assert.That(dto.IsCompleted, Is.EqualTo(domain.IsCompleted));
        }
    }
}