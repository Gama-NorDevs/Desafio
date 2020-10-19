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
                      DateTime dateStart,
                      DateTime dateEnd,
                      List<Actor> actors
                      )
        {
            Productor = productor;
            Genre = genre;
            Name = name;
            Budget = budget;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Actors = actors;
        }

        public Work (   int id,
                        User productor,
                        Genre genre,
                        string name,
                        double budget,
                        DateTime dateStart,
                        DateTime dateEnd,
                        List<Actor> actors
                      )
        {
            Id = id;
            Productor = productor;
            Genre = genre;
            Name = name;
            Budget = budget;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Actors = actors;
        }
        public Work(int id,
                       User productor,
                       Genre genre,
                       string name,
                       double budget,
                       DateTime dateStart,
                       DateTime dateEnd
                     )
        {
            Id = id;
            Productor = productor;
            Genre = genre;
            Name = name;
            Budget = budget;
            DateStart = dateStart;
            DateEnd = dateEnd;
        }
        public int Id { get; set; }
        // Productor is the Admin
        public User Productor { get; set; }
        public Genre Genre { get; set; }
        public string Name { get; set; }
        public double Budget { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public List<Actor> Actors { get; set; }

        public bool IsValid()
        {
            var valid = true;

            Productor.IsValid();
            Genre.IsValid();

            if (
                string.IsNullOrEmpty(Name) ||
                string.IsNullOrEmpty(Budget.ToString()) ||
                string.IsNullOrEmpty(DateStart.ToString()) ||
                string.IsNullOrEmpty(DateEnd.ToString())
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
