using System;
using System.Collections.Generic;
using System.Text;

namespace NordTv.Application.AppActor.Input
{
    public class ActorInput
    {
        public double Amount { get; set; }
        public char Sex { get; set; }
        public int IdUser { get; set; }
        public int[] Genres { get; set; }
    }
}
