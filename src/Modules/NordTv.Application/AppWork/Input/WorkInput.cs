using NordTv.Domain.Entities;
using System;
using System.Collections.Generic;

namespace NordTv.Application.AppWork.Input
{
    public class WorkInput
    {
        public int Productor_Id { get; set; }
        public int Genre_Id { get; set; }
        public string Name { get; set; }
        public double Budget { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int[] Actors { get; set; }
    }
}
