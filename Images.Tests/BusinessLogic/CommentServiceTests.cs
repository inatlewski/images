using FluentAssertions;
using Images.BusinessLogic.Implementations;
using Images.BusinessLogic.Interfaces;
using Images.DataAccess.Interfaces;
using Images.Model.DTO.In;
using Images.Model.Entities;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Images.Tests.BusinessLogic
{
    public class CommentServiceTests : BaseTest
    {
        private readonly ICommentService _commentService;
        private readonly IRepository<Comment> _commentRepository;

        public CommentServiceTests()
        {
            _commentRepository = Substitute.For<IRepository<Comment>>();
            _commentService= new CommentService(_commentRepository); 
        }

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
        public void AddComment_ShouldAddCommentToRepositoryAndReturnTrue_WhenModelIsNotNull()
        {
            // Arrange
            var commentDto = new CommentInDto();

            // Act
            var result =_commentService.AddComment(commentDto);

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
            _commentRepository.Received(1).FindByKey();
            _commentRepository.DidNotReceive().Update(Arg.Any<Comment>());
        }

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
    }
}