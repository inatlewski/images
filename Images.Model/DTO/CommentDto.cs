namespace Images.Model.DTO
{
    public class CommentDto : AuditDto
    {
        public int Id { get; set; }

        public string Content { get; set; }
    }
}
