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
            try
            {
                string sql = "INSERT INTO NUser (Pseudo, PasswordHash, Email, NPerson_Id, Role_Id) VALUES" + "(@Pseudo, @PasswordHash, @Email, @NPerson_Id, @Role_Id)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Pseudo", nUser.Pseudo);
                parameters.Add("@PasswordHash", nUser.PasswordHash);
                parameters.Add("@Email", nUser.Email);
                parameters.Add("@NPerson_Id", nUser.NPerson_Id);
                parameters.Add("@Role_Id", nUser.Role_Id);
                return _connection.Execute(sql, parameters) > 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error Enconding New User : {ex.ToString}");
            }
            return false;
        }
        //public void CreateNUser(NUser nUser)
        //{
        //    string sql = "INSERT INTO NUser (Pseudp, PasswordHash, Email, NPerson_Id, Role_Id) " +
        //        "VALUES (@pseudo, @passwordHash, @email, @nPerson_Id, @role)";
        //    //var param = nUser;
        //    _connection.Query(sql, nUser);
        //}
        
        public NUser? LoginNUser(string email, string passwordHash)
        {
            
            try
            {
                string sqlCheckPassword = "SELECT * FROM NUser WHERE Email = @email, PasswordHash = @passwordHash";
                var parameters = new DynamicParameters();
                parameters.Add("@email", email);
                parameters.Add("@passwordHash", passwordHash);
                return _connection.QueryFirst<NUser>(sqlCheckPassword, parameters);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException($"Non-existent user : {ex.ToString}");
            }
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
            try
            {
                string sql = "SELECT * FROM NUser WHERE NUser_Id = @nUser_Id";
                var param = new { nUser_Id };
                return _connection.QueryFirst<NUser>(sql, param);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting User : {ex.ToString}");
            }
            return new NUser();
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
        public void RegisterNUser(string pseudo, string email, string passwordHash)
        {
            try
            {
                //byte PswdHash = BCrypt.Net.BCrypt.HashPassword(passwordHash);
                string sql = "INSERT INTO NUser (Pseudo, Email, PasswordHash)" +
                    " VALUES (@pseudo, @email, @passwordHash)";
                var param = new { pseudo, email, passwordHash };
                _connection.Execute(sql, param);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error UnRegistering User : {ex.ToString}");
            }
            return;
        }
        public NUser? Delete(Guid nUser_Id)
        {
            try
            {
                string sql = "DELETE FROM NUser WHERE NUser_Id = @nUser_Id";
                var param = new { nUser_Id };
                return _connection.QueryFirst<NUser>(sql, param);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting User : {ex.ToString}");
            }
            return null;

        }
        public NUser? Update(Guid nUser_Id, string pseudo, string passwordHash, string email, int? nPerson_Id, int? role_Id)
        {
            try
            {
                string sql = "UPDATE NUser SET Pseudo = @pseudo, PasswordHash = @passwordHash, Email = @email, NPerson_Id = @nPerson_Id, Role_Id = @role_Id WHERE NUser_Id = @nUser_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@nUser_Id", nUser_Id);
                parameters.Add("@pseudo", pseudo);
                parameters.Add("@passwordHash", passwordHash);
                parameters.Add("@email", email);
                parameters.Add("@nPerson_Id", nPerson_Id);
                parameters.Add("@role_Id", role_Id);
                return _connection.QueryFirst<NUser>(sql, parameters);
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating User : {ex}");
            }
            return new NUser();
        }
        public void SetRole(Guid nUser_Id, int role_id)
        {
            try
            {
                string sql = "UPDATE NUser SET Role_Id = @role_Id WHERE Id = @nUser_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@nUser_Id", nUser_Id);
                parameters.Add("@role_Id", role_id);
                _connection.Execute(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error changing rôle : {ex.ToString}");
            }
        }
    }
}

