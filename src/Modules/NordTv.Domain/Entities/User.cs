using System;
using System.Collections.Generic;
using System.Text;

namespace NordTv.Domain.Entities
{
    public class User
    {
        public User (   string name,
                        string email,
                        string password,
                        string profile )
        {
            Name = name;
            Email = email;
            Password = password;
            Profile = profile;
        }

        public User (   int id,
                        string name,
                        string email,
                        string password,
                        string profile )
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Profile = profile;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Profile { get; private set; }

    }
}
