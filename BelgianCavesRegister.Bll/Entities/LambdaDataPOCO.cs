using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelgianCavesRegister.Bll.Entities
{
    public class LambdaDataPOCO
    {
        public int DonneesLambda_Id { get; set; }
        public string Localisation { get; set; }
        public string Topo { get; set; }
        public string Acces { get; set; }
        public string EquipementSheet { get; set; }
        public string PracticalInformation { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public List<LambdaDataPOCO> LambdaDatas { get; set; }
        public class Result
        {
            public List<LambdaDataResult> Results { get; set; }
        }
    }
    public class LambdaDataResult
    {
        public string Localisation { get; set; }
        public string Description { get; set; }
    }
}




