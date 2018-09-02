using Images.Model.DTO.In;
using Images.Model.DTO.Out;

namespace Images.BusinessLogic.Interfaces
{
    public interface ICommentService
    {
        CommentOutDto GetComment(int commentId);

        bool AddComment(CommentInDto commentDto);

        bool UpdateComment(UpdateCommentInDto commentDto);

        bool DeleteComment(int commentId);
    }
}