using Enterwell.Exceptions.Exceptions;

namespace Enterwell.Exceptions
{
    /// <summary>
    /// Helper class for Enterwell exceptions
    /// </summary>
    public static class ExceptionsHelper
    {
        /// <summary>
        /// Converts the enterwell exception to enterwell HTTP exception.
        /// </summary>
        /// <param name="enterwellException">The enterwell exception.</param>
        /// <returns>Returns converted enterwell http exception</returns>
        public static EnterwellHttpException ToEnterwellHttpException(
            EnterwellException enterwellException)
        {
            var httpCode = (int) System.Net.HttpStatusCode.BadRequest;

            if (enterwellException is EnterwellValidationException)
            {
                httpCode = (int) System.Net.HttpStatusCode.BadRequest;
            }
            else if (enterwellException is EnterwellForbiddenException)
            {
                httpCode = (int) System.Net.HttpStatusCode.Forbidden;
            }
            else if (enterwellException is EnterwellUnauthorizedException)
            {
                httpCode = (int) System.Net.HttpStatusCode.Unauthorized;
            }
            else if (enterwellException is EnterwellEntityNotFoundException)
            {
                httpCode = (int)System.Net.HttpStatusCode.NotFound;
            }

            return new EnterwellHttpException(enterwellException.Key, httpCode, enterwellException.Message,
                enterwellException);
        }
    }
}