using System;

namespace LabFlow.Domain.Protocol.Models
{
    public class Tiger : Animal
    {
        public Tiger(Guid id, string name)
        {
            Id = id;
            Name = name;
            Pleasure = 50;
        }
        // Empty constructor for EF 
        protected Tiger() { }

        public int Pleasure { get; set; }

        public void IncreaseTigerPleasure()
        {
            Pleasure += 50;
        }
    }
}
