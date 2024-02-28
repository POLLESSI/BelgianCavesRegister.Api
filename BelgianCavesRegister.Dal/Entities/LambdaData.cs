﻿
namespace BelgianCavesRegister.Dal.Entities
{
    public class LambdaData
    {
        public int DonneesLambda_Id { get; set; }
        public string? Localisation { get; set; }
        public string? Topo { get; set; }
        public string? Acces { get; set; }
        public string? EquipementSheet { get; set; }
        public string? PracticalInformation { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; }
    }
}

