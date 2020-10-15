using System;
using System.Collections.Generic;
using System.Text;

namespace NordTv.Domain.Entities
{
    public class Work
    {
        public Work ( User productor,
                      Genre genre,
                      string name,
                      double budget,
                      DateTime dateInit,
                      DateTime dateEnd
                      )
        {
            Productor = productor;
            Genre = genre;
            Name = name;
            Budget = budget;
            DateInit = dateInit;
            DateEnd = dateEnd;
        }

        public Work (   int id,
                        User productor,
                        Genre genre,
                        string name,
                        double budget,
                        DateTime dateInit,
                        DateTime dateEnd
                      )
        {
            Id = id;
            Productor = productor;
            Genre = genre;
            Name = name;
            Budget = budget;
            DateInit = dateInit;
            DateEnd = dateEnd;
        }

        public int Id { get; private set; }
        // Productor is the Admin
        public User Productor { get; private set; }
        public Genre Genre { get; private set; }
        public string Name { get; private set; }
        public double Budget { get; private set; }
        public DateTime DateInit { get; private set; }
        public DateTime DateEnd { get; private set; }
        public List<Actor> Actors { get; private set; }
    }
}
