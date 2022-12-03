using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasking.Management.Domain.Interfaces;

namespace Tasking.Management.CrossCutting.ProblemDetail
{
    public static class ErrorGenerator
    {
        private static readonly string DefaultType = "https://example.com";
        /// <summary>
        /// Generate a problem details object and set the values ​​based on what was received from the interface
        /// </summary>
        /// <param name="error">Interface that contains values ​​such as title, detail and access context</param>
        /// <param name="statusCode">Status code that will be returned to the end user</param>
        /// <returns>A Problem Details object</returns>
        public static ProblemDetails GetProblemDetails(IErrorDetails error, int statusCode)
        {
            return new ProblemDetails
            {
                Type = DefaultType,
                Title = error.Title,
                Detail = error.Detail,
                Status = statusCode,
                Instance = error.ContextAccessor.HttpContext!.Request.Path
            };
        }

        /// <summary>
        /// Generate a problem details object
        /// </summary>
        /// <param name="title">title string that will be returned to the end user</param>
        /// <param name="detail">detail string that will be returned to the end user</param>
        /// <param name="statusCode">status code that will be returned to the end user</param>
        /// <param name="context">IHttpContextAccessor to access additional attributes</param>
        /// <returns>A Problem Details object</returns>
        public static ProblemDetails GetProblemDetails(string title, string detail, int statusCode, IHttpContextAccessor context)
        {
            return new ProblemDetails
            {
                Type = DefaultType,
                Title = title,
                Detail = detail,
                Status = statusCode,
                Instance = context.HttpContext!.Request.Path
            };
        }

        /// <summary>
        /// Set custom Type in current ProblemDetails object
        /// </summary>
        /// <param name="type">String containing a url to the error documentation</param>
        /// <returns>Current ProblemDetails with Type updated</returns>
        public static ProblemDetails SetType(this ProblemDetails problemDetails, string type)
        {
            problemDetails.Type = type;
            return problemDetails;
        }

        /// <summary>
        /// Set a custom extension in the current ProblemDetails object
        /// </summary>
        /// <param name="extensionName">Extension name</param>
        /// <param name="properties">Object properties</param>
        /// <returns>Current ProblemDetails with a new extension</returns>
        public static ProblemDetails SetExtension(this ProblemDetails problemDetails, string extensionName, object properties)
        {
            problemDetails.Extensions.Add(extensionName, properties);
            return problemDetails;
        }
    }
}
