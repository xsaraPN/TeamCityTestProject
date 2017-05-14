using System;

namespace Registration.Models
{
    public class RegistrationUser
    {

        public string Key { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int[] MatrialStatus { get; set; }

        public int[] Hobby { get; set; }

        public string Country { get; set; }

        public string BirthMonth { get; set; }

        public string BirthDay { get; set; }

        public string BirthYear { get; set; }

        public string Phone { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string UploadPicDir { get; set; }

        public string Description { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
        
    }
}
