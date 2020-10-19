using System;
using System.Collections.Generic;
using System.Text;

namespace NordTv.Application.AppUser.Output
{
    public class UserViewModel
    {
        public UserViewModel(int id,
                                string email,
                                string name,
                                string profile)
        {
            Id = id;
            Email = email;
            Name = name;
            Profile = profile;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Profile { get; set; }
    }
}
