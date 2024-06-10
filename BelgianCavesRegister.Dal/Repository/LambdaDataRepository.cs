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
    public class LambdaDataRepository : ILambdaDataRepository
    {
        private readonly SqlConnection _connection;

        public LambdaDataRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool Create(LambdaData lambdaData)
        {
            try
            {
                string sql = "INSERT INTO LambdaData (Localisation, Topo, Acces, EquipementSheet, PracticalInformation, Description, Site_Id) VALUES " +
                    "(@Localisation, @Topo, @Acces, @EquipementSheet, @PracticalInformation, @Description, @Site_Id)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Localisation", lambdaData.Localisation);
                parameters.Add("@Topo", lambdaData.Topo);
                parameters.Add("@Acces", lambdaData.Acces);
                parameters.Add("@EquipementSheet", lambdaData.EquipementSheet);
                parameters.Add("@PracticalInformation", lambdaData.PracticalInformation);
                parameters.Add("@Description", lambdaData.Description);
                parameters.Add("@Site_Id", lambdaData.Site_Id);
                return _connection.Execute(sql, parameters) > 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error encoding Lambda Data: {ex.ToString}");
            }
            return false;
        }
        public void CreateLambdaData(LambdaData lambdaData)
        {
            try
            {
                string sql = "INSERT INTO LambdaData(Localisation, Topo, Acces, EquipementSheet, PracticalInformation, Description, Site_Id) VALUES " +
                    "(@localisation, @topo, @acces, @equipementSheet, @pracricalInformation, @description)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@localisation", lambdaData.Localisation);
                parameters.Add("@topo", lambdaData.Topo);
                parameters.Add("@acces", lambdaData.Acces);
                parameters.Add("@equipementSheet", lambdaData.EquipementSheet);
                parameters.Add("@practicalInformation", lambdaData.PracticalInformation);
                parameters.Add("@description", lambdaData.Description);
                parameters.Add("@site_Id", lambdaData.Site_Id);
                _connection.Query(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error CreateLambda data : {ex.ToString}");
            }
        }

        public LambdaData? Delete(int donneesLambda_Id)
        {


            try
            {
                string sql = "DELETE * FROM LambdaData WHERE DonneesLambda_Id = @donneesLambda_Id";
                DynamicParameters parameters = new DynamicParameters();
                return _connection.QueryFirst<LambdaData>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting Lambda Data: {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<LambdaData?> GetAll()
        {
            string sql = "SELECT * FROM LambdaData";
            return _connection.Query<LambdaData>(sql);
        }

        public LambdaData? GetById(int donneesLambda_Id)
        {

            try
            {
                string sql = "SELECT la.Localisation, la.Topo, la.Acces, la.EquipementSheet, la.PracticalInformation, la.Description, la.Site_Id FROM LambdaData la JOIN Site si ON la.Site_Id WHERE DonneesLambda_Id = @donneesLambda_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@donneesLambda_Id", donneesLambda_Id);
                return _connection.QueryFirst<LambdaData>(sql, parameters);
            }
			catch (Exception ex)
			{

                Console.WriteLine($"Error geting Lambda Data: {ex.ToString}");
            }
            return null;
        }

        public LambdaData? Update(string localisation, string topo, string acces, string equipementSheet, string practicalInformation, string description, int site_Id, int donneesLambda_Id)
        {
            try
            {
                string sql = "UPDATE LambdaData SET  Localisation = @localisation, Topo = @topo, Acces = @acces, EquipementSheet = @equipementSheet, PracticalInformation = @practicalInformation, Description = @description, Site_Id = @site_Id WHERE DonneesLambda_Id = @donneesLambda_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@localisation", localisation);
                parameters.Add("@topo", topo);
                parameters.Add("@acces", acces);
                parameters.Add("@equipementSheet", equipementSheet);
                parameters.Add("@description", description);
                parameters.Add("@site_Id", site_Id);
                parameters.Add("@donneesLambda_Id", donneesLambda_Id);

                return _connection.QueryFirst<LambdaData>(sql, parameters);
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Lambda Data: {ex}");
            }
            return new LambdaData();
        }
    }
}

