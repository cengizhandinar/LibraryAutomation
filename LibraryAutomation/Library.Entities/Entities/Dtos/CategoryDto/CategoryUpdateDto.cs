using Library.Core.Enum;

namespace Library.Entities.Entities.Dtos.CategoryDto
{
    public class CategoryUpdateDto
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public GeneralStatus GeneralStatus { get; set; }
    }
}