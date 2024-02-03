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
    public class LambdaDataRepository : ILambdaDataRepository
    {
        private readonly SqlConnection _connection;

        public LambdaDataRepository(SqlConnection connection)
        {
            _connection = connection;
        }
        public bool Create(LambdaData lambdaData)
        {
            string sql = "INSERT INTO LambdaData (Localisation, Topo, Acces, EquipementSheet, PracticalInformation, Description) VALUES " + "(@Localisation, @Topo, @Acces, @EquipementSheet, @PracticalInformation, @Description)";
            //var param = lambdaData;
            return _connection.Execute(sql, lambdaData) > 0;
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error encoding Lambda Data: {ex.ToString}");
            //}
            //return false;
        }
        //public void CreateLambdaData(LambdaData lambdaData)
        //{
        //    string sql = "INSERT INTO LambdaData(Localisation, Topo, Acces, EquipementSheet, PracticalInformation, Description) VALUES " + "(@localisation, @topo, @acces, @equipementSheet, @practicalInformation, @description)";
        //    //var param = lambdaData;
        //    _connection.Query(sql, lambdaData);
        //}
        public IEnumerable<LambdaData> GetAll()
        {
            string sql = "SELECT * FROM LambdaData";
            return _connection.Query<LambdaData>(sql);
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error geting Lambda Datas: {ex.ToString}");
            //}
            //return Enumerable.Empty<LambdaData>();
        }
        //async Task<System.Windows.Documents.IEnumerable<LambdaData>> ILambdaDataRepository.GetAll()
        //{
        //    using (HttpClient http = new HttpClient())
        //    {
        //        HttpResponseMessage message = await http.GetAsync("https://BelgianCavesRegister.Dal/Entities/lambdadata?limit=100000");
        //        if (message.IsSuccessStatusCode)
        //        {
        //            LambdaData lambdaData = await message.Content.ReadFromJsonAsync<LambdaData>();
        //        }
        //    }
        //}
        public LambdaData? GetById(int donneesLambda_Id)
        {
            string sql = "SELECT * FROM LambdaData WHERE DonneesLambda_Id = @donneesLambda_Id";
            var param = new { donneesLambda_Id };
            return _connection.QueryFirst<LambdaData>(sql, param);
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error geting Lambda Data: {ex.ToString}");
            //}
            //return new LambdaData();
        }
        //async Task<LambdaData> ILambdaDataRepository.GetById(int donneesLambda_Id)
        //{
        //    using (HttpClient http = new HttpClient())
        //    {
        //        HttpResponseMessage message = await http.GetAsync($"https://BelgianCavesRegister.Dal/Entities/LambdaData/{donneesLambda_Id}");
        //        if (message.IsSuccessStatusCode)
        //        {
        //            return await message.Content.ReadFromJsonAsync<LambdaData>();
        //        }
        //    }
        //    return null;
        //}
        public LambdaData? Delete(int donneesLambda_Id)
        {
            string sql = "DELETE FROM LambdaData WHERE DonneesLambda_Id = @donneesLambda_Id";
            var param = new { donneesLambda_Id };
            return _connection.QueryFirst<LambdaData>(sql, param);
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error deleting Lambda Data: {ex.ToString}");
            //}
            //return null;
        }

        public LambdaData? Update(int donneesLambda_Id, string localisation, string topo, string acces, string equipementSheet, string practicalInformation, string description)
        {
            string sql = "UPDATE LambdaData SET DonneesLambda_Id = @lambdaData_Id WHERE DonneesLambda_Id = @donneesLambda_Id";
            var param = new { donneesLambda_Id };
            return _connection.QueryFirst<LambdaData>(sql, param);
            //try
            //{
                
            //}
            //catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            //{

            //    Console.WriteLine($"Validation error : {ex.Message}");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error updating Lambda Data: {ex}");
            //}
            //return new LambdaData();
        }
    }
}

