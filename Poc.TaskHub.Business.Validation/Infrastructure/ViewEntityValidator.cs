using Poc.TaskHub.Business.Domain.Infrastructure;

namespace Poc.TaskHub.Api.Business.Validation.Infrastructure
{
    /// <summary>
    /// Provides validation for view entities ensuring that they meet specified criteria.
    /// </summary>
    public class ViewEntityValidator
    {
        public const string ValidateFieldMessage = "The data {0} only accepts integer values greater than zero.";
        public const string RequiredFieldMessage = "The data {0} is not valid.";

        /// <summary>
        /// Validates that the provided DataView entity meets the obligatory criteria.
        /// </summary>
        /// <param name="viewEntity">The DataView<T> entity to validate.</param>
        /// <param name="name">The name of the field being validated.</param>
        /// <returns>A ValidateObject indicating if the validation passed along with any messages.</returns>
        public static ValidateObject ValidateMandatory<T>(DataView<T> viewEntity, string name) where T : IComparable, IComparable<T>
        {
            if (viewEntity == null || viewEntity.Id == null)
            {
                return new ValidateObject(false, string.Format(RequiredFieldMessage, name));
            }

            if (viewEntity.Id.CompareTo(default) <= decimal.Zero)
            {
                return new ValidateObject(false, string.Format(ValidateFieldMessage, name));
            }

            return new ValidateObject(true, string.Empty);
        }
    }
}