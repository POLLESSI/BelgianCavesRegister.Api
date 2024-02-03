using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using Dapper;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.Data.SqlClient;

namespace BelgianCavesRegister.Dal.Repository
{
    public class NUserRepository : INUserRepository
    {
        private readonly SqlConnection _connection;

        public NUserRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool Create(NUser nUser) 
        {
            string sql = "INSERT INTO NUser (Pseudo, PasswordHash, Email, NPerson_Id, Role_Id) VALUES" + "(@Pseudo, @PasswordHash, @Email, @NPerson_Id, @Role)";
            //var param = nUser;
            return _connection.Execute(sql, nUser) > 0;
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error Enconding New User : {ex.ToString}");
            //}
            //return false;
        }
        //public void CreateNUser(NUser nUser)
        //{
        //    string sql = "INSERT INTO NUser (Pseudp, PasswordHash, Email, NPerson_Id, Role_Id) " +
        //        "VALUES (@pseudo, @passwordHash, @email, @nPerson_Id, @role)";
        //    //var param = nUser;
        //    _connection.Query(sql, nUser);
        //}
        
        public NUser? LoginNUser(string email, byte passwordHash)
        {
            string sqlCheckPassword = "SELECT * FROM NUser WHERE Email = @email";
            return _connection.QueryFirst<NUser>(sqlCheckPassword, new { email });
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    throw new InvalidOperationException("Non-existent user");
            //}
        }
        public IEnumerable<NUser> GetAll()
        {
            string sql = "SELECT * FROM NUser";
            return _connection.Query<NUser>(sql);
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error geting Users : {ex.ToString}");
            //}
            //return Enumerable.Empty<NUser>();
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
            string sql = "SELECT * FROM NUser WHERE NUser_Id = @nUser_Id";
            return _connection.QueryFirst<NUser>(sql, new { nUser_Id });
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error geting User : {ex.ToString}");
            //}
            //return new NUser();
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
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error UnRegistering User : {ex.ToString}");
            //}
            //return null;
        }
        public NUser? Delete(Guid nUser_Id)
        {
            string sql = "DELETE FROM NUser WHERE NUser_Id = @nUser_Id";
            var param = new { nUser_Id };
            return _connection.QueryFirst<NUser>(sql, param);
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error deleting User : {ex.ToString}");
            //}
            //return default(NUser);
            
        }
        public NUser? Update(Guid nUser_Id, string pseudo, byte passwordHash, string email, int? nPerson_Id, int? role_Id)
        {
            string sql = "UPDATE NUser SET Pseudo = @pseudo, PasswordHash = @passwordHash, Email = @email WHERE NUser_Id = @nUser_Id";
            return _connection.QueryFirst<NUser>(sql);
            //try
            //{
                
            //}
            //catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            //{

            //    Console.WriteLine($"Validation error : {ex.Message}");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error updating User : {ex}");
            //}
            //return new NUser();
        }
        public void SetRole(Guid nUser_Id, int role_id)
        {
            string sql = "UPDATE NUser SET Role_Id = @role_Id WHERE Id = @nUser_Id";
            var param = new { nUser_Id, role_id };
            _connection.Execute(sql, param);
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error changing rôle : {ex.ToString}");
            //}           
        }
    }
}

