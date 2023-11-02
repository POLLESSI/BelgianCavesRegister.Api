using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using Dapper;
using System.Data;

namespace BelgianCavesRegister.Dal.Repository
{
    public class NPersonRepository : INPersonRepository
    {
        private readonly IDbConnection _connection;

        public NPersonRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public void RegisterNPerson(NPersonDTO newNPerson)
        {
            string sql = "INSERT INTO NPerson (Lastname, Firstname, BirthDate, Email, Address_Street, Address_Nbr, PostalCode, Address_City, Address_Country, Telephone, Gsm) " +
                "VALUES (@lastname, @firstname, @birthDate, @email, @address_Street, @address_Nbr, @postalCode, @address_City, @address_Country, @telephone, @gsm)";
            //var param = new { newDto };
            _connection.Query(sql, newNPerson);
        }
       
        public IEnumerable<NPersonDTO> GetAll()
        {
            string sql = "SELECT * FROM NPerson";
            return _connection.Query<NPersonDTO>(sql);
        }
        public NPersonDTO? GetById(int nPerson_Id)
        {
            
            string sql = "SELECT * FROM NPerson WHERE NPerson_Id = @nPerson_Id";
            var param = new { nPerson_Id };
            return _connection.QueryFirst<NPersonDTO>(sql, param);
           
        }
        public NPersonDTO? Delete(int nPerson_Id)
        {
           
            string sql = "DELETE NPerson_Id SET NPerson_Id = @nPerson_Id WHERE NPerson_Id = @nPerson_Id";
            var param = new { nPerson_Id };
            return _connection.QueryFirst<NPersonDTO>(sql, param);
        }
        public NPersonDTO? Update(int nPerson_Id)
        {
            string sql = "UPDATE NPerson SET NOerson_Id = @nPerson_Id WHERE NPerson_Id = @nPerson_Id";
            var param = new { nPerson_Id };
            return _connection.QueryFirst<NPersonDTO>(sql, param);
        }
    }
}

