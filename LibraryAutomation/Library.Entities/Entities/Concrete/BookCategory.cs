using Library.Core.Entities.Abstract;

namespace Library.Entities.Entities.Concrete
{
    public class BookCategory : IEntity
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}