using System.Collections.Generic;
using Library.Core.Entities.Abstract;
using Library.Core.Enum;

namespace Library.Entities.Entities.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public GeneralStatus GeneralStatus { get; set; } = GeneralStatus.Active;

        public ICollection<BookCategory> BookCategories { get; set; }
    }
}