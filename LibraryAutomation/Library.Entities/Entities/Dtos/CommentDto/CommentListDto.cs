using System.Collections.Generic;
using Library.Entities.Entities.Concrete;

namespace Library.Entities.Entities.Dtos.CommentDto
{
    public class CommentListDto
    {
        public IList<Comment> Comments { get; set; }
    }
}