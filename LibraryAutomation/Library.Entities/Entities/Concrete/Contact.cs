using Library.Core.Entities.Abstract;

namespace Library.Entities.Entities.Concrete
{
    public class Contact : EntityBase
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
    }
}