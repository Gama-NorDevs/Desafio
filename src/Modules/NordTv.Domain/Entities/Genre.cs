using System;
using System.Collections.Generic;
using System.Text;

namespace NordTv.Domain.Entities
{
    public class Genre
    {
        public Genre ( string description )
        {
            Description = description;
        }

        public Genre ( int id,
                       string description )
        {
            Id = id;
            Description = description;
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public bool IsValid()
        {
            var valid = true;
           
            if (
                string.IsNullOrEmpty(Description)
                )
            {
                valid = false;
            }

            return valid;
        }
    }
}
