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
    public class NUserRepository : INUserRepository
    {
        private readonly SqlConnection _connection;

        public NUserRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task AddAsync(NUser user)
        {
            try
            {
                var query = @"INSER INTO NUser (Pseudo, PasswordHash, SecurityStamp, Email,NPerson_Id, Role_Id, Active)
                              VALUES (@Pseudo, @PasswordHash, @SecurityStamp, @Email, @NPerson_Id, @Role_Id, @Active)"; 
                await _connection.ExecuteAsync(query, user);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error registration: {ex.ToString}");
            }
        }
        public async Task<NUser?> GetByEmailAsync(string? email)
        {
            try
            {
                var query = "SELECT * FROM NUser WHERE Email = @Email";
                return await _connection.QuerySingleOrDefaultAsync<NUser>(query, new { Email = email });
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error registration: {ex.ToString}");
            }
            return null;
        }

        public bool Create(NUser nUser)
        {
            try
            {
                string sql = "INSERT INTO NUser (Pseudo, PasswordHash, Email, NPerson_Id, Role_Id) VALUES " +
                    "(@Pseudo, CONVERT(varbinary(4000), @PasswordHash), @Email, @NPerson_Id, @Role_Id)";
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

                Console.WriteLine($"Error Encoding New User: {ex.ToString}");
            }
            return false;
        }

        public void CreateNUser(NUser nUser)
        {
            try
            {
                string sql = "INSERT INTO NUser (Pseudo, PasswordHash, Email, NPerson_Id, Role_Id) " +
                    "VALUES (@pseudo, CONVERT(varbinary(4000), @passwordHash), @email, @nPerson_Id, @role_Id)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@pseudo", nUser.Pseudo);
                parameters.Add("@passwordHash", nUser.PasswordHash);
                parameters.Add("@email", nUser.Email);
                parameters.Add("@nPerson_Id", nUser.NPerson_Id);
                parameters.Add("@role_Id", nUser.Role_Id);
                _connection.Query<NUser>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error Create New Person: {ex.ToString}");
            }
        }
        public NUser? Delete(int nUser_Id)
        {


            try
            {
                string sql = "DELETE * FROM NUser WHERE NUser_Id = @nUser_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@nUser_Id", nUser_Id);
                return _connection.QueryFirst<NUser>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting User: {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<NUser?> GetAll()
        {
            string sql = "SELECT Pseudo, PasswordHash, Email, NPerson_Id, Role_Id FROM NUser";
            return _connection.Query<NUser?>(sql);
        }
        public NUser? GetById(int nUser_Id)
        {
            try
            {
                string sql = "SELECT nu.Pseudo, nu.PasswordHash, nu.SecurityStamp, nu.Email, nu.NPerson_Id, nu.Role_Id FROM NUser nu JOIN NPerson pe ON nu.NPerson_Id = pe.NPerson_Id WHERE NUser_Id = @nUser_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@nUser_Id", nUser_Id);
                return _connection.QueryFirst<NUser?>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting User: {ex.ToString}");
            }
            return null;
        }

        public NUser? LoginNUser(string email, string passwordHash)
        {
            try
            {
                string sqlCheckPassword = "SELECT * FROM NUser WHERE Email = @email, PasswordHash = CONVERT(varbinary(4000), @passwordHash)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@email", email);
                parameters.Add("@passwordhash", passwordHash);
                return _connection.QueryFirst<NUser?>(sqlCheckPassword, parameters);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException($"Non-existent user : {ex.ToString}");
            }
        }

        public void RegisterNUser(string pseudo, string email, string passwordHash)
        {
            try
            {
                //byt PswHash = BCrypt.Net.Bcrypt.HashPassword^(passwordHash);
                string sql = "INSERT INTO NUser (Pseudo, Email, PasswordHash)" +
                    "VALUES (@pseudo, @email, CONVERT(varbinary(64), @passwordHash))";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@pseudo", pseudo);
                parameters.Add("@email", email);
                parameters.Add("@passwordHash", passwordHash);
                _connection.Execute(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error Registering User: {ex.ToString}");
            }
            
        }
        public void SetRole(string role_Id, int nUser_Id)
        {
            try
            {
                string sql = "UPDATE NUser SET Role_Id = @role_Id WHERE NUser_Id = @nUser_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@role_Id", role_Id);
                parameters.Add("@nUser_Id", nUser_Id);
                _connection.Execute(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error changing rôle : {ex.ToString}");
            }
        }

        public NUser? Update(string pseudo, string passwordHash, string email, int nPerson_Id, string role_Id, int nUser_Id)
        {
            try
            {
                string sql = "UPDATE NUser SET Pseudo = @pseudo, PasswordHash = CONVERT(varbinary(4000), @passwordHash), Email = @email, NPerson_Id = @nPerson_Id, Role_Id = @role_Id WHERE NUser_Id = @nUser_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@pseudo", pseudo);
                parameters.Add("@passwordHash", passwordHash);
                parameters.Add("@email", email);
                parameters.Add("@nPerson_Id", nPerson_Id);
                parameters.Add("@role_Id", role_Id);
                parameters.Add("@nUser_Id", nUser_Id);
                return _connection.QueryFirst<NUser>(sql, parameters);
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user : {ex}");
            }
            return new NUser();
        }
    }
}

