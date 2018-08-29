namespace Images.Model.Entities
{
    public class Comment : BaseEntity
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public Image Image { get; set; }
    }
}
