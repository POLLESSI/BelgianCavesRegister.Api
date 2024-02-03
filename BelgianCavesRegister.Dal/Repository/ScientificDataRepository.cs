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
        public bool Create(ScientificData scientificdata) 
        {
            string sql = "INSERT INTO ScientificData (DataType, DetailsData, ReferenceData) VALUES " + "(@DataType, @DetailData, @ReferenceData)";
            //var param = scientificdata;
            return _connection.Execute(sql, scientificdata) > 0;
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error encoding new scientific datas : {ex.ToString}");
            //}
            //return false;
            
        }
        //public void CreateScientificData(ScientificData scientificData)
        //{
        //    string sql = "INSERT INTO ScientificData (DataType, DetailsData, ReferenceData) VALUES " + "(@dataType, @detailData, @referenceData)";
        //    //var param = scientificData;
        //    _connection.Query(sql, scientificData);
        //}
        public IEnumerable<ScientificData> GetAll()
        {
            string sql = "SELECT * FROM ScientificData";
            return _connection.Query<ScientificData>(sql);
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error geting sientific's datas : {ex.ToString}");
            //}
            //return Enumerable.Empty<ScientificData>();
        }
        //async Task<System.Windows.Documents.IEnumerable<ScientificData>> IScientificDataRepository.GetAll()
        //{
        //    using (HttpClient http = new HttpClient())
        //    {
        //        HttpResponseMessage message = await http.GetAsync("https://BelgianCavesRegister.Dal/Entities/scientificdata?limit=100000");
        //        if (message.IsSuccessStatusCode)
        //        {
        //            ScientificData scientificData = await message.Content.ReadFromJsonAsync<ScientificData>();
        //        }
        //    }
        //}
        public ScientificData? GetById(int scientificData_Id)
        {
            string sql = "SELECT * FROM ScientificData WHERE ScientificData_Id = @scientificData_Id";
            return _connection.QueryFirst<ScientificData>(sql, new { scientificData_Id });
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error geting scientific's data : {ex.ToString}");
            //}
            //return new ScientificData();
        }

        //async Task<ScientificData> IScientificDataRepository.GetById(int scientificData_Id)
        //{
        //    using (HttpClient http = new HttpClient())
        //    {
        //        HttpResponseMessage message = await http.GetAsync($"https://BelgianCavesRegister.Dal/Entities/ScientificData/{scientificData_Id}");

        //        if (message.IsSuccessStatusCode)
        //        {
        //            return await message.Content.ReadFromJsonAsync<ScientificData>();
        //        }
        //    }
        //    return null;
        //}
        public ScientificData? Delete(int scientificData_Id)
        {
            string sql = "DELETE FROM ScientificData WHERE ScientificData_Id = @scientificData_Id";
            return _connection.QueryFirst<ScientificData>(sql, new { scientificData_Id });
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error deleting Scientific's data : {ex.ToString}");
            //}
            //return null;
        }
        public ScientificData? Update(int scientificData_Id, string dataType, string detailsData, string referenceData)
        {
            string sql = "UPDATE ScientificData SET DataType = @dataType, DetailsData = @detailsData, ReferenceData = @referenceData  WHERE ScientificData_Id = @scientificData_Id";
            var param = new { scientificData_Id, dataType, detailsData, referenceData };
            return _connection.QueryFirst<ScientificData>(sql, param);
            //try
            //{
                
            //}
            //catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            //{

            //    Console.WriteLine($"Validation error : {ex.Message}");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error updating scientific's data : {ex}");
            //}
            //return new ScientificData();
        }
    }
}
