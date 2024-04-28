using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using Dapper;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace BelgianCavesRegister.Dal.Repository
{
    public class ScientificDataRepository : IScientificDataRepository
    {
        private readonly SqlConnection _connection;

        public ScientificDataRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool Create(ScientificData scientificData)
        {
            try
            {
                string sql = "INSERT INTO ScientificData (DataType, DetailsData, ReferenceData) VALUES " +
                    "(@DataType, @DetailsData, @ReferenceData)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DataType", scientificData.DataType);
                parameters.Add("@DetailsData", scientificData.DetailsData);
                parameters.Add("@ReferenceData", scientificData.ReferenceData);
                return _connection.Execute(sql, parameters) > 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error encoding new scientific datas: {ex.ToString}");
            }
            return false;
        }

        public void CreateScientificData(ScientificData scientificData)
        {
            try
            {
                string sql = "INSERT INTO ScientificData (DataType, DetailsData, ReferenceData) VALUES " +
                    "(@dataType, @detailsData, @referenceData)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@dataType", scientificData.DataType);
                parameters.Add("@detailsData", scientificData.DetailsData);
                parameters.Add("@referenceData", scientificData.ReferenceData);
                _connection.Query(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error Create Scientific Data: {ex.ToString}");
            }
        }

        public ScientificData? Delete(int scientificData_Id)
        {


            try
            {
                string sql = "DELETE FROM ScientificData WHERE ScientificData_Id = @scientificData_ID";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@csientificData_Id", scientificData_Id);
                return _connection.QueryFirst<ScientificData?>(sql, scientificData_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting Scientific data: {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<ScientificData?> GetAll()
        {
            string sql = "SELECT * FROM ScientificData";
            return _connection.Query<ScientificData?>(sql);
        }

        public ScientificData? GetById(int scientificData_Id)
        {
            string sql = "SELECT * FROM ScientificData WHERE ScientificData_Id = @scientificData_Id";
            return _connection.QueryFirst<ScientificData?>(sql, new { scientificData_Id });
            //try
            //{
                
            //    DynamicParameters parameters = new DynamicParameters();
            //    parameters.Add("@scientificData_Id", scientificData_Id);
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error geting scientific data: {ex.ToString}");
            //}
            //return null;
        }

        public ScientificData? Update(int scientificData_Id, string dataType, string detailsData, string referenceData)
        {
            try
            {
                string sql = "UPDATE ScientificData SET DataType = @dataType, DetailsData = @detailsData, ReferenceData = @referenceData WHERE cientificData_Id = @scientificData_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@scientificData_Id", scientificData_Id);
                parameters.Add("@dataType", dataType);
                parameters.Add("@detailsData", detailsData);
                parameters.Add("@referenceData", referenceData);

                return _connection.QueryFirst<ScientificData?>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error updating scientific data: {ex}");
            }
            return new ScientificData();
        }
    }
}
