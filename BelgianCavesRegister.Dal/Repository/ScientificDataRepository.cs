using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using Dapper;
using System.Data;

namespace BelgianCavesRegister.Dal.Repository
{
    public class ScientificDataRepository : IScientificDataRepository
    {
        private readonly IDbConnection _connection;

        public ScientificDataRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public void RegisterScientificData(ScientificDataDTO newScien)
        {
            string sql = "INSERT INTO ScientificData(DataType, DetailsData, ReferenceData) " + " VALUES (@dataType, @detailsData, @referenceData)";
            //var param = new { dataType, detailData, referenceData };
            _connection.Query(sql, newScien);
        }
        //public bool Create(string dataType, string detailData, string referenceData)
        //{
        //    string sql = "INSERT INTO ScientificData(DataType, DetailsData, ReferenceData) VALUES " + "(@dataType, @detailsData, @referenceData)";
        //    var param = new { dataType, detailData, referenceData };
        //    return _connection.Execute(sql, param) > 0;
        //}
        public IEnumerable<ScientificDataDTO> GetAll()
        {
            string sql = "SELECT + FROM ScientificData";
            return _connection.Query<ScientificDataDTO>(sql);
        }
        public ScientificDataDTO? GetById(int scientificData_Id)
        {
           
            string sql = "SELECT * FROM SCIENTIFICDATA WHERE ScientificData_Id = @scientificData_Id";
            return _connection.QueryFirst<ScientificDataDTO>(sql, new { scientificData_Id });
        }
        public ScientificDataDTO? Delete(int scientificData_Id)
        {

            //string ToDelete;
            string sql = "DELETE ScientificData SET ScientificData_Id = WHERE ScientificData_Id = @scientificData_Id";
            return _connection.QueryFirst<ScientificDataDTO>(sql, new { scientificData_Id });
        }
        public ScientificDataDTO? Update(int scientificData_Id)
        {
   
            //string ToUpdate;
            string sql = "UPDATE ScientificData SET ScientificData_Id = @scientificData_Id  WHERE ScientificData_Id = @scientificData_Id";
            var param = new { scientificData_Id };
            return _connection.QueryFirst<ScientificDataDTO>(sql, new { scientificData_Id });
        }
    }
}
