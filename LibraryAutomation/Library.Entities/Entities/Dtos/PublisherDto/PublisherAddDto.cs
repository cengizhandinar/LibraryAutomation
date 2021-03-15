using Library.Core.Enum;

namespace Library.Entities.Entities.Dtos.PublisherDto
{
    public class PublisherAddDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public GeneralStatus GeneralStatus { get; set; }
    }
}