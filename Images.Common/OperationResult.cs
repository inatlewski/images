using System.Collections.Generic;
using System.Net;

namespace Images.Common
{
    public class OperationResult
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public ICollection<string> Errors { get; set; } = new List<string>();

        public OperationResult()
        {
        }

        public OperationResult(HttpStatusCode httpStatusCode)
        {
            HttpStatusCode = httpStatusCode;
        }

        public OperationResult(ICollection<string> errors)
        {
            Errors = errors;
        }

        public OperationResult(string errorMessage)
        {
            Errors.Add(errorMessage);
        }

        public OperationResult(HttpStatusCode httpStatusCode, string errorMessage)
        {
            HttpStatusCode = httpStatusCode;
            Errors.Add(errorMessage);
        }
    }

    public class OperationResult<T> : OperationResult
    {
        public T Model { get; set; }

        public OperationResult()
        {
        }

        public OperationResult(T model, HttpStatusCode httpStatusCode) : base(httpStatusCode)
        {
            Model = model;
        }

        public OperationResult(T model, ICollection<string> errors) : base(errors)
        {
            Model = model;
        }

        public OperationResult(T model, string errorMessage) : base(errorMessage)
        {
            Model = model;
        }

        public OperationResult(T model, HttpStatusCode httpStatusCode, string errorMessage) : base(httpStatusCode, errorMessage)
        {
            Model = model;
        }

        public OperationResult(HttpStatusCode httpStatusCode, string errorMessage) : base(httpStatusCode, errorMessage)
        {
        }
    }
}