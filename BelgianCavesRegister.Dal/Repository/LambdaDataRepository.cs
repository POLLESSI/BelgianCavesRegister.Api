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
        private readonly /*IDbConnection*/ SqlConnection _connection;

        public LambdaDataRepository(/*IDbConnection*/ SqlConnection connection)
        {
            _connection = connection;
        }
        public bool Create(LambdaData lambdaData)
        {
            try
            {
                string sql = "INSERT INTO LambdaData (Localisation, Topo, Acces, EquipementSheet, PracticalInformation, Description) VALUES " + "(@Localisation, @Topo, @Acces, @EquipementSheet, @PracticalInformation, @Description)";
                var param = new { lambdaData };
                return _connection.Execute(sql, param) > 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error encoding Lambda Data: {ex.ToString}");
            }
            return false;
        }
        public void AddLambdaData(string localisation, string topo, string acces, string equipementSheet, string practicalInformation, string description)
        {
            try
            {
                string sql = "INSERT INTO LambdaData (Localisation, Topo, Acces, EquipementSheet, PracticalInformation, Description) " +
                "VALUES (@localisation, @topo, @acces, @equipementSheet, @practicalInformation, @description)";
                var param = new { localisation, topo, acces, equipementSheet, practicalInformation, description };
                _connection.Query(sql, param);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error Additionning Lambda Data: {ex.ToString}");
            }
        }
        
        public IEnumerable<LambdaData> GetAll()
        {
            try
            {
                string sql = "SELECT * FROM LambdaData";
                return _connection.Query<LambdaData>(sql);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Lambda Datas: {ex.ToString}");
            }
            return Enumerable.Empty<LambdaData>();
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
            try
            {
                string sql = "SELECT * FROM LambdaData WHERE DonneesLambda_Id = @donneesLambda_Id";
                var param = new { donneesLambda_Id };
                return _connection.QueryFirst<LambdaData>(sql, param);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Lambda Data: {ex.ToString}");
            }
            return new LambdaData();
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

            try
            {
                string sql = "DELETE FROM LambdaData WHERE DonneesLambda_Id = @donneesLambda_Id";
                var param = new { donneesLambda_Id };
                return _connection.QueryFirst<LambdaData>(sql, param);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting Lambda Data: {ex.ToString}");
            }
            return null;
        }

        public LambdaData? Update(int donneesLambda_Id, string localisation, string topo, string acces, string equipementSheet, string practicalInformation, string description)
        {

            try
            {
                string sql = "UPDATE LambdaData SET DonneesLambda_Id = @lambdaData_Id WHERE DonneesLambda_Id = @donneesLambda_Id";
                var param = new { donneesLambda_Id };
                return _connection.QueryFirst<LambdaData>(sql, param);
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Lambda Data: {ex}");
            }
            return new LambdaData();
        }
    }
}

