﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Text;

namespace BelgianCavesRegister.Dal.Repository
{
    public class SiteRepository : ISiteRepository
    {
        private readonly SqlConnection _connection;

        public SiteRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool Create(Site site)
        {
            try
            {
                string sql = "INSERT INTO Site (Site_Name, Site_Description, Latitude, Longitude, Length, Depth, AccessRequirement, PracticalInformation, DonneesLambda_Id, NOwner_Id, ScientificData_Id, Bibliography_Id) VALUES " + "(@Site_Name, @Site_Description, @Latitude, @Longitude, @Length, @Depth, @AccessRequirement, @PracticalInformation, @DonneesLambda_Id, @NOwner_Id, @ScientificData_Id, @Bibliography_Id)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Site_Name", site.Site_Name);
                parameters.Add("@Site_Description", site.Site_Description);
                parameters.Add("@Latitude", site.Latitude);
                parameters.Add("Longitude", site.Longitude);
                parameters.Add("@Length", site.Length);
                parameters.Add("@Depth", site.Depth);
                parameters.Add("@AccessRequirement", site.AccessRequirement);
                parameters.Add("@PracticalInformation", site.PracticalInformation);
                parameters.Add("@DonneesLambda_Id", site.DonneesLambda_Id);
                parameters.Add("@NOwner_Id", site.NOwner_Id);
                parameters.Add("@ScientificData_Id", site.ScientificData_Id);
                parameters.Add("@Bibliography_Id", site.Bibliography_Id);

                return _connection.Execute(sql, parameters) > 0;
            }
            catch (FormatException ex)
            {

                Console.WriteLine($"Format error during conversion: {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Overflow during conversion: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Use a Logging system to record errors
                Console.WriteLine($"Error encoding Site: {ex.Message}");
            }
            return false;
        }

        public void CreateSite(Site site)
        {
            try
            {
                string sql = "INSERT INTO Site (Site_Name, Site_Description, Latitude, Longitude, Length, Depth, AccessRequirement, PracticalInformation, DonneesLambda_Id, NOwner_Id, ScientificData_Id, Bibliography_Id) " +
                    "VALUES (@site_Name, @site_Description, @latitude, @longitude, @length, @depth, @accessRequirement, @practicalInformation, @donneesLambda_Id, @nOwner_Id, @scientificData_Id, @bibliography_Id)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@site_Name", site.Site_Name);
                parameters.Add("@site_Description", site.Site_Description);
                parameters.Add("@latitude", site.Latitude);
                parameters.Add("@longitude", site.Longitude);
                parameters.Add("@length", site.Length);
                parameters.Add("@depth", site.Depth);
                parameters.Add("@accessRequirement", site.AccessRequirement);
                parameters.Add("@practicalInformation", site.PracticalInformation);
                parameters.Add("@donneesLambda_Id", site.DonneesLambda_Id);
                parameters.Add("@nOwner_Id", site.NOwner_Id);
                parameters.Add("@scintificData_Id", site.ScientificData_Id);
                parameters.Add("@bibliography_id", site.Bibliography_Id);
                _connection.Query(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error cretaing Site: {ex.ToString}");
            }
        }

        public Site? Delete(int site_Id)
        {
            try
            {
                string sql = "DELETE FROM Site WHERE Site_Id = @site_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@site_Id", site_Id);
                return _connection.QueryFirst<Site>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleiting Site: {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<Site?> GetAll()
        {
            try
            {
                string sql = "SELECT * FROM Site";
                return _connection.Query<Site?>(sql);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Sites: {ex.ToString}");
            }
            return Enumerable.Empty<Site?>();
        }

        public Site? GetById(int site_Id)
        {
            try
            {
                string sql = "SELECT si.Site_Name, si.Site_Description, si.Latitude, si.Longitude, si.Length, si.Depth, si.AccessRequirement, si.PracticalInformation FROM Site si JOIN LambdaData la ON si.DonneesLambda_Id = la.DonneesLambda_Id JOIN NOwner no si.NOwner_Id = no.NOwner_Id JOIN ScientificData_Id = sc.ScientificData_Id JOIN Bibliography bi ON si.Bibliography_Id = bi.Bibliography_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("site_Id", site_Id);
                return _connection.QueryFirst<Site?>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting site: {ex.ToString}");
            }
            return null;
        }

        public Site? Update(int site_Id, string site_Name, string site_Decription, string latitude, string longitude, string length, string depth, string accessRequirement, string practicalInformation, int donneesLambda_Id, int nOwner_Id, int scientificData_Id, int bibliography_Id)
        {
            try
            {
                string sql = "UPDATE Sire SET Site_Name = @site_Name, Site_Description = @site_Description, Latitude = @latitude, Longitude = @longitude, Length = @length, Depth = @depth, AccessRequirement = @accessRequirement, PracticalInformation = @practicalInformation, DonneesLambda_Id = @donneesLambda_Id, NOwner_Id = @nOwner_Id, ScientificData_Id = @scientificData_Id, Bibliography_Id = @bibliography_Id WHERE Site_Id = @site_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@site_Id", site_Id);
                parameters.Add("@site_Name", site_Name);
                parameters.Add("@site_Description", site_Decription);
                parameters.Add("@latitude", latitude);
                parameters.Add("@longitude", longitude);
                parameters.Add("@length", length);
                parameters.Add("@depth", depth);
                parameters.Add("@accessRequirement", accessRequirement);
                parameters.Add("@practicalInformation", practicalInformation);
                parameters.Add("@donneesLambda_Id", donneesLambda_Id);
                parameters.Add("@nOwner_Id", nOwner_Id);
                parameters.Add("@scientificData_Id", scientificData_Id);
                parameters.Add("@bibliography_Id", bibliography_Id);
                return _connection.QueryFirst<Site>(sql, parameters);
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Site: {ex}");
            }
            return new Site();

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
        }
    }
}

