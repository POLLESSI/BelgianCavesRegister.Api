using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using Dapper;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace BelgianCavesRegister.Dal.Repository
{
    public class SiteRepository : ISiteRepository
    {
        private readonly /*IDbConnection*/ SqlConnection _connection;

        public SiteRepository(/*IDbConnection*/ SqlConnection connection)
        {
            _connection = connection;
        }
        public bool Create(Site site)
        {
            string sql = "INSERT INTO Site (Site_Name, Site_Description, Latitude, Longitude, Length, Depth, AccessRequirement, PracticalInformation, DonneesLambda_Id, NOwner_Id, ScientificData_Id, Bibliography_Id) VALUES " + "(@Site_Name, @Site_Description, @Latitude, @Longitude, @Length, @Depth, @AccessRequirement), @PracticalInformation, @DonneesLambda_Id, @NOwner_Id, @ScientificData_Id, @Bibliography_Id)";
            var param = new { site };
            return _connection.Execute(sql, param) > 0;
        }
        public void CreateSite(string site_Name, string site_Description, double latitude, double longitude, decimal length, decimal depth, string accessRequirement, string practicalInformation, int donneesLambda_Id, int nOwner_Id, int scientificData_Id, int bibliography_Id)
        {
            string sql = "INSERT INTO Site (Site_Name, Site_Description, Latitude, Longitude, Length, Depth, AccessRequirement, PracticalInformation, DonneesLambda_Id, NOwner_Id, ScientificData_Id, Bibliography_Id) " +
                "VALUES (@site_Name, @site_Descrition, @latitude, @longitude, @length, @depth, @accesRequirement, @practicalInformation, @donneesLambda_Id, @nOwner_Id, @scientificData_Id, @bibliography_Id)";

            var param = new { site_Name, site_Description, latitude, longitude, length, depth, accessRequirement, practicalInformation, donneesLambda_Id, nOwner_Id, scientificData_Id, bibliography_Id };
            _connection.Query(sql, param);

        }
        public IEnumerable<Site> GetAll()
        {
            string sql = "SELECT * FROM Site";
            return _connection.Query<Site>(sql);
        }
        //async Task<System.Windows.Documents.IEnumerable<Site>> ISiteRepository.GetAll()
        //{
        //    using (HttpClient http = new HttpClient())
        //    {
        //        HttpResponseMessage message = await http.GetAsync("https://BelgianCavesRegister.Dal/Entities/site?limit=150");
        //        if (message.IsSuccessStatusCode)
        //        {
        //            Site site = await message.Content.ReadFromJsonAsync<Site>();
        //        }
        //    }
        //}
        public Site? GetById(int site_Id)
        {
            
            //string sql = "SELECT * FROM Site WHERE Site_Id = @site_Id";
            string sql = "SELECT si.Site_Name, si.Site_Description, si.Latitude, si.Longitude, si.Length, si.Depth, si.AccessRequirement, si.PracticalInformation FROM Site si JOIN LambdaData la ON si.Lambdadata_Id = la.LambdaData_Id JOIN NOwner no ON si.NOwner_Id = no.NOwner_Id JOIN ScientificData sc ON si.ScientificData_Id = sc.ScientificData_Id JOIN Bibliography bi ON si.Bibliography_Id = bi.Bibliography_Id ";
            var param = new { site_Id };
            return _connection.QueryFirst<Site?>(sql, param);
        }
        //async Task<Site> ISiteRepository.GetById(int site_Id)
        //{
        //    using (HttpClient http =  new HttpClient())
        //    {
        //        HttpResponseMessage message = await http.GetAsync($"https://BelgianCavesRegister.Dal/Entities/Site/{site_Id}");
        //        if (message.IsSuccessStatusCode)
        //        {
        //            return await message.Content.ReadFromJsonAsync<Site>();
        //        }
        //    }
        //    return null;
        //}
        public Site? Delete(int site_Id)
        {
            string sql = "DELETE FROM Site WHERE Site_Id = @site_Id";
            var param = new { site_Id };
            return _connection.QueryFirst<Site>(sql, param);
        }
        public Site? Update(int site_Id, string site_Name, string site_Description, double latitude, double longitude, decimal length, decimal depth, string accessRequirement, string practicalInformation, int donneesLambda_Id, int nOwner_Id, int scientificData_Id, int bibliography_Id)
        {
            
            //string ToUpdate;
            string sql = "UPDATE Site SET Site_Name = @site_Name, Site_Description = @site_Description, Latitude = @latitude, Longitude = @longitude, Length = @length, Depth = @depth, AccessRequirement = @accessRequirement, PracticalInformation = @practicalInformation, DonneesLambda_Id = @donneesLambda_Id, NOwner_Id = @nOwner_Id, ScientificData_Id = @scientificData_Id, Bibliography_Id = @bibliography_Id WHERE Site_Id = @site_Id";
            var param = new { site_Id, site_Name, site_Description, latitude, longitude, length, depth, accessRequirement, practicalInformation, donneesLambda_Id, nOwner_Id, scientificData_Id, bibliography_Id };
            return _connection.QueryFirst<Site>(sql, param);
        }
    }
}

