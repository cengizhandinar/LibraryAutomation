using System;
using Library.Core.Entities.Abstract;
using Library.Core.Enum;

namespace Library.Entities.Entities.Concrete
{
    public class UserBook : IEntity
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public BookStatus BookStatus { get; set; }
        public DateTime LendDate { get; set; }
        public DateTime? ReceiveDate { get; set; }
    }
}