using Images.BusinessLogic.Interfaces;
using Images.DataAccess.Interfaces;
using Images.Model.DTO.In;
using Images.Model.DTO.Out;
using Images.Model.Entities;

namespace Images.BusinessLogic.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> _commenRepository;

        public CommentService(IRepository<Comment> commenRepository)
        {
            _commenRepository = commenRepository;
        }

        public CommentOutDto GetComment(int commentId)
        {
            throw new System.NotImplementedException();
        }

        public bool AddComment(CommentInDto commentDto)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateComment(UpdateCommentInDto commentDto)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteComment(int commentId)
        {
            throw new System.NotImplementedException();
        }
    }
}
