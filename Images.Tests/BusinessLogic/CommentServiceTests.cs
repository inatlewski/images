using System;
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
        public void GetComment_ShouldReturnCommentFromRepository_WhenCommentExists()
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
            result.Id.Should().Be(commentId);
            _commentRepository.Received().FindByKey(commentId);
        }

        [Fact]
        public void GetComment_ShouldReturnNull_WhenCommentDoesNotExist()
        {
            // Arrange
            var commentId = 1;
            _commentRepository.FindByKey(commentId).ReturnsNull();

            // Act
            var result = _commentService.GetComment(commentId);

            //Assert
            result.Should().BeNull();
            _commentRepository.Received().FindByKey(commentId);
        }

        [Fact]
        public void GetComment_ShouldLogExceptionAndReturnNull_WhenExceptionWasThrown()
        {
            // Arrange
            var commentId = 1;
            var exception = new Exception();
            _commentRepository.When(r => r.FindByKey(commentId)).Do(x => throw exception);

            // Act
            var result = _commentService.GetComment(commentId);

            //Assert
            result.Should().BeNull();
            _logger.Received().Error(exception, ErrorMessages.GetCommentExceptionMessage);
        }
        #endregion

        #region AddComment
        [Fact]
        public void AddComment_ShouldAddCommentToRepositoryAndReturnTrue_WhenModelIsNotNull()
        {
            // Arrange
            var commentDto = new CommentInDto();

            // Act
            var result = _commentService.AddComment(commentDto);

            //Assert
            result.Should().BeTrue();
            _commentRepository.Received(1).Add(Arg.Any<Comment>());
        }

        [Fact]
        public void AddComment_ShouldReturnFalse_WhenModelIsNull()
        {
            // Arrange
            CommentInDto commentDto = null;

            // Act
            var result = _commentService.AddComment(commentDto);

            //Assert
            result.Should().BeFalse();
            _commentRepository.DidNotReceive().Update(Arg.Any<Comment>());
        }

        [Fact]
        public void AddComment_ShouldLogExceptionAndReturnFalse_WhenExceptionWasThrown()
        {
            // Arrange
            var commentDto = new CommentInDto();
            var exception = new Exception();
            _commentRepository.When(r => r.Add(Arg.Any<Comment>())).Do(x => throw exception);

            // Act
            var result = _commentService.AddComment(commentDto);

            //Assert
            result.Should().BeFalse();
            _logger.Received().Error(exception, ErrorMessages.AddCommentExceptionMessage);
        }
        #endregion

        #region UpdateComment
        [Fact]
        public void UpdateComment_ShouldUpdateCommentInRepositoryAndReturnTrue_WhenCommentExists()
        {
            // Arrange
            var commentDto = new UpdateCommentInDto
            {
                Id = 1
            };
            var comment = new Comment();
            _commentRepository.FindByKey(commentDto.Id).Returns(comment);

            // Act
            var result = _commentService.UpdateComment(commentDto);

            //Assert
            result.Should().BeTrue();
            _commentRepository.Received(1).Update(comment);
        }

        [Fact]
        public void UpdateComment_ShouldNotUpdateAnyCommentInRepositoryAndReturnFalse_WhenModelIsNull()
        {
            // Arrange
            UpdateCommentInDto commentDto = null;

            // Act
            var result = _commentService.UpdateComment(commentDto);

            //Assert
            result.Should().BeFalse();
            _commentRepository.DidNotReceive().Update(Arg.Any<Comment>());
        }

        [Fact]
        public void UpdateComment_ShouldNotUpdateAnyCommentInRepositoryAndReturnFalse_WhenCommentDoesNotExist()
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
            result.Should().BeFalse();
            _commentRepository.Received(1).FindByKey(commentDto.Id);
            _commentRepository.DidNotReceive().Update(Arg.Any<Comment>());
        }

        [Fact]
        public void UpdateComment_ShouldLogExceptionAndReturnFalse_WhenExceptionWasThrown()
        {
            // Arrange
            var commentDto = new UpdateCommentInDto
            {
                Id = 1
            };
            var comment = new Comment();
            var exception = new Exception();
            _commentRepository.FindByKey(commentDto.Id).Returns(comment);
            _commentRepository.When(r => r.Update(Arg.Any<Comment>())).Do(x => throw exception);

            // Act
            var result = _commentService.UpdateComment(commentDto);

            //Assert
            result.Should().BeFalse();
            _logger.Received().Error(exception, ErrorMessages.UpdateCommentExceptionMessage);
        }
        #endregion

        #region DeleteComment
        [Fact]
        public void DeleteComment_ShouldDeleteCommentFromRepositoryAndReturnTrue_WhenCommentExists()
        {
            // Arrange
            var commentId = 1;
            var comment = new Comment();
            _commentRepository.FindByKey(commentId).Returns(comment);

            // Act
            var result = _commentService.DeleteComment(commentId);

            //Assert
            result.Should().BeTrue();
            _commentRepository.Received().FindByKey(commentId);
            _commentRepository.Received().Delete(comment);
        }

        [Fact]
        public void DeleteComment_ShouldNotDeleteAnyCommentFromRepositoryAndReturnFalse_WhenCommentDoesNotExist()
        {
            // Arrange
            var commentId = 1;
            _commentRepository.FindByKey(commentId).ReturnsNull();

            // Act
            var result = _commentService.DeleteComment(commentId);

            //Assert
            result.Should().BeFalse();
            _commentRepository.Received().FindByKey(commentId);
            _commentRepository.DidNotReceive().Delete(Arg.Any<Comment>());
        }

        [Fact]
        public void DeleteComment_ShouldLogExceptionAndReturnFalse_WhenExceptionWasThrown()
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
            result.Should().BeFalse();
            _logger.Received().Error(exception, ErrorMessages.DeleteCommentExceptionMessage);
        } 
        #endregion
    }
}