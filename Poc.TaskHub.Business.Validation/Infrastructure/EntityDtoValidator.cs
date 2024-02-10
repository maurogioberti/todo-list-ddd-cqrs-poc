using Poc.TaskHub.Business.Domain.Infrastructure;

namespace Poc.TaskHub.Api.Business.Validation.Infrastructure
{
    /// <summary>
    /// Provides validation for DTO entities ensuring that they meet specified criteria.
    /// </summary>
    public class EntityDtoValidator
    {
        public const string ValidateFieldMessage = "The data {0} only accepts integer values greater than zero.";
        public const string RequiredFieldMessage = "The data {0} is not valid.";

        /// <summary>
        /// Validates that the provided DTO entity meets the obligatory criteria.
        /// </summary>
        /// <param name="entityDto">The DTO entity to validate.</param>
        /// <param name="name">The name of the field being validated.</param>
        /// <returns>A ValidateObject indicating if the validation passed along with any messages.</returns>
        public static ValidateObject ValidateMandatory<T>(EntityDto<T> entityDto, string name) where T : IComparable, IComparable<T>
        {
            if (entityDto == null || entityDto.Id == null)
            {
                return new ValidateObject(false, string.Format(RequiredFieldMessage, name));
            }

            if (entityDto.Id.CompareTo(default) <= decimal.Zero)
            {
                return new ValidateObject(false, string.Format(ValidateFieldMessage, name));
            }

            return new ValidateObject(true, string.Empty);
        }
    }
}