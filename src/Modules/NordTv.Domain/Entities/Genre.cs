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

        public int Id { get; private set; }
        public string Description { get; private set; }
    }
}
