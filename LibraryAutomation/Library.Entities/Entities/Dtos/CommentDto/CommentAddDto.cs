namespace Library.Entities.Entities.Dtos.CommentDto
{
    public class CommentAddDto
    {
        public int UserId { get; set; }
        public string CommentText { get; set; }
        public int BookId { get; set; }
        public decimal Rating { get; set; }
    }
}