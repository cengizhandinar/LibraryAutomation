using Library.Core.Enum;

namespace Library.Entities.Entities.Dtos.PublisherDto
{
    public class PublisherUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public GeneralStatus GeneralStatus { get; set; }
    }
}