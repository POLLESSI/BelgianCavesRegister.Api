using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelgianCavesRegister.Bll.Entities
{
    public class SitePOCO
    {
        public int Site_Id { get; set; }
        public string? Site_Name { get; set; }
        public string? Site_Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public decimal Length { get; set; }
        public decimal Depth { get; set; }
        public string? AccessRequirement { get; set; }
        public string? PracticalInformation { get; set; }
        public int DonneesLambda_Id { get; set; }
        public int NOwner_Id { get; set; }
        public int ScientificData_Id { get; set; }
        public int Bibliography_Id { get; set; }
        public bool Active { get; set; }

        public List<SitePOCO> Sites { get; set; }
        public class Result
        {
            public List<SiteResult> Results { get; set; }
        }

        public class SiteResult
        {
            public string Site_Name { get; set; }
            public string Site_Description { get; set; }
            public string Url { get; set; }
        }
    }
}

