using System.Collections.Generic;
using Library.Entities.Entities.Concrete;

namespace Library.Entities.Entities.Dtos.UserBookDto
{
    public class UserBookListDto
    {
        public IList<UserBook> UserBooks { get; set; }
    }
}