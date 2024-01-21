using BelgianCavesRegister.Dal.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.LambdaData;

namespace BelgianCavesRegister.Dal.Interfaces
{
    public interface ILambdaDataRepository
    {
        bool Create(LambdaData lambdaData);
        void AddLambdaData(string localisation, string topo, string acces, string equipementSheet, string practicalInformation, string description);
        IEnumerable<LambdaData> GetAll();
        LambdaData? GetById(int donneesLambda_Id);
        LambdaData? Delete(int donneesLambda_Id);
        LambdaData? Update(int donneesLambda_Id, string localisation, string topo, string acces, string equipementSheet, string practicalInformation, string description);
        
    }
}

