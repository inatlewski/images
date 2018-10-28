using System.Net;
using Images.BusinessLogic.Interfaces;
using Images.Model.DTO.In;
using Images.Model.DTO.Out;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Images.Web.Controllers
{
    /// <summary>
    /// Represents controller with operations related to the images.
    /// </summary>
    public class ImageController : BaseController
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService, ILogger logger) : base(logger)
        {
            _imageService = imageService;
        }

        [HttpGet("{imageId:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult<ImageOutDto> GetImage(int imageId)
        {
            var operationResult = _imageService.GetImage(imageId);
            var actionResult = HandleOperationResult(operationResult);
            return actionResult;
        }

        [HttpPatch("{imageId:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult<ImageOutDto> UpdateImage(int imageId, [FromBody] UpdateImageInDto imageDto)
        {
            //todo
            imageDto.Id = imageId;
            var operationResult = _imageService.UpdateImage(imageDto);
            var actionResult = HandleOperationResult(operationResult);
            return actionResult;
        }

        [HttpDelete("{imageId:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult DeleteImage(int imageId)
        {
            var operationResult = _imageService.DeleteImage(imageId);
            var actionResult = HandleOperationResult(operationResult);
            return actionResult;
        }
    }
}