using System.Collections.Generic;
using Library.Entities.Entities.Concrete;

namespace Library.Entities.Entities.Dtos.CategoryDto
{
    public class CategoryListDto
    {
        public IList<Category> Categories { get; set; }
    }
}