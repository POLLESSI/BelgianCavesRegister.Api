using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using Dapper;
using System.Data;

namespace BelgianCavesRegister.Dal.Repository
{
    public class NUserRepository : INUserRepository
    {
        private readonly IDbConnection _connection;

        public NUserRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public void RegisterNUser(NUserDTO newNUser)
        {
            string sql = "INSERT INTO NUser (Pseudo, PasswordHash, Email, NPerson_Id, Role_Id) VALUES " + "(@pseudo, @passwordHash, @email, @nPerson_Id, @role_Id)using";
            var param = new { newNUser };
            _connection.Query(sql, param);
        }
        

        
        public NUserDTO? LoginNUser(string email, string passwordHash)
        {
            try
            {
                string sqlCheckPassword = "SELECT * FROM NUser WHERE Email = @email";
                return _connection.QueryFirst<NUserDTO>(sqlCheckPassword, new { email });
            }
            catch (Exception)
            {

                throw new InvalidOperationException("Non-existent user");
            }

        }
        public IEnumerable<NUserDTO> GetAll()
        {
            string sql = "SELECT * FROM NUser";
            return _connection.Query<NUserDTO>(sql);
           
        }
        public NUserDTO? GetById(Guid nUser_Id)
        {
            string sql = "SELECT * FROM NUSER WHERE NUser_Id = @nUser_Id";
            return _connection.QueryFirst<NUserDTO>(sql, new { nUser_Id });
           
        }
        public NUserDTO? Delete(Guid nUser_Id)
        {
            
            //string ToDelete;
            string sql = "DELETE NUser SET NUser_Id = @nUser_Id WHERE NUser_Id = @nUser_Id";
            var param = new { nUser_Id };
            return _connection.QueryFirst<NUserDTO>(sql, new { nUser_Id });
            
        }
        public NUserDTO? Update(Guid nUser_Id)
        {
            _connection.Open();
            //string ToUpdate;
            string sql = "UPDATE NUser SET NUser_Id = @nUser_Id WHERE NUser_Id = @nUser_Id";
            var param = new { nUser_Id };
            return _connection.QueryFirst<NUserDTO>(sql, new { nUser_Id });
        }
        public void SetRole(Guid nUser_Id, int role_id)
        {
            string sql = "UPDATE NUser SET Role_Id = @role_Id WHERE Id = @nUser_Id";
            var param = new { nUser_Id, role_id };
            _connection.Execute(sql, param);
           
        }
    }
}

