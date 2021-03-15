namespace Library.Entities.Entities.Dtos.CommentDto
{
    public class CommentUpdateDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CommentText { get; set; }
        public decimal Rating { get; set; }
    }
}