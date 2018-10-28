using Images.Common;
using Images.Model.DTO.In;
using Images.Model.DTO.Out;

namespace Images.BusinessLogic.Interfaces
{
    public interface ICommentService
    {
        OperationResult<CommentOutDto> GetComment(int commentId);

        OperationResult<CommentOutDto> AddComment(int imageId, CommentInDto commentDto);

        OperationResult<CommentOutDto> UpdateComment(UpdateCommentInDto commentDto);

        OperationResult<bool> DeleteComment(int commentId);
    }
}