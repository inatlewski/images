using System.Net;
using AutoMapper;
using Images.Common;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Images.Web.Controllers
{
    [Route("/api/[controller]")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public class BaseController : Controller
    {
        private readonly ILogger _logger;

        public BaseController(ILogger logger)
        {
            _logger = logger;
        }

        public ActionResult HandleOperationResult<T>(OperationResult<T> operationResult)
        {
            if (operationResult == null)
            {
                _logger.Fatal("Operation result is null.");

                return new ObjectResult(ErrorMessage.InternalServerError)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }

            var objectResult = Mapper.Map<ObjectResult>(operationResult);

            return objectResult;
        }
    }
}