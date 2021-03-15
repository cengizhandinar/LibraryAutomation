using System.Collections.Generic;
using Library.Entities.Entities.Concrete;

namespace Library.Entities.Entities.Dtos.FavoriteBookDto
{
    public class FavoriteBookListDto
    {
        public IList<FavoriteBook> FavoriteBooks { get; set; }
    }
}