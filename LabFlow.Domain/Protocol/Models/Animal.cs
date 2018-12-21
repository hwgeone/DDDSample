using LabFlow.Domain.Core.Models;

namespace LabFlow.Domain.Protocol.Models
{
    public abstract class Animal:Entity
    {
        protected Animal() { }
        public string Name { get; set; }
    }
}
