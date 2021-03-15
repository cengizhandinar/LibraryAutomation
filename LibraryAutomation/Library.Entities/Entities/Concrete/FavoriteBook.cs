using Library.Core.Entities.Abstract;

namespace Library.Entities.Entities.Concrete
{
    public class FavoriteBook : IEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}