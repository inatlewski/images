using System;
using System.Net;
using FluentAssertions;
using Images.BusinessLogic.Implementations;
using Images.BusinessLogic.Interfaces;
using Images.Common;
using Images.DataAccess.Interfaces;
using Images.Model.DTO.In;
using Images.Model.Entities;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Serilog;
using Xunit;

namespace Images.Tests.BusinessLogic
{
    public class CommentServiceTests : BaseTest
    {
        private readonly ICommentService _commentService;
        private readonly IRepository<Comment> _commentRepository;
        private readonly ILogger _logger;

        public CommentServiceTests()
        {
            _commentRepository = Substitute.For<IRepository<Comment>>();
            _logger = Substitute.For<ILogger>();
            _commentService= new CommentService(_commentRepository, _logger);
        }

        #region GetComment
        [Fact]
        public void GetComment_ShouldReturnCommentFromRepositoryWithOkStatus_WhenCommentExists()
        {
            // Arrange
            var commentId = 1;
            var comment = new Comment
            {
                Id = commentId
            };
            _commentRepository.FindByKey(commentId).Returns(comment);

            // Act
            var result = _commentService.GetComment(commentId);

            //Assert
            result.Model.Id.Should().Be(commentId);
            result.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeEmpty();
            _commentRepository.Received().FindByKey(commentId);
        }

        [Fact]
        public void GetComment_ShouldReturnNullWithNotFoundStatus_WhenCommentDoesNotExist()
        {
            // Arrange
            var commentId = 1;
            _commentRepository.FindByKey(commentId).ReturnsNull();

            // Act
            var result = _commentService.GetComment(commentId);

            //Assert
            result.Model.Should().BeNull();
            result.HttpStatusCode.Should().Be(HttpStatusCode.NotFound);
            result.Errors.Should().Contain(ErrorMessage.CommentNotFound);
            _commentRepository.Received().FindByKey(commentId);
        }

        [Fact]
        public void GetComment_ShouldLogExceptionAndReturnNullWithInternalServerErrorStatus_WhenExceptionWasThrown()
        {
            // Arrange
            var commentId = 1;
            var exception = new Exception();
            _commentRepository.When(r => r.FindByKey(commentId)).Do(x => throw exception);

            // Act
            var result = _commentService.GetComment(commentId);

            //Assert
            result.Model.Should().BeNull();
            result.HttpStatusCode.Should().Be(HttpStatusCode.InternalServerError);
            result.Errors.Should().Contain(ErrorMessage.GetCommentException);
            _logger.Received().Error(exception, ErrorMessage.GetCommentException);
        }
        #endregion

        #region AddComment
        [Fact]
        public void AddComment_ShouldAddCommentToRepositoryAndReturnCommentWithCreatedStatus_WhenModelIsNotNull()
        {
            // Arrange
            var imageId = 1;
            var commentDto = new CommentInDto();
            var newCommentId = 1;
            _commentRepository.Add(Arg.Any<Comment>()).Returns(call =>
            {
                var comment = call.Arg<Comment>();
                comment.Id = newCommentId;
                return comment;
            });

            // Act
            var result = _commentService.AddComment(imageId, commentDto);

            //Assert
            result.Model.Id.Should().Be(newCommentId);
            result.HttpStatusCode.Should().Be(HttpStatusCode.Created);
            result.Errors.Should().BeEmpty();
            _commentRepository.Received(1).Add(Arg.Any<Comment>());
        }

        [Fact]
        public void AddComment_ShouldReturnNullWithBadRequestStatus_WhenModelIsNull()
        {
            // Arrange
            var imageId = 1;
            CommentInDto commentDto = null;

            // Act
            var result = _commentService.AddComment(imageId, commentDto);

            //Assert
            result.Model.Should().BeNull();
            result.HttpStatusCode.Should().Be(HttpStatusCode.BadRequest);
            result.Errors.Should().Contain(ErrorMessage.CommentIsNull);
            _commentRepository.DidNotReceive().Update(Arg.Any<Comment>());
        }

        [Fact]
        public void AddComment_ShouldLogExceptionAndReturnNullWithInternalServerErrorStatus_WhenExceptionWasThrown()
        {
            // Arrange
            var imageId = 1;
            var commentDto = new CommentInDto();
            var exception = new Exception();
            _commentRepository.When(r => r.Add(Arg.Any<Comment>())).Do(x => throw exception);

            // Act
            var result = _commentService.AddComment(imageId, commentDto);

            //Assert
            result.Model.Should().BeNull();
            result.HttpStatusCode.Should().Be(HttpStatusCode.InternalServerError);
            result.Errors.Should().Contain(ErrorMessage.AddCommentException);
            
            
            _logger.Received().Error(exception, ErrorMessage.AddCommentException);
        }
        #endregion

