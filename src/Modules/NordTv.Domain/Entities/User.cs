using NordTv.Domain.Core;
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
            CriptografyPassword(password);
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
            CriptografyPassword(password);
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
                throw new ArgumentException("O argumento do perfil não corresponde a  " + string.Join(" ou ", profiles));
            }

        }

        public bool IsValid()
        {
            var valid = true;

            if (string.IsNullOrEmpty(Name) ||
                string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(Password)
                )
            {
                valid = false;
            }

            return valid;
        }

        public void CriptografyPassword(string password)
        {
            Password = PasswordHasher.Hash(password);
        }

        public bool IsEqualPassword(string password)
        {
            return PasswordHasher.Verify(password, Password);
        }

        public void InformationEmailUser(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public void SetId(int id) 
        {
            Id = id;
        }

    }
}
