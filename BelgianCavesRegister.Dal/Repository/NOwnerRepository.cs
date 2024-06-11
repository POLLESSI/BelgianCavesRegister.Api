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
    public class NOwnerRepository : INOwnerRepository
    {
        private readonly SqlConnection _connection;

        public NOwnerRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool Create(NOwner nOwner)
        {
            try
            {
                string sql = "INSERT INTO NOwner (Status, Agreement, NPerson_Id, Site_Id) VALUES " +
                    "(@Status, @Agreement, @NPerson_Id, @Site_Id)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Status", nOwner.Status);
                parameters.Add("@Agreement", nOwner.Agreement);
                parameters.Add("@NPerson_Id", nOwner.NPerson_Id);
                parameters.Add("@Site_Id", nOwner.Site_Id);
                return _connection.Execute(sql, parameters) > 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error encoding New Owner: {ex.ToString}");
            }
            return false;
        }

        public void CreateNOwner(NOwner nOwner)
        {
            try
            {
                string sql = "INSERT INTO NOwner (Status, Agrement, MPerson_Id, Site_Id) " +
                    " VALUES (@status, @agreement, @nPerson_Id, @site_Id)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@status", nOwner.Status);
                parameters.Add("@agreement", nOwner.Agreement);
                parameters.Add("@nPerson_Id", nOwner.NPerson_Id);
                parameters.Add("@site_id", nOwner.Site_Id);
                _connection.Query(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error GreateNewOwner: {ex.ToString}");
            }
        }

        public NOwner? Delete(int nOwner_Id)
        {


            try
            {
                string sql = "DELETE * FROM NOwner WHERE NOwner_Id = @nOwner_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@nOwner_Id", nOwner_Id);
                return _connection.QueryFirst<NOwner?>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting Owner: {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<NOwner?> GetAll()
        {
            string sql = "SELECT * FROM NOwner";
            return _connection.Query<NOwner?>(sql);
        }

        public NOwner? GetById(int nOwner_Id)
        {


            try
            {
                string sql = "SELECT no.Status, no.Agreement, no.Site_Id FROM NOwner no JOIN Site si ON no.Site_Id WHERE NOwner_Id = @nOwner_Id JOIN NPerson pe ON no.NPerson_Id WHERE NPerson_Id = @nPerson_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@nOwner_Id", nOwner_Id);
                return _connection.QueryFirst<NOwner?>(sql, new { nOwner_Id });
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Owner: {ex.ToString}");
            }
            return null;
        }

        public NOwner? Update(string status, string agreement, int nPerson_Id, int site_Id, int nOwner_Id)
        {
            try
            {
                string sql = "UPDATE NOwner SET Status = @status, Agreement = @agreement, NPerson_Id = @nPerson_Id, Site_Id = @site_Id WHERE NOwner_Id = @nOwner_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@status", status);
                parameters.Add("@agreement", agreement);
                parameters.Add("@nPerson_Id", nPerson_Id);
                parameters.Add("@site_Id", site_Id);
                parameters.Add("@nOwner_Id", nOwner_Id);
                return _connection.QueryFirst<NOwner?>(sql, parameters);
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Owner: {ex}");
            }
            return new NOwner();
        }
    }
}