        #region UpdateComment
        [Fact]
        public void UpdateComment_ShouldUpdateCommentInRepositoryAndReturnCommentWithOkStatus_WhenCommentExists()
        {
            // Arrange
            var commentId = 1;
            var commentDto = new UpdateCommentInDto
            {
                Id = commentId
            };
            var comment = new Comment
            {
                Id = commentId
            };
            _commentRepository.FindByKey(commentDto.Id).Returns(comment);
            _commentRepository.Update(Arg.Any<Comment>()).Returns(call => call.Arg<Comment>());

            // Act
            var result = _commentService.UpdateComment(commentDto);

            //Assert
            result.Model.Id.Should().Be(commentId);
            result.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeEmpty();
            _commentRepository.Received(1).Update(comment);
        }

        [Fact]
        public void UpdateComment_ShouldNotUpdateAnyCommentInRepositoryAndReturnNullWithBadRequestStatus_WhenModelIsNull()
        {
            // Arrange
            UpdateCommentInDto commentDto = null;

            // Act
            var result = _commentService.UpdateComment(commentDto);

            //Assert
            result.Model.Should().BeNull();
            result.HttpStatusCode.Should().Be(HttpStatusCode.BadRequest);
            result.Errors.Should().Contain(ErrorMessage.CommentIsNull);
            _commentRepository.DidNotReceive().Update(Arg.Any<Comment>());
        }

        [Fact]
        public void UpdateComment_ShouldNotUpdateAnyCommentInRepositoryAndReturnNullWithNotFoundStatus_WhenCommentDoesNotExist()
        {
            // Arrange
            var commentDto = new UpdateCommentInDto
            {
                Id = 1
            };
            _commentRepository.FindByKey(commentDto.Id).ReturnsNull();

            // Act
            var result = _commentService.UpdateComment(commentDto);

            //Assert
            result.Model.Should().BeNull();
            result.HttpStatusCode.Should().Be(HttpStatusCode.NotFound);
            result.Errors.Should().Contain(ErrorMessage.CommentNotFound);
            _commentRepository.Received(1).FindByKey(commentDto.Id);
            _commentRepository.DidNotReceive().Update(Arg.Any<Comment>());
        }

        [Fact]
        public void UpdateComment_ShouldLogExceptionAndReturnNullWithInternalServerErrorStatus_WhenExceptionWasThrown()
        {
            // Arrange
            var commentId = 1;
            var commentDto = new UpdateCommentInDto
            {
                Id = commentId
            };
            var comment = new Comment();
            var exception = new Exception();
            _commentRepository.FindByKey(commentDto.Id).Returns(comment);
            _commentRepository.When(r => r.Update(Arg.Any<Comment>())).Do(x => throw exception);

            // Act
            var result = _commentService.UpdateComment(commentDto);

            //Assert
            result.Model.Should().BeNull();
            result.HttpStatusCode.Should().Be(HttpStatusCode.InternalServerError);
            result.Errors.Should().Contain(ErrorMessage.UpdateCommentException);
            _logger.Received().Error(exception, ErrorMessage.UpdateCommentException);
        }
        #endregion

        #region DeleteComment
        [Fact]
        public void DeleteComment_ShouldDeleteCommentFromRepositoryAndReturnTrueWithOkStatus_WhenCommentExists()
        {
            // Arrange
            var commentId = 1;
            var comment = new Comment();
            _commentRepository.FindByKey(commentId).Returns(comment);

            // Act
            var result = _commentService.DeleteComment(commentId);

            //Assert
            result.Model.Should().BeTrue();
            result.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeEmpty();
            _commentRepository.Received().FindByKey(commentId);
            _commentRepository.Received().Delete(comment);
        }

        [Fact]
        public void DeleteComment_ShouldNotDeleteAnyCommentFromRepositoryAndReturnFalseWithNotFoundStatus_WhenCommentDoesNotExist()
        {
            // Arrange
            var commentId = 1;
            _commentRepository.FindByKey(commentId).ReturnsNull();

            // Act
            var result = _commentService.DeleteComment(commentId);

            //Assert
            result.Model.Should().BeFalse();
            result.HttpStatusCode.Should().Be(HttpStatusCode.NotFound);
            result.Errors.Should().Contain(ErrorMessage.CommentNotFound);
            _commentRepository.Received().FindByKey(commentId);
            _commentRepository.DidNotReceive().Delete(Arg.Any<Comment>());
        }

        [Fact]
        public void DeleteComment_ShouldLogExceptionAndReturnFalseWithInternalServerErrorStatus_WhenExceptionWasThrown()
        {
            // Arrange
            var commentId = 1;
            var comment = new Comment();
            var exception = new Exception();
            _commentRepository.FindByKey(commentId).Returns(comment);
            _commentRepository.When(r => r.Delete(Arg.Any<Comment>())).Do(x => throw exception);

            // Act
            var result = _commentService.DeleteComment(commentId);

            //Assert
            result.Model.Should().BeFalse();
            result.HttpStatusCode.Should().Be(HttpStatusCode.InternalServerError);
            result.Errors.Should().Contain(ErrorMessage.DeleteCommentException);
            _logger.Received().Error(exception, ErrorMessage.DeleteCommentException);
        } 
        #endregion
    }
}