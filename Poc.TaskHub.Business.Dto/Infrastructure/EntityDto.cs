namespace Poc.TaskHub.Business.Domain.Infrastructure
{
    /// <summary>
    /// Base class for domain entities, providing a common ID and description.
    /// This class serves as the foundation for all domain entities, ensuring consistency in the domain model.
    /// </summary>
    /// <typeparam name="T">The type of the ID property.</typeparam>
    public abstract class EntityDto<T>
    {
        /// <summary>
        /// Gets or sets the ID of the domain entity.
        /// </summary>
        public T Id { get; set; } = default;

        /// <summary>
        /// Gets or sets the description of the domain entity.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityDto{T}"/> class.
        /// </summary>
        protected EntityDto() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityDto{T}"/> class with the specified ID and description.
        /// </summary>
        /// <param name="id">The ID of the domain entity.</param>
        /// <param name="description">The description of the domain entity.</param>
        protected EntityDto(T id, string description = default)
        {
            Id = id;
            Description = description;
        }
    }
}