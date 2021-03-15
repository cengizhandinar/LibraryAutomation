using System.Collections.Generic;
using Library.Entities.Entities.Concrete;

namespace Library.Entities.Entities.Dtos.BookDto
{
    public class BookListDto
    {
        public IList<Book> Books { get; set; }
    }
}