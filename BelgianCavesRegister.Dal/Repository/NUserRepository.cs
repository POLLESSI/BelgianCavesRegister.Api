using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using Dapper;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.Data.SqlClient;

namespace BelgianCavesRegister.Dal.Repository
{
    public class NUserRepository : INUserRepository
    {
        private readonly /*IDbConnection*/ SqlConnection _connection;

        public NUserRepository(/*IDbConnection*/ SqlConnection connection)
        {
            _connection = connection;
        }

        public bool Create(NUser newNUser) 
        {
            string sql = "INSERT INTO NUser (Pseudo, PasswordHash, Email, NPerson_Id, Role_Id) VALUES" + "(@Pseudo, @PasswordHash, Email, NPerson_Id, @Role)";
            var param = new { newNUser };
            return _connection.Execute(sql, param) > 0;
        }
        public void CreateNUser(string pseudo, string passwordHash, string email, int? nPerson_Id, int? role_Id)
        {
            string sql = "INSERT INTO NUser (Pseudo, PasswordHash, Email, NPerson_Id, Role_Id)  " +
                "VALUES(@pseudo, @passwordHash, @email, @nPerson_Id, @role_Id)using";
            _connection.Query(sql);
        }
        public void CreateNUser(NUser newNUser)
        {
            //string PasswordHashed = BCrypt.Net.BCrypt.HashPassword(PasswordHash);
            
        }
        
        public NUser? LoginNUser(string email, string passwordHash)
        {
            try
            {
                string sqlCheckPassword = "SELECT * FROM NUser WHERE Email = @email";
                return _connection.QueryFirst<NUser>(sqlCheckPassword, new { email });
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Non-existent user");
            }

        }
        public IEnumerable<NUser> GetAll()
        {
            //_connection.Open();
            string sql = "SELECT * FROM NUser";
            return _connection.Query<NUser>(sql);
           
        }
        //async Task<System.Windows.Documents.IEnumerable<NUser>> INUserRepository.GetAll()
        //{
        //    using (HttpClient http = new HttpClient())
        //    {
        //        HttpResponseMessage message = await http.GetAsync("https://BelgianCavesRegister.Dal/Entities/nuser?limit=1000000000");
        //        if (message.IsSuccessStatusCode)
        //        {
        //            NUser nUser = await message.Content.ReadFromJsonAsync<NUser>();
        //        }
        //    }
        //}
        public NUser? GetById(Guid nUser_Id)
        {
            string sql = "SELECT * FROM NUSER WHERE NUser_Id = @nUser_Id";
            return _connection.QueryFirst<NUser>(sql, new { nUser_Id });
           
        }
        //async Task<NUser> INUserRepository.GetById(System.Guid nUser_Id)
        //{
        //    using (HttpClient http = new HttpClient())
        //    {
        //        HttpResponseMessage message = await http.GetAsync($"https://BelgianCavesRegister.Dal/Entities/NUser/{nUser_Id}");
        //        if (message.IsSuccessStatusCode)
        //        {
        //            return await message.Content.ReadFromJsonAsync<NUser>();
        //        }
        //    }
        //    return null;
        //}
        public NUser? UnregisterNUser(Guid nUser_Id)
        {
            string sql = "DELETE FROM NUser WHERE NUser_Id = @nUser_Id";
            var param = new { nUser_Id };
            return _connection.QueryFirst<NUser>(sql, new { nUser_Id });
        }
        public NUser? Delete(Guid nUser_Id)
        {
            string sql = "DELETE FROM NUser WHERE NUser_Id = @nUser_Id";
            var param = new { nUser_Id };
            return _connection.QueryFirst<NUser>(sql, new { nUser_Id });
            
        }
        public NUser? Update(Guid nUser_Id, string pseudo, string passwordHash, string email, int? nPerson_Id, int? role_Id)
        {
            string sql = "UPDATE NUser SET Pseudo = @pseudo, PasswordHash = @passwordHash, Email = @email WHERE NUser_Id = @nUser_Id";
            return _connection.QueryFirst<NUser>(sql);
        }
        public void SetRole(Guid nUser_Id, int role_id)
        {
            string sql = "UPDATE NUser SET Role_Id = @role_Id WHERE Id = @nUser_Id";
            var param = new { nUser_Id, role_id };
            _connection.Execute(sql, param);
           
        }
    }
}

