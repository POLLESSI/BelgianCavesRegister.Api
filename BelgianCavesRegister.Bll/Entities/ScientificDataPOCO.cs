using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelgianCavesRegister.Bll.Entities
{
    public class ScientificDataPOCO
    {
        public int ScientificData_Id { get; set; }
        public string DataType { get; set; }
        public string DetailsData { get; set; }
        public string ReferenceData { get; set; }
        public bool Active { get; set; }

        public List<ScientificDataPOCO> ScientificDatas { get; set; }
        public class Result
        {
            public List<ScientificDataResult> Results { get; set; }
        }
        public class ScientificDataResult
        {
            public string Datatype { get; set; }
            public string ReferenceData { get; set; }
            public string Url { get; set; }
            public bool Active { get; set; }
        }
    }
}
