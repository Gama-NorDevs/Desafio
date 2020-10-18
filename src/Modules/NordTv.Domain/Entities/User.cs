using System;
using System.Collections.Generic;
using System.Text;

namespace NordTv.Domain.Entities
{
    public class User
    {


        public User(string name,
                        string email,
                        string password,
                        string profile)
        {
            Name = name;
            Email = email;
            Password = password;
            SetProfile(profile);
        }

        public User(int id,
                        string name,
                        string email,
                        string password,
                        string profile)
        {
            SetId(id);
            Name = name;
            Email = email;
            Password = password;
            SetProfile(profile);
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Profile { get; private set; }

        private void SetProfile(string profile)
        {
            var profiles = new[] { "ADMIN", "ACTOR" };

            Array.ForEach(profiles, item =>
            {
                if (item.Equals(profile.ToUpper()))
                {
                    Profile = profile;
                    return;
                }
            });

            if (Profile == null)
            {
                throw new ArgumentException("Profile argument not match with " + string.Join(" or ", profiles));
            }

        }

        public void SetId(int id) 
        {
            Id = id;
        }

    }
}
