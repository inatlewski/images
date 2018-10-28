namespace Images.Common
{
    public class ErrorMessage
    {
        public static readonly string GetImageException = "Unexpected error occurred when getting the image.";
        public static readonly string AddImageException = "Unexpected error occurred when adding the image.";
        public static readonly string UpdateImageException = "Unexpected error occurred when updating the image.";
        public static readonly string DeleteImageException = "Unexpected error occurred when deleting the image.";

        public static readonly string ImageNotFound = "Image was not found.";
        public static readonly string ImageIsNull = "Image model was not provided.";

        public static readonly string GetCommentException = "Unexpected error occurred when getting the comment.";
        public static readonly string AddCommentException = "Unexpected error occurred when adding the comment.";
        public static readonly string UpdateCommentException = "Unexpected error occurred when updating the comment.";
        public static readonly string DeleteCommentException = "Unexpected error occurred when deleting the comment.";

        public static readonly string CommentNotFound = "Image was not found.";
        public static readonly string CommentIsNull = "Image model was not provided.";

        public static readonly string InternalServerError = "Internal server error occurred.";
    }
}