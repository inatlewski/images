using System;
using AutoMapper;
using Images.BusinessLogic.Interfaces;
using Images.Common;
using Images.DataAccess.Interfaces;
using Images.Model.DTO.In;
using Images.Model.DTO.Out;
using Images.Model.Entities;
using Serilog;

namespace Images.BusinessLogic.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> _commentRepository;
        private readonly ILogger _logger;

        public CommentService(IRepository<Comment> commentRepository, ILogger logger)
        {
            _commentRepository = commentRepository;
            _logger = logger;
        }

        public CommentOutDto GetComment(int commentId)
        {
            try
            {
                var comment = _commentRepository.FindByKey(commentId);

                if (comment == null)
                {
                    return null;
                }

                var commentDto = Mapper.Map<CommentOutDto>(comment);

                return commentDto;
            }
            catch (Exception e)
            {
                _logger.Error(e, ErrorMessages.GetCommentExceptionMessage);

                return null;
            }
        }

        public bool AddComment(CommentInDto commentDto)
        {
            try
            {
                if (commentDto == null)
                {
                    return false;
                }

                var comment = Mapper.Map<Comment>(commentDto);
                _commentRepository.Add(comment);

                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e, ErrorMessages.AddCommentExceptionMessage);

                return false;
            }
        }

        public bool UpdateComment(UpdateCommentInDto commentDto)
        {
            try
            {
                if (commentDto == null)
                {
                    return false;
                }

                var comment = _commentRepository.FindByKey(commentDto.Id);

                if (comment == null)
                {
                    return false;
                }

                Mapper.Map(commentDto, comment);
                _commentRepository.Update(comment);

                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e, ErrorMessages.UpdateCommentExceptionMessage);

                return false;
            }
        }

        public bool DeleteComment(int commentId)
        {
            try
            {
                var comment = _commentRepository.FindByKey(commentId);

                if (comment == null)
                {
                    return false;
                }

                _commentRepository.Delete(comment);

                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e, ErrorMessages.DeleteCommentExceptionMessage);

                return false;
            }
        }
    }
}
