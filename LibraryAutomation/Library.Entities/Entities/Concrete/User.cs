using System;
using System.Collections.Generic;
using Library.Core.Entities.Abstract;
using Library.Core.Enum;

namespace Library.Entities.Entities.Concrete
{
    public class User : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string About { get; set; }
        public string Picture { get; set; }
        public DateTime DateBirth { get; set; }
        public AccessStatus AccessStatus { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<UserBook> UserBooks { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<FavoriteBook> FavoriteBooks { get; set; }
    }
}