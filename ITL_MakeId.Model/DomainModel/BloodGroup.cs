using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ITL_MakeId.Model.DomainModel
{
    public class BloodGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<IdentityCard> Models { get; set; }

        public BloodGroup()
        {
            Models = new Collection<IdentityCard>();
        }

    }
}
