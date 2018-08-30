namespace Images.Model.DTO.Out
{
    public class CommentOutDto : AuditOutDto
    {
        public int Id { get; set; }

        public string Content { get; set; }
    }
}
