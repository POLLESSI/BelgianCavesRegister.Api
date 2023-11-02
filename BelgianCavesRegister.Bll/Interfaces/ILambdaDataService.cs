using BelgianCavesRegister.Bll.Entities;
using BelgianCavesRegister.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BelgianCavesRegister.Bll
{
    public interface ILambdaDataService
    {
        void RegisterLambdaData(string localisation, string topo, string acces, string equipementSheet, string practicalInformation, string description);
        void Create(string localisation, string topo, string acces, string equipementSheet, string practicalInformation, string description);
        IEnumerable<LambdaDataPOCO> GetAll();
        LambdaDataPOCO? GetById(int donneesLambda_Id);
        LambdaDataPOCO? Delete(int donneesLambda_Id);
        LambdaDataPOCO? Update(int donneesLambda_Id);
    }
}

