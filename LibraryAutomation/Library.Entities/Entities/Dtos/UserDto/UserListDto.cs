using System.Collections.Generic;
using Library.Entities.Entities.Concrete;

namespace Library.Entities.Entities.Dtos.UserDto
{
    public class UserListDto
    {
        public IList<User> Users { get; set; }
    }
}