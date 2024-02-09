using System.Linq.Expressions;

namespace Poc.TaskHub.CrossCutting.Exceptions
{
    /// <summary>
    /// Provides helper methods for argument validation.
    /// </summary>
    public static class Argument
    {
        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the specified expression evaluates to null.
        /// </summary>
        /// <typeparam name="T">The type of the expression.</typeparam>
        /// <param name="expression">The expression to evaluate.</param>
        public static void ThrowIfNull<T>(Expression<Func<T>> expression)
        {
            Evaluate(expression, out var body, out var value);

            ThrowIfNull(value, body.Member.Name);
        }

        /// <summary>
        /// Evaluates the specified expression and retrieves its body and value.
        /// </summary>
        /// <typeparam name="T">The type of the expression.</typeparam>
        /// <param name="expression">The expression to evaluate.</param>
        /// <param name="body">The body of the expression.</param>
        /// <param name="value">The value of the expression.</param>
        private static void Evaluate<T>(Expression<Func<T>> expression, out MemberExpression body, out T value)
        {
            body = (MemberExpression)expression.Body;
            ThrowIfNull(body, nameof(body));

            var compiled = expression.Compile();

            value = compiled();
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the specified object is null.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="obj">The object to check for null.</param>
        /// <param name="parameterName">The name of the parameter associated with the object.</param>
        private static void ThrowIfNull<T>(T obj, string parameterName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }
    }
}