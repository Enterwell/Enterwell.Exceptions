using Enterwell.Exceptions.Exceptions;

namespace Enterwell.Exceptions
{
    /// <summary>
    /// Extension methods class for converting enterwell exceptions
    /// </summary>
    public static class CastExtensionMethods
    {
        /// <summary>
        /// Converts EnterwellException to EnterwellHttpException
        /// </summary>
        /// <param name="enterwellException">The enterwell exception.</param>
        /// <returns>Returns created enterwell http exception</returns>
        public static EnterwellHttpException AsHttpException(this EnterwellException enterwellException)
        {
            return ExceptionsHelper.ToEnterwellHttpException(enterwellException);
        }
    }
}
