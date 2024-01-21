using BelgianCavesRegister.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.LambdaData;

namespace BelgianCavesRegister.Bll
{
    public interface ILambdaDataService
    {
        void AddLambdaData(string localisation, string topo, string acces, string equipementSheet, string practicalInformation, string description);
        bool Create(LambdaData lambdaData);
        IEnumerable<LambdaData> GetAll();
        LambdaData? GetById(int donneesLambda_Id);
        LambdaData? Delete(int donneesLambda_Id);
        LambdaData? Update(int donneesLambda_Id, string localisation, string topo, string acces, string equipementSheet, string practicalInformation, string description);
    }
}

