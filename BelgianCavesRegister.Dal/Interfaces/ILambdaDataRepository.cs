using BelgianCavesRegister.Dal.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.Chat;

namespace BelgianCavesRegister.Dal.Interfaces
{
    public interface ILambdaDataRepository
    {
        bool Create(LambdaData lambdaData);
        void CreateLambda(LambdaData lambdaData);
        IEnumerable<LambdaData> GetAll();
        LambdaData GetById(int donneesLambda_Id);
        LambdaData Delete(int donneesLambda_Id);
        LambdaData Update(int donneesLambda_Id, string localisation, string topo, string acces, string equipementSheet, string practicalInformation, string description);
    }
}

