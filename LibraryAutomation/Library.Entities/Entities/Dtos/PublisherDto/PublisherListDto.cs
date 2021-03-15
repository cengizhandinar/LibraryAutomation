using System.Collections.Generic;
using Library.Entities.Entities.Concrete;

namespace Library.Entities.Entities.Dtos.PublisherDto
{
    public class PublisherListDto
    {
        public IList<Publisher> Publishers { get; set; }
    }
}