using System.Collections.Generic;
using Library.Entities.Entities.Concrete;

namespace Library.Entities.Entities.Dtos.WriterDto
{
    public class WriterListDto
    {
        public IList<Writer> Writers { get; set; }
    }
}