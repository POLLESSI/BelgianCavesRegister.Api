using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using System.Data;
using Dapper;

namespace BelgianCavesRegister.Dal.Repository
{
    public class SiteRepository : ISiteRepository
    {
        private readonly IDbConnection _connection;

        public SiteRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public void RegisterSite(SiteDTO newSite)
        {
            string sql = "INSERT INTO Site (Site_Name, Site_Description, Latitude, Longitude, Length, Depth, AccessRequirement, PracticalInformation, DonneesLambda_Id, NOwner_Id, ScientificData_Id, Bibliography_Id) " +
                "VALUES (@site_Name, @site_Descrition, @latitude, @longitude, @length, @depth, @accesRequirement, @practicalInformation, @donneesLambda_Id, @nOwner_Id, @scientificData_Id, @bibliography_Id)";

            //var param = new { site_Name, site_Description, latitude, longitude, length, depth, accessRequirement, practicalInformation, donneesLambda_Id, nOwner_Id, scientificData_Id, bibliography_Id };
            _connection.Query(sql, newSite);

        }
        public IEnumerable<SiteDTO> GetAll()
        {
            string sql = "SELECT * FROM Site";
            return _connection.Query<SiteDTO>(sql);
        }
        public SiteDTO? GetById(int site_Id)
        {
            
            //string sql = "SELECT * FROM Site WHERE Site_Id = @site_Id";
            string sql = "SELECT si.Site_Name, si.Site_Description, si.Latitude, si.Longitude, si.Length, si.Depth, si.AccessRequirement, si.PracticalInformation FROM Site si JOIN LambdaData la ON si.Lambdadata_Id = la.LambdaData_Id JOIN NOwner no ON si.NOwner_Id = no.NOwner_Id JOIN ScientificData sc ON si.ScientificData_Id = sc.ScientificData_Id JOIN Bibliography bi ON si.Bibliography_Id = bi.Bibliography_Id ";
            var param = new { site_Id };
            return _connection.QueryFirst<SiteDTO?>(sql, param);
        }
        public SiteDTO? Delete(int site_Id)
        {
            
            //string ToDelete;
            string sql = "DELETE Site SET Site_Id = @site_Id WHERE Site_Id = @site_Id";
            var param = new { site_Id };
            return _connection.QueryFirst<SiteDTO>(sql, param);
        }
        public SiteDTO Update(int site_Id)
        {
            
            //string ToUpdate;
            string sql = "UPDATE Site SET Site_Id = @site_Id WHERE Site_Id = @site_Id";
            var param = new { site_Id };
            return _connection.QueryFirst<SiteDTO>(sql, param);
        }
    }
}

