using BelgianCavesRegister.Dal.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.LambdaData;

namespace BelgianCavesRegister.Dal.Interfaces
{
    public interface ILambdaDataRepository
    {
        bool Create(LambdaData lambdaData);
        void CreateLambdaData(LambdaData lambdaData);
        IEnumerable<LambdaData?> GetAll();
        LambdaData? GetById(int donneesLambda_Id);
        LambdaData? Delete(int donneesLambda_Id);
        LambdaData? Update(string? localisation, string? topo, string? acces, string? equipementSheet, string? practicalInformation, string? description, int site_Id, int donneesLambda_Id);
    }
}

