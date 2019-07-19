using System;
using System.Collections.Generic;
using System.Text;

namespace CnsApp30_Ex10Queries.Classes
{
    class OwnerSFarms
    {
        public string Name { get; set; }
        public List<Farm> OwnedFarms { get; set; }

        public OwnerSFarms() { }

        public OwnerSFarms(string ownerSName, List<Farm> ownedFarms)
        {
            Name = ownerSName;
            OwnedFarms = ownedFarms;
        }
    }
}