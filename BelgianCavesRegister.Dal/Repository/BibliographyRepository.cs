using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using Dapper;
using System.Data;

namespace BelgianCavesRegister.Dal.Repository
{
    public class BibliographyRepository : IBibliographyRepository
    {
        private readonly IDbConnection _connection;

        public BibliographyRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public void RegisterBibliography(BibliographyDTO newBiblio)
        {
            string sql = "INSERT INTO Bibliography (Title, Author, ISBN, DataType, Detail) VALUES " +
                "(@title, @author, @iSBN, @dataType, @detail)";
            //var param = new { title, author, iSBN, dataType, detail };
            _connection.Query(sql, newBiblio);
        }
        
        public IEnumerable<BibliographyDTO> GetAll()
        {
            string sql = "SELECT * FROM Bibliography";
            return _connection.Query<BibliographyDTO>(sql);
        }
        public BibliographyDTO? GetById(int bibliography_Id)
        {
          
            string sql = "SELECT * FROM BIBLIOGRAPHY WHERE Bibliography_Id = @bibliography_Id";
            var param = new { bibliography_Id };
            return _connection.QueryFirst<BibliographyDTO>(sql, param);
        }
        public BibliographyDTO? Delete(int bibliography_Id)
        {
            string sql = "SELECT * FROM BIBLIOGRAPHY WHERE Bibliography_Id = @bibliography_Id";
            var param = new { bibliography_Id };
            return _connection.QueryFirst<BibliographyDTO>(sql, param);
        }
        public BibliographyDTO? Update(int bibliography_Id)
        {
            string sql = "UPDATE Bibliography SET Bibliography_Id = @bibliography_Id WHERE Bibliography_Id = @bibliography";
            var param = new { bibliography_Id };
            return _connection.QueryFirst<BibliographyDTO>(sql, param);
        }
    }
}

