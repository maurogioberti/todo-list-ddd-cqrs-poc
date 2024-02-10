using Poc.TaskHub.Business.Dto;

namespace Poc.TaskHub.Api.Business.Validation.Infrastructure
{
    public class TaskDtoCreationValidator
    {
        public const string RequiredFieldMessage = "The field {0} is required.";
        public const string ContentLengthMessage = "The content must be between {0} and {1} characters long.";
        public const string DescriptionLengthMessage = "The description, if provided, must be between {0} and {1} characters long.";
        public const int MinContentLength = 5;
        public const int MaxContentLength = 100;
        public const int MinDescriptionLength = 0;
        public const int MaxDescriptionLength = 200;

        public static ValidateObject Validate(TaskDto taskDto)
        {
            var contentError = ValidateContent(taskDto);
            if (!contentError.IsValid)
                return contentError;

            var descriptionError = ValidateDescription(taskDto);
            if (!descriptionError.IsValid)
                return descriptionError;

            return new ValidateObject(true, string.Empty);
        }

        private static ValidateObject ValidateContent(TaskDto taskDto)
        {
            if (string.IsNullOrWhiteSpace(taskDto.Content))
                return new ValidateObject(false, string.Format(RequiredFieldMessage, nameof(taskDto.Content)));

            if (taskDto.Content.Length < MinContentLength || taskDto.Content.Length > MaxContentLength)
                return new ValidateObject(false, string.Format(ContentLengthMessage, MinContentLength, MaxContentLength));

            return new ValidateObject(true, string.Empty);
        }

        private static ValidateObject ValidateDescription(TaskDto taskDto)
        {
            if (!string.IsNullOrWhiteSpace(taskDto.Description) &&
                (taskDto.Description.Length < MinDescriptionLength || taskDto.Description.Length > MaxDescriptionLength))
                return new ValidateObject(false, string.Format(DescriptionLengthMessage, MinDescriptionLength, MaxDescriptionLength));

            return new ValidateObject(true, string.Empty);
        }
    }
}