﻿using System;

namespace Enterwell.Exceptions.Exceptions
{
    /// <summary>
    /// Enterwell forbidden exception class
    /// </summary>
    public class EnterwellForbiddenException : EnterwellException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnterwellForbiddenException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public EnterwellForbiddenException(string message, Exception innerException)
            : base(message, innerException)
        {       
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnterwellForbiddenException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="key">The key.</param>
        /// <param name="innerException">The inner exception.</param>
        public EnterwellForbiddenException(string message, string key = null, Exception innerException = null)
            : base(message, key, innerException)
        {         
        }

        /// <summary>
        /// Gets the default key.
        /// </summary>
        /// <returns>
        /// Returns default key
        /// </returns>
        protected override string GetDefaultKey()
        {
            return GenerateDefaultKey(base.GetDefaultKey(), "Forbidden");
        }
    }
}
