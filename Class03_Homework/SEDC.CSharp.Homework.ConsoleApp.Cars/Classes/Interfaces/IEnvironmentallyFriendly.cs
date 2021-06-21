using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Interfaces
{
    public interface IEnvironmentallyFriendly
    {
        public bool IsHarmful { get; set; }
        public void HarmsTheEnviroment();
    }
}
