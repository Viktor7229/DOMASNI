using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Interfaces
{
    public interface IVan
    {
        public bool IsAvailable { get; set; }
        public float TrunkArea { get; set; }
        public void IsTransporting();
    }
}
