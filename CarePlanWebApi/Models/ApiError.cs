using System.Net;
using System.Text.Json.Serialization;

namespace CarePlanWebApi.Models
{
    /// <summary>
    ///  Base class for the Api error types
    /// </summary>
    public class ApiError
    {
        #region - Fields -

        /// <summary>
        /// Gets the status code.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        [JsonPropertyName("status_code")]
        public int StatusCode { get; private set; }

        /// <summary>
        /// Gets the status description.
        /// </summary>
        /// <value>
        /// The status description.
        /// </value>
        [JsonPropertyName("status_description")]
        public string StatusDescription { get; private set; }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        [JsonPropertyName("error")]
        public ApiErrorMessage ErrorMessage { get; private set; }

        #endregion - Fields -

        #region - Constructors and initializers -

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiError"/> class.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="statusDescription">The status description.</param>
        public ApiError(int statusCode, string statusDescription)
        {
            this.StatusCode = statusCode;
            this.StatusDescription = statusDescription;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiError" /> class.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="statusDescription">The status description.</param>
        /// <param name="message">The message.</param>
        public ApiError(int statusCode, string statusDescription, ApiErrorMessage message)
            : this(statusCode, statusDescription)
        {
            this.ErrorMessage = message;
        }

        #endregion - Constructors and initializers -
    }

    /// <summary>
    /// Custom error for Status code 500 [InternalServerError]
    /// </summary>
    /// <seealso cref="CarePlanWebApi.Models.ApiError" />
    public class InternalServerError : ApiError
    {
        #region - Constructors and initializers -

        /// <summary>
        /// Initializes a new instance of the <see cref="InternalServerError"/> class.
        /// </summary>
        public InternalServerError()
            : base((int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString())
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="InternalServerError" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public InternalServerError(ApiErrorMessage message)
            : base((int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), message)
        {
        }

        #endregion - Constructors and initializers -
    }

    /// <summary>
    /// Custom error for Status code 404 [NotFound]
    /// </summary>
    /// <seealso cref="CarePlanWebApi.Models.ApiError" />
    public class NotFoundError : ApiError
    {
        #region - Constructors and initializers -

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundError"/> class.
        /// </summary>
        public NotFoundError()
            : base((int)HttpStatusCode.NotFound, HttpStatusCode.NotFound.ToString())
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundError" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public NotFoundError(ApiErrorMessage message)
            : base((int)HttpStatusCode.NotFound, HttpStatusCode.NotFound.ToString(), message)
        {
        }

        #endregion - Constructors and initializers -
    }

    /// <summary>
    /// Custom error for Status code 400 [BadRequest]
    /// </summary>
    /// <seealso cref="CarePlanWebApi.Models.ApiError" />
    public class BadRequestError : ApiError
    {
        #region - Constructors and initializers -

        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestError"/> class.
        /// </summary>
        public BadRequestError()
            : base((int)HttpStatusCode.BadRequest, HttpStatusCode.BadRequest.ToString())
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestError" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public BadRequestError(ApiErrorMessage message)
            : base((int)HttpStatusCode.BadRequest, HttpStatusCode.BadRequest.ToString(), message)
        {
        }

        #endregion - Constructors and initializers -
    }
}
