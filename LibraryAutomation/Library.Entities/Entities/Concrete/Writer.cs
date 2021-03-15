using System;
using System.Collections.Generic;
using Library.Core.Entities.Abstract;
using Library.Core.Enum;

namespace Library.Entities.Entities.Concrete
{
    public class Writer : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public string Picture { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NumberOfBooks { get; set; } = 0;
        public GeneralStatus GeneralStatus { get; set; } = GeneralStatus.Active;

        public ICollection<Book> Books { get; set; }
    }
}