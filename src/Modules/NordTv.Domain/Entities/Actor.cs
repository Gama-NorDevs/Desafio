using System;
using System.Collections.Generic;
using System.Text;

namespace NordTv.Domain.Entities
{
    public class Actor
    {
        public Actor ( double amount, 
                       char sex,
                       User user )
        {
            Amount = amount;
            Sex = sex;
            User = user;
        }

        public Actor (  int id,
                        double amount,
                        char sex,
                        User user )
        {
            SetId(id);
            Amount = amount;
            Sex = sex;
            User = user;
        }

        public int Id { get; private set; }
        public double Amount { get; private set; }
        public char Sex { get; private set; }
        public User User { get; private set; }
        public List<Work> Works { get; private set; }
        public List<Genre> Genres { get; private set; }

        public bool IsValid()
        {
            var valid = true;

            User.IsValid();
           
            if (
                string.IsNullOrEmpty(Amount.ToString()) ||
                string.IsNullOrEmpty(Sex.ToString()) 
                )
            {
                valid = false;
            }

            return valid;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
