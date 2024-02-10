using AutoFixture;
using NUnit.Framework;
using Poc.TaskHub.Api.Business.Validation.Infrastructure;
using Poc.TaskHub.Business.Dto;

namespace Poc.TaskHub.Business.Tests.Validations
{
    [TestFixture]
    public class TaskDtoCreationValidatorTests
    {
        private readonly Fixture _fixture = new();

        private const string RequiredFieldMessageFormat = "The field {0} is required.";
        private const string ContentLengthMessageFormat = "The content must be between {0} and {1} characters long.";
        private const string DescriptionLengthMessageFormat = "The description, if provided, must be between {0} and {1} characters long.";

        private const string ValidContent = "Valid content";
        private const string ValidDescription = "Valid description";
        private const string TooShortContent = "1234"; // Assuming MinContentLength > 4
        private const char SingleContentLength = 'a';
        private const int ContentJustOverMaxLength = TaskDtoCreationValidator.MaxContentLength + 1;
        private const int DescriptionJustOverMaxLength = TaskDtoCreationValidator.MaxDescriptionLength + 1;

        [Test]
        public void Validate_Content_Is_Required_Should_Fail_If_Missing()
        {
            // Arrange
            var taskDto = _fixture.Build<TaskDto>()
                                  .With(x => x.Content, string.Empty)
                                  .Create();

            var expectedMessage = string.Format(RequiredFieldMessageFormat, nameof(TaskDto.Content));

            // Act
            var result = TaskDtoCreationValidator.Validate(taskDto);

            // Assert
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.Message, Does.Contain(expectedMessage));
        }

        [Test]
        public void Validate_Content_Length_Should_Fail_If_Too_Short()
        {
            // Arrange
            var taskDto = _fixture.Build<TaskDto>()
                                  .With(x => x.Content, TooShortContent)
                                  .Create();

            var expectedMessage = string.Format(ContentLengthMessageFormat, TaskDtoCreationValidator.MinContentLength, TaskDtoCreationValidator.MaxContentLength);

            // Act
            var result = TaskDtoCreationValidator.Validate(taskDto);

            // Assert
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.Message, Does.Contain(expectedMessage));
        }

        [Test]
        public void Validate_Content_Length_Should_Fail_If_Too_Long()
        {
            // Arrange
            var longContent = new string(SingleContentLength, ContentJustOverMaxLength);
            var taskDto = _fixture.Build<TaskDto>()
                                  .With(x => x.Content, longContent)
                                  .Create();
            var expectedMessage = string.Format(ContentLengthMessageFormat, TaskDtoCreationValidator.MinContentLength, TaskDtoCreationValidator.MaxContentLength);

            // Act
            var result = TaskDtoCreationValidator.Validate(taskDto);

            // Assert
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.Message, Does.Contain(expectedMessage));
        }

        [Test]
        public void Validate_Description_Length_Should_Fail_If_Too_Long()
        {
            // Arrange
            var longDescription = new string(SingleContentLength, DescriptionJustOverMaxLength);
            var taskDto = _fixture.Build<TaskDto>()
                                  .With(x => x.Description, longDescription)
                                  .Create();
            var expectedMessage = string.Format(DescriptionLengthMessageFormat, TaskDtoCreationValidator.MinDescriptionLength, TaskDtoCreationValidator.MaxDescriptionLength);

            // Act
            var result = TaskDtoCreationValidator.Validate(taskDto);

            // Assert
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.Message, Does.Contain(expectedMessage));
        }

        [Test]
        public void Validate_Valid_TaskDto_Should_Pass()
        {
            // Arrange
            var taskDto = _fixture.Build<TaskDto>()
                                  .With(x => x.Content, ValidContent)
                                  .With(x => x.Description, ValidDescription)
                                  .Create();

            // Act
            var result = TaskDtoCreationValidator.Validate(taskDto);

            // Assert
            Assert.That(result.IsValid, Is.True);
            Assert.That(result.Message, Is.Empty);
        }
    }
}