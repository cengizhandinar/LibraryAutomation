using System;
using Library.Core.Enum;

namespace Library.Entities.Entities.Dtos.UserDto
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string About { get; set; }
        public string Picture { get; set; }
        public DateTime DateBirth { get; set; }
        public AccessStatus AccessStatus { get; set; }
        public GeneralStatus GeneralStatus { get; set; }
    }
}