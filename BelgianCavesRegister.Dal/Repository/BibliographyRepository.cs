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
            try
            {
                string sql = "INSERT INTO Bibliography (Title, Author, ISBN, DataType, Detail) VALUES " + "(@Title, @Author, @ISBN, @DataType, @Detail)";
                var param = new { bibliography };
                return _connection.Execute(sql, param) > 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error encoding Bibliography: {ex.ToString}");
                
            }
            return false;
            
        }
        public void AddBibliography(string title, string author, string iSBN, string dataType, string detail)
        {
            try
            {
                string sql = "INSERT INTO Bibliography (Title, Author, ISBN, DataType, Detail) VALUES " +
                "(@title, @author, @iSBN, @dataType, @detail)";
                var param = new { title, author, iSBN, dataType, detail };
                _connection.Query(sql, param);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error additioning Bibliography {ex.ToString}");
            }
            
        }
        
        public IEnumerable<Bibliography> GetAll()
        {
            try
            {
                string sql = "SELECT * FROM Bibliography";
                return _connection.Query<Bibliography>(sql);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Bibliographies");
            }
            return Enumerable.Empty<Bibliography>();
            
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
            try
            {
                string sql = "SELECT * FROM BIBLIOGRAPHY WHERE Bibliography_Id = @bibliography_Id";
                var param = new { bibliography_Id };
                return _connection.QueryFirst<Bibliography>(sql, param);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Bibliography: {ex.ToString}");
                
            }
            return new Bibliography();
            
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
            try
            {
                string sql = "DELETE FROM Bibliography WHERE Bibliography_Id = @bibliography_Id";
                var param = new { bibliography_Id };
                return _connection.QueryFirst<Bibliography>(sql, param);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting Bibliography: {ex.ToString}");
                
            }
            return null;
        }
        public Bibliography? Update(int bibliography_Id, string title, string author, string iSBN, string dataType, string detail)
        {
            try
            {
                string sql = "UPDATE Bibliography SET Bibliography_Id = @bibliography_Id WHERE Bibliography_Id = @bibliography_Id";
                var param = new { bibliography_Id };
                return _connection.QueryFirst<Bibliography>(sql, param);
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error updating Bibliography: {ex}");
                
            }
            return new Bibliography();
        }

        public Bibliography? Update(Bibliography bibliography)
        {
            throw new NotImplementedException();
        }
    }
}

