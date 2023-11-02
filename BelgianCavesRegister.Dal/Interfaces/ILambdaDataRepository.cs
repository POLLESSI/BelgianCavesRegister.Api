using BelgianCavesRegister.Dal.Entities;

namespace BelgianCavesRegister.Dal.Interfaces
{
    public interface ILambdaDataRepository
    {
        void RegisterLambdaData(LambdaDataDTO newDto);
        IEnumerable<LambdaDataDTO> GetAll();
        LambdaDataDTO? GetById(int donneesLambda_Id);
        LambdaDataDTO? Delete(int donneesLambda_Id);
        LambdaDataDTO? Update(int donneesLambda_Id);
        ///*bool Create(string localisation, string topo, string acces, string equipementSheet, string practicalInformation, string description)*/;
    }
}

