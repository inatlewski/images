using System;
using System.Net;
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

        public OperationResult<CommentOutDto> GetComment(int commentId)
        {
            try
            {
                var comment = _commentRepository.FindByKey(commentId);

                if (comment == null)
                {
                    return new OperationResult<CommentOutDto>(HttpStatusCode.NotFound, ErrorMessage.CommentNotFound);
                }

                var commentDto = Mapper.Map<CommentOutDto>(comment);

                return new OperationResult<CommentOutDto>(commentDto, HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                _logger.Error(e, ErrorMessage.GetCommentException);

                return new OperationResult<CommentOutDto>(HttpStatusCode.InternalServerError, ErrorMessage.GetCommentException);
            }
        }

        public OperationResult<CommentOutDto> AddComment(int imageId, CommentInDto commentDto)
        {
            try
            {
                if (commentDto == null)
                {
                    return new OperationResult<CommentOutDto>(HttpStatusCode.BadRequest, ErrorMessage.CommentIsNull);
                }

                var commentToAdd = Mapper.Map<Comment>(commentDto);
                var addedComment = _commentRepository.Add(commentToAdd);
                var commentOutDto = Mapper.Map<CommentOutDto>(addedComment);

                return new OperationResult<CommentOutDto>(commentOutDto, HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                _logger.Error(e, ErrorMessage.AddCommentException);

                return new OperationResult<CommentOutDto>(HttpStatusCode.InternalServerError, ErrorMessage.AddCommentException);
            }
        }

        public OperationResult<CommentOutDto> UpdateComment(UpdateCommentInDto commentDto)
        {
            try
            {
                if (commentDto == null)
                {
                    return new OperationResult<CommentOutDto>(HttpStatusCode.BadRequest, ErrorMessage.CommentIsNull);
                }

                var comment = _commentRepository.FindByKey(commentDto.Id);

                if (comment == null)
                {
                    return new OperationResult<CommentOutDto>(HttpStatusCode.NotFound, ErrorMessage.CommentNotFound);
                }

                Mapper.Map(commentDto, comment);
                var updatedComment = _commentRepository.Update(comment);
                var commentOutDto = Mapper.Map<CommentOutDto>(updatedComment);

                return new OperationResult<CommentOutDto>(commentOutDto, HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                _logger.Error(e, ErrorMessage.UpdateCommentException);

                return new OperationResult<CommentOutDto>(HttpStatusCode.InternalServerError, ErrorMessage.UpdateCommentException);
            }
        }

        public OperationResult<bool> DeleteComment(int commentId)
        {
            try
            {
                var comment = _commentRepository.FindByKey(commentId);

                if (comment == null)
                {
                    return new OperationResult<bool>(HttpStatusCode.NotFound, ErrorMessage.CommentNotFound);
                }

                _commentRepository.Delete(comment);

                return new OperationResult<bool>(true, HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                _logger.Error(e, ErrorMessage.DeleteCommentException);

                return new OperationResult<bool>(HttpStatusCode.InternalServerError, ErrorMessage.DeleteCommentException);
            }
        }
    }
}
