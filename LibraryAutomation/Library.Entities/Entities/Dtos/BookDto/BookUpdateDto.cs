using System;
using Library.Core.Enum;

namespace Library.Entities.Entities.Dtos.BookDto
{
    public class BookUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int NumberOfPages { get; set; }
        public int Stock { get; set; }
        public string Place { get; set; }
        public int WriterId { get; set; }
        public int PublisherId { get; set; }
        public GeneralStatus GeneralStatus { get; set; }
    }
}