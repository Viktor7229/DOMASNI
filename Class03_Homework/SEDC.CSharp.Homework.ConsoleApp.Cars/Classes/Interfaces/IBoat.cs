using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Interfaces
{
    public interface IBoat
    {
        public BoatTypes TypeOfBoat { get; set; }
    }
}
