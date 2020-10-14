using System;
using System.Collections.Generic;
using System.Text;

namespace NordTv.Domain.Entities
{
    public class People
    {
        public People()
        {

        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        
    }
}
