using BelgianCavesRegister.Dal.Entities;

namespace BelgianCavesRegister.Dal.Interfaces
{
    public interface IScientificDataRepository
    {
        void RegisterScientificData(ScientificDataDTO newDto);
        IEnumerable<ScientificDataDTO> GetAll();
        ScientificDataDTO? GetById(int scientificData_Id);
        ScientificDataDTO? Delete(int scientificData_Id);
        ScientificDataDTO? Update(int scientificData_Id);
        //bool Create(string dataType, string detailData, string referenceData);
    }
}

