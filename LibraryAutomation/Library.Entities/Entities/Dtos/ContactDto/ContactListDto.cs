using System.Collections.Generic;
using Library.Entities.Entities.Concrete;

namespace Library.Entities.Entities.Dtos.ContactDto
{
    public class ContactListDto
    {
        public IList<Contact> Contacts { get; set; }
    }
}