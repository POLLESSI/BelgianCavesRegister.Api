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
        private readonly SqlConnection _connection;

        public BibliographyRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool Create(Bibliography bibliography)
        {
            try
            {
                string sql = "INSERT INTO Bibliography (Title, Author, ISBN, DataType, Detail, Site_Id) VALUES " +
                    "(@Title, @Author, @ISBN, @DataType, @Detail, @Site_Id)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Title", bibliography.Title);
                parameters.Add("@Author", bibliography.Author);
                parameters.Add("ISBN", bibliography.ISBN);
                parameters.Add("@DataType", bibliography.DataType);
                parameters.Add("@Detail", bibliography.Detail);
                parameters.Add("Site_Id", bibliography.Site_Id);

                return _connection.Execute(sql, parameters) > 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error encoding Bibliography: {ex.ToString}");
            }
            return false;
        }

        public void CreateBibliography(Bibliography bibliography)
        {
            try
            {
                string sql = "INSERT INTO Bibliography (Title, Author, ISBN, DataType, Detail, Site_Id) " +
                    "VALUES (@title, @author, @iSBN, @dataType, @detail, @site_Id)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@title", bibliography.Title);
                parameters.Add("@author", bibliography.Author);
                parameters.Add("@iSBN", bibliography.ISBN);
                parameters.Add("@dataType", bibliography.DataType);
                parameters.Add("@detail", bibliography.Detail);
                parameters.Add("@site_id", bibliography.Site_Id);

                _connection.Query(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Creating Error: {ex.ToString}");
            }
        }

        public Bibliography? Delete(int bibliography_Id)
        {


            try
            {
                string sql = "DELETE * FROM Bibliography WHERE Bibliography_Id = @bibliography_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@bibliography_Id", bibliography_Id);
                return _connection.QueryFirst<Bibliography>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting Bibliogrephy: {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<Bibliography?> GetAll()
        {
            string sql = "SELECT * FROM Bibliography";
            return _connection.Query<Bibliography?>(sql);
        }

        public Bibliography? GetById(int bibliography_Id)
        {


            try
            {
                string sql = "SELECT bi.Title, bi.Author, bi.ISBN, bi.DataType, bi.Detail, bi.Site_Id FROM Bibliography bi JOIN Site si ON bi.Site_Id = si.Site_Id WHERE Bibliography_Id = @bibliography_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@bibliography_Id", bibliography_Id);
                return _connection.QueryFirst<Bibliography>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Bibliography: {ex.ToString}");
            }
            return null;
        }
			
        public Bibliography? Update(string title, string author, string iSBN, string dataType, string detail, int site_Id, int bibliography_Id)
        {
            try
            {
                string sql = "UPDATE Bibliography SET Title = @title, Author = @author, ISBN = @iSBN, DataType = @dataType, Detail = @detail, Site_Id = @site_Id WHERE Bibliography_Id = @bibliography_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@title", title);
                parameters.Add("@author", author);
                parameters.Add("@iSBN", iSBN);
                parameters.Add("@dataType", dataType);
                parameters.Add("@detail", detail);
                parameters.Add("@site_Id", site_Id);
                parameters.Add("@bibliography_Id", bibliography_Id);
                return _connection.QueryFirst<Bibliography?>(sql, parameters);
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Bibliography: {ex}");
            }
            return new Bibliography();
        }

        public Bibliography Update(Bibliography bibliography)
        {
            throw new NotImplementedException();
        }
    }
}

