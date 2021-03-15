using Library.Core.Enum;

namespace Library.Entities.Entities.Dtos.ContactDto
{
    public class ContactAddDto
    {
        public int UserId { get; set; }
        public string Content { get; set; }
        public GeneralStatus GeneralStatus { get; set; }
    }
}