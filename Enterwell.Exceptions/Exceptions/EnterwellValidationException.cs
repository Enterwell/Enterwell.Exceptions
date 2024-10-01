using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Enterwell.Exceptions.Exceptions
{
    /// <summary>
    /// Enterwell validation exception class
    /// </summary>
    /// <seealso cref="EnterwellException" />
    [Serializable]
    public class EnterwellValidationException : EnterwellException
    {
        /// <summary>
        /// Gets the field errors.
        /// </summary>
        /// <value>
        /// The field errors.
        /// </value>
        public Dictionary<string, string> FieldErrors { get; private set; } = new Dictionary<string, string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="EnterwellValidationException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="fieldErrors">The field errors.</param>
        public EnterwellValidationException(string message, Exception innerException, Dictionary<string, string> fieldErrors = null)
            : base(message, innerException)
        {
            if (fieldErrors != null)
            {
                this.FieldErrors = fieldErrors;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnterwellValidationException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="fieldErrors">The field errors.</param>
        /// <param name="key">The key.</param>
        /// <param name="innerException">The inner exception.</param>
        public EnterwellValidationException(string message, Dictionary<string, string> fieldErrors = null, string key = null, Exception innerException = null)
            : base(message, key, innerException)
        {
            if (fieldErrors != null)
            {
                this.FieldErrors = fieldErrors;
            }
        }

        /// <summary>
        /// Gets the default key.
        /// </summary>
        /// <returns>
        /// Returns default key
        /// </returns>
        protected override string GetDefaultKey()
        {
            return GenerateDefaultKey(base.GetDefaultKey(), "Validation");
        }

        /// <summary>
        /// Adds the error.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="error">The error.</param>
        /// <returns>Returns enterwell validation exception with new error added</returns>
        public EnterwellValidationException AddError(string field, string error)
        {
            FieldErrors.Add(field, error);
            return this;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnterwellValidationException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected EnterwellValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info != null)
            {
                this.FieldErrors = (Dictionary<string, string>)info.GetValue("FieldErrors", typeof(Dictionary<string, string>));
            }
        }

        /// <summary>
        /// Gets information about the exception and adds it to the <see cref="T:System.Runtime.Serialization.SerializationInfo" /> object.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that holds the contextual information about the source or destination.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info != null)
            {
                info.AddValue("FieldErrors", this.FieldErrors);
            }

            base.GetObjectData(info, context);
        }
    }
}