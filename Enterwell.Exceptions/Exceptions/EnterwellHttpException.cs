using System;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Enterwell.Exceptions.Exceptions
{
    /// <summary>
    /// Enterwell exception
    /// </summary>
    [Serializable]
    public class EnterwellHttpException : System.Web.HttpException, IHttpActionResult
    {
        /// <summary>
        /// Gets the error code.
        /// </summary>
        public string Error { get; }

        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>
        /// The exception.
        /// </value>
        public EnterwellException Exception { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnterwellHttpException"/> class.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="httpCode">The HTTP code.</param>
        /// <param name="errorDescription">The error description.</param>
        public EnterwellHttpException(string error, int httpCode, string errorDescription)
            : base(httpCode, errorDescription)
        {
            this.Error = error;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnterwellHttpException"/> class.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="errorDescription">The error description.</param>
        /// <param name="exception">The exception.</param>
        public EnterwellHttpException(string error, string errorDescription, EnterwellException exception)
            : base(errorDescription)
        {
            this.Error = error;
            this.Exception = exception;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnterwellHttpException"/> class.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="httpCode">The HTTP code.</param>
        /// <param name="errorDescription">The error description.</param>
        /// <param name="exception">The exception.</param>
        public EnterwellHttpException(string error, int httpCode, string errorDescription, EnterwellException exception)
            : base(httpCode, errorDescription)
        {
            this.Error = error;
            this.Exception = exception;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnterwellException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that holds the contextual information about the source or destination.</param>
        protected EnterwellHttpException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info != null)
            {
                this.Error = info.GetString("Error");
                this.Exception = (EnterwellException)info.GetValue("Exception", typeof(EnterwellException));
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
                info.AddValue("Error", this.Error);
                info.AddValue("Exception", this.Exception);
            }

            base.GetObjectData(info, context);
        }

        /// <summary>
        /// Creates an <see cref="T:System.Net.Http.HttpResponseMessage" /> asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>
        /// A task that, when completed, contains the <see cref="T:System.Net.Http.HttpResponseMessage" />.
        /// </returns>
        Task<HttpResponseMessage> IHttpActionResult.ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage((HttpStatusCode) this.GetHttpCode());
            response.Content = new ObjectContent(typeof(System.Web.HttpException), this,
                new System.Net.Http.Formatting.JsonMediaTypeFormatter());
            return Task.FromResult(response);
        }
    }
}
