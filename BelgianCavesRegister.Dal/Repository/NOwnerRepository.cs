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
        private readonly /*IDbConnection*/ SqlConnection _connection;

        public NOwnerRepository(/*IDbConnection*/ SqlConnection connection)
        {
            _connection = connection;
        }
        public bool Create(NOwner nowner) 
        {
            string sql = "INSERT INTO NOwner(Status, Agreement) VALUES " + "(@Status, @Agreement)";
            var param = new { nowner };
            return _connection.Execute(sql, param) > 0;
        }
        public void AddNOwner(string status, string agreement)
        {
            string sql = "INSERT INTO NOwner (Status, Agreement) " +
                " VALUES (@status, @agreement)";
            var param = new { status, agreement };
            _connection.Query(sql, param);
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
            string sql = "SELECT * FROM NOwner WHERE NOwner_Id = @nOwner_Id";
            var param = new { nOwner_Id };
            return _connection.QueryFirst<NOwner>(sql, param);
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
            string sql = "DELETE FROM NOwner WHERE NOwner_Id = @nOwner_Id";
            var param = new { nOwner_Id };
            return _connection.QueryFirst<NOwner>(sql, param);
        }
        public NOwner? Update(int nOwner_Id, string status, string agreement)
        {
            string sql = "UPDATE NOwner SET Status = @status, Agreement = @agreement WHERE NOwner_Id = @nOwner_Id";
            var param = new {nOwner_Id, status, agreement };
            return _connection.QueryFirst<NOwner>(sql, param);
        }
    }
}

