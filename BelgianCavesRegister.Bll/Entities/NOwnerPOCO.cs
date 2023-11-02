using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelgianCavesRegister.Bll.Entities
{
    public class NOwnerPOCO
    {
        public int NOwner_Id { get; set; }
        public string Status { get; set; }
        public string Agreement { get; set; }
        public bool Active { get; set; }

        public List<NOwnerPOCO> NOwners { get; set; }

        public class Result
        {
            public List<NOwnerResult> Results { get; set; }
        }
        public class NOwnerResult
        {
            public string Status { get; set; }
            public string Agreement { get; set; }
            public bool Active { get; set; }
        }
    }
}

