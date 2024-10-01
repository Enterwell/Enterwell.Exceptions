using System;
using System.Runtime.Serialization;

namespace Enterwell.Exceptions.Exceptions
{
    /// <summary>
    /// Enterwell exception class
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class EnterwellException : Exception
    {
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key { get; private set; }

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EnterwellException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public EnterwellException(string message, Exception innerException)
            : base(message, innerException)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            this.Key = GetDefaultKey();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnterwellException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="key">The key.</param>
        /// <param name="innerException">The inner exception.</param>
        public EnterwellException(string message, string key = null, Exception innerException = null)
            : base(message, innerException)
        {
            this.Key = key == null ? GetDefaultKey() : GenerateKey(GetDefaultKey(), key);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnterwellException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected EnterwellException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {           
        }

        #endregion

        /// <summary>
        /// Generates the default key.
        /// </summary>
        /// <param name="baseDefaultKey">The base default key.</param>
        /// <param name="defaultKey">The default key.</param>
        /// <returns>Returns string with default key added</returns>
        protected static string GenerateDefaultKey(string baseDefaultKey, string defaultKey)
        {
            return $"{baseDefaultKey}.{defaultKey}";
        }

        /// <summary>
        /// Generates the addition.
        /// </summary>
        /// <param name="defaultKey">The default.</param>
        /// <param name="key">The key.</param>
        /// <returns>Returns key with added key connected with hyphen</returns>
        private static string GenerateKey(string defaultKey, string key)
        {
            return $"{defaultKey}-{key}";
        }

        /// <summary>
        /// Gets the default key.
        /// </summary>
        /// <returns>Returns default key</returns>
        protected virtual string GetDefaultKey()
        {
            return "Enterwell";
        }
    }
}