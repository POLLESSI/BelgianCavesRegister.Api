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
                string sql = "INSERT INTO ScientificData (DataType, DetailsData, ReferenceData, Site_Id) VALUES " +
                    "(@DataType, @DetailsData, @ReferenceData, @Site_Id)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DataType", scientificData.DataType);
                parameters.Add("@DetailsData", scientificData.DetailsData);
                parameters.Add("@ReferenceData", scientificData.ReferenceData);
                parameters.Add("@Site_Id", scientificData.Site_Id);
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
                string sql = "INSERT INTO ScientificData (DataType, DetailsData, ReferenceData, Site_Id) VALUES " +
                    "(@dataType, @detailsData, @referenceData, @site_Id)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@dataType", scientificData.DataType);
                parameters.Add("@detailsData", scientificData.DetailsData);
                parameters.Add("@referenceData", scientificData.ReferenceData);
                parameters.Add("@site_Id", scientificData.Site_Id);
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
                string sql = "DELETE * FROM ScientificData WHERE ScientificData_Id = @scientificData_ID";
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
            
            try
            {
                string sql = "SELECT sc.DataType, sc.DetailsData, sc.ReferenceData, sc.Site_Id FROM ScientificData sc JOIN Site si ON sc.Site_Id = si.Site_Id WHERE ScientificData_Id = @scientificData_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@scientificData_Id", scientificData_Id);
                return _connection.QueryFirst<ScientificData?>(sql, new { scientificData_Id });
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting scientific data: {ex.ToString}");
            }
            return null;
        }

        public ScientificData? Update(string dataType, string detailsData, string referenceData, int site_Id, int scientificData_Id)
        {
            try
            {
                string sql = "UPDATE ScientificData SET DataType = @dataType, DetailsData = @detailsData, ReferenceData = @referenceData, Site_Id = @site_Id WHERE cientificData_Id = @scientificData_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@dataType", dataType);
                parameters.Add("@detailsData", detailsData);
                parameters.Add("@referenceData", referenceData);
                parameters.Add("@site_Id", site_Id);
                parameters.Add("@scientificData_Id", scientificData_Id);

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
