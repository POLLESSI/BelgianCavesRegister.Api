using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using Dapper;
using System.Data;

namespace BelgianCavesRegister.Dal.Repository
{
    public class LambdaDataRepository : ILambdaDataRepository
    {
        private readonly IDbConnection _connection;

        public LambdaDataRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public void RegisterLambdaData(LambdaDataDTO newLambda)
        {
            string sql = "INSERT INTO LambdaData (Localisation, Topo, Acces, EquipementSheet, PracticalInformation, Description) " +
                "VALUES (@localisation, @topo, @acces, @equipementSheet, @practicalInformation, @description)";
            //var param = new { localisation, topo, acces, equipementSheet, practicalInformation, description };
            _connection.Query(sql, newLambda);
        }
        
        public IEnumerable<LambdaDataDTO> GetAll()
        {
            string sql = "SELECT * FROM LambdaData";
            return _connection.Query<LambdaDataDTO>(sql);
        }
        public LambdaDataDTO? GetById(int donneesLambda_Id)
        {
          
            string sql = "SELECT * FROM LAMBDADATA WHERE DonneesLambda_Id = @donneesLambda_Id";
            var param = new { donneesLambda_Id};
            return _connection.QueryFirst<LambdaDataDTO>(sql, param);
        }
        public LambdaDataDTO? Delete(int donneesLambda_Id)
        {
            
           
            string sql = "SELECT * FROM LAMBDADATA WHERE DonneesLambda_Id = @donneesLambda_Id";
            var param = new { donneesLambda_Id };
            return _connection.QueryFirst<LambdaDataDTO>(sql, param);
        }

        LambdaDataDTO? ILambdaDataRepository.Update(int donneesLambda_Id)
        {
            
            
            string sql = "UPDATE LambdaData SET DonneesLambda_Id = @lambdaData_Id WHERE DonneesLambda_Id = @donneesLambda_Id";
            var param = new { donneesLambda_Id };
            return _connection.QueryFirst<LambdaDataDTO>(sql, param);
        }
    }
}

