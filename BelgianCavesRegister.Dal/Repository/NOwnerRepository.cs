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
    public class NOwnerRepository : INOwnerRepository
    {
        private readonly SqlConnection _connection;

        public NOwnerRepository(SqlConnection connection)
        {
            _connection = connection;
        }
        public bool Create(NOwner nowner) 
        {
            try
            {
                string sql = "INSERT INTO NOwner (Status, Agreement) VALUES " + "(@Status, @Agreement)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Status", nowner.Status);
                parameters.Add("@Agreement", nowner.Agreement);
                return _connection.Execute(sql, parameters) > 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error encoding New Owner: {ex.ToString}");
            }
            return false;
        }
        public void CreateNOwner(NOwner nowner)
        {
            try
            {
                string sql = "INSERT INTO NOwner (Status, Agreement) " +
                " VALUES (@status, @agreement)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@status", nowner.Status);
                parameters.Add("@agreement", nowner.Agreement);
                _connection.Query(sql, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error CreateNewOwner : {ex.ToString}");
            }
            
        }
        public IEnumerable<NOwner> GetAll()
        {
            string sql = "SELECT * FROM NOwner";
            return _connection.Query<NOwner>(sql);
        }
        //async Task<System.Windows.Documents.IEnumerable<NOwner>> INOwnerRepository.GetAll()
        //{
        //    using (HttpClient http = new HttpClient())
        //    {
        //        HttpResponseMessage message = await http.GetAsync("https://BelgianCavesRegister.Dal/Entities/nowner?limit=1530");
        //        if (message.IsSuccessStatusCode)
        //        {
        //            NOwner nowner = await message.Content.ReadFromJsonAsync<NOwner>();
        //        }
        //    }
        //}
        public NOwner? GetById(int nOwner_Id)
        {
            try
            {
                string sql = "SELECT * FROM NOwner WHERE NOwner_Id = @nOwner_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@nOwner_Id");
                return _connection.QueryFirst<NOwner>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Owner: {ex.ToString}");
            }
            return new NOwner();
        }
        //async Task<NOwner> INOwnerRepository.GetById(int nOwner_Id)
        //{
        //    using (HttpClient http =  new HttpClient())
        //    {
        //        HttpResponseMessage message = await http.GetAsync($"https://BelgianCavesRegister.Dal/Entities/NOwner/{nOwner_Id}");
        //        if (message.IsSuccessStatusCode)
        //        {
        //            return await message.Content.ReadFromJsonAsync<NOwner>();
        //        }
        //    }
        //    return null;
        //}
        public NOwner? Delete(int nOwner_Id)
        {
            try
            {
                string sql = "DELETE FROM NOwner WHERE NOwner_Id = @nOwner_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@nOwner_Id", nOwner_Id);
                return _connection.QueryFirst<NOwner>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting Owner: {ex.ToString}");
            }
            return null;
        }
        public NOwner? Update(int nOwner_Id, string status, string agreement)
        {
            try
            {
                string sql = "UPDATE NOwner SET Status = @status, Agreement = @agreement WHERE NOwner_Id = @nOwner_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@nOwner_Id", nOwner_Id);
                return _connection.QueryFirst<NOwner>(sql, parameters);
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Owner : {ex}");
            }
            return new NOwner();
        }
    }
}

