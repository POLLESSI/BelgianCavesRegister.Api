using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using Dapper;
using System.Data;

namespace BelgianCavesRegister.Dal.Repository
{
    public class NOwnerRepository : INOwnerRepository
    {
        private readonly IDbConnection _connection;

        public NOwnerRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public void RegisterNOwner(NOwnerDTO newNOwner)
        {
            string sql = "INSERT INTO NOwner (Status, Agreement) " +
                " VALUES (@status, @agreement)";
            //var param = new { status, agreement };
            _connection.Query(sql, newNOwner);
        }
        
        public IEnumerable<NOwnerDTO> GetAll()
        {
            string sql = "SELECT * FROM NOwner";
            return _connection.Query<NOwnerDTO>(sql);
        }
        public NOwnerDTO? GetById(int nOwner_Id)
        {
            string sql = "SELECT * FROM NOWNER WHERE NOwner_Id = @nOwner_Id";
            var param = new { nOwner_Id };
            return _connection.QueryFirst<NOwnerDTO>(sql, param);
        }
        public NOwnerDTO? Delete(int nOwner_Id)
        {
            string sql = "SELECT * FROM NOWNER WHERE NOwner_Id = @nOwner_Id";
            var param = new { nOwner_Id };
            return _connection.QueryFirst<NOwnerDTO>(sql, param);
        }
        public NOwnerDTO? Update(int nOwner_Id)
        {
            string sql = "UpDate NOwner SET NOwner_Id = @nOwner_Id WHERE NOwner_Id";
            var param = new { nOwner_Id };
            return _connection.QueryFirst<NOwnerDTO>(sql, param);
        }
    }
}

