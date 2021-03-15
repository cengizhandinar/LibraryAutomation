using System.Collections.Generic;
using Library.Core.Entities.Abstract;
using Library.Core.Enum;

namespace Library.Entities.Entities.Concrete
{
    public class Publisher : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public GeneralStatus GeneralStatus { get; set; } = GeneralStatus.Active;

        public ICollection<Book> Books { get; set; }
    }
}