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
    public class BibliographyRepository : IBibliographyRepository
    {
        private readonly /*IDbConnection*/ SqlConnection _connection;

        public BibliographyRepository(/*IDbConnection*/ SqlConnection connection)
        {
            _connection = connection;
        }
        public bool Create(Bibliography bibliography)
        {
            string sql = "INSERT INTO Bibliography (Title, Author, ISBN, DataType, Detail) VALUES " + "(@Title, @Author, @ISBN, @DataType, @Detail)";
            var param = new { bibliography };
            return _connection.Execute(sql, param) > 0;
        }
        public void AddBibliography(string title, string author, int iSBN, string dataType, string detail)
        {
            string sql = "INSERT INTO Bibliography (Title, Author, ISBN, DataType, Detail) VALUES " +
                "(@title, @author, @iSBN, @dataType, @detail)";
            var param = new { title, author, iSBN, dataType, detail };
            _connection.Query(sql, param);
        }
        
        public IEnumerable<Bibliography> GetAll()
        {
            string sql = "SELECT * FROM Bibliography";
            return _connection.Query<Bibliography>(sql);
        }

        //async Task<System.Windows.Documents.IEnumerable<Bibliography>> IBibliographyRepository.GetAll()
        //{
        //    using (HttpClient http = new HttpClient())
        //    {
        //        HttpResponseMessage message = await http.GetAsync("https://BelgianCavesRegister.Dal/Entities/bibliography?limit=100000");
        //        if (message.IsSuccessStatusCode)
        //        {
        //            Bibliography bibliography = await message.Content.ReadFromJsonAsync<Bibliography>();
        //        }
        //    }
        //}
        public Bibliography? GetById(int bibliography_Id)
        {
          
            string sql = "SELECT * FROM BIBLIOGRAPHY WHERE Bibliography_Id = @bibliography_Id";
            var param = new { bibliography_Id };
            return _connection.QueryFirst<Bibliography>(sql, param);
        }
        //async Task<Bibliography> IBibliographyRepository.GetById(int bibliography_Id)
        //{
        //    using (HttpClient http = new HttpClient())
        //    {
        //        HttpResponseMessage message = await http.GetAsync($"https://BelgianCavesRegister.Dal/Entities/Bibliography/{bibliography_Id}");
        //        if (message.IsSuccessStatusCode)
        //        {
        //            return await message.Content.ReadFromJsonAsync<Bibliography>();
        //        }
        //    }
        //    return null;
        //}
        public Bibliography? Delete(int bibliography_Id)
        {
            string sql = "DELETE FROM Bibliography WHERE Bibliography_Id = @bibliography_Id";
            var param = new { bibliography_Id };
            return _connection.QueryFirst<Bibliography>(sql, param);
        }
        public Bibliography? Update(int bibliography_Id, string title, string author, int iSBN, string dataType, string detail)
        {
            string sql = "UPDATE Bibliography SET Bibliography_Id = @bibliography_Id WHERE Bibliography_Id = @bibliography_Id";
            var param = new { bibliography_Id };
            return _connection.QueryFirst<Bibliography>(sql, param);
        }

        public Bibliography? Update(Bibliography bibliography)
        {
            throw new NotImplementedException();
        }
    }
}

