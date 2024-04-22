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
                string sql = "INSERT INTO NOwner (Status, Agreement) VALUES " +
                    "(@Status, @Agreement)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Status", nOwner.Status);
                parameters.Add("@Agreement", nOwner.Agreement);
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
                string sql = "INSERT INTO NOwner (Status, Agrement) " +
                    " VALUES (@status, @agreement)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@status", nOwner.Status);
                parameters.Add("@agreement", nOwner.Agreement);
                _connection.Query(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error GreateNewOwner: {ex.ToString}");
            }
        }

        public NOwner Delete(int nOwner_Id)
        {


            try
            {
                string sql = "DELETE FROM NOwner WHERE NOwner_Id = @nOwner_Id";
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

        public IEnumerable<NOwner> GetAll()
        {
            string sql = "SELECT * FROM NOwner";
            return _connection.Query<NOwner?>(sql);
        }

        public NOwner GetById(int nOwner_Id)
        {


            try
            {
                string sql = "SELECT * FROM NOwner WHERE NOwner_Id = @nOwner_Id";
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

        public NOwner Update(int nOwner_Id, string status, string agreement)
        {
            try
            {
                string sql = "UPDATE NOwner SET Status = @status, Agreement = @agreement WHERE NOwner_Id = @nOwber_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@nOwner_Id", nOwner_Id);
                parameters.Add("@status", status);
                parameters.Add("@agreement", agreement);
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

