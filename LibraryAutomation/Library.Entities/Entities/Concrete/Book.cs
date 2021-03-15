using System;
using System.Collections.Generic;
using Library.Core.Entities.Abstract;

namespace Library.Entities.Entities.Concrete
{
    public class Book : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int NumberOfPages { get; set; }
        public int Stock { get; set; }
        public string Place { get; set; }

        public int NumberOfFavorites { get; set; } = 0;
        public int NumberOfReads { get; set; } = 0;
        public int NumberOfComments { get; set; } = 0;
        public decimal RatingAverage { get; set; } = 0;

        public int WriterId { get; set; }
        public Writer Writer { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public ICollection<UserBook> UserBooks { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
        public ICollection<FavoriteBook> FavoriteBooks { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}