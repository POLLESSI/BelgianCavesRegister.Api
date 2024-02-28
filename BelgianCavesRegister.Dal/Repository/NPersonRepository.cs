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
    public class NPersonRepository : INPersonRepository
    {
        private readonly SqlConnection _connection;

        public NPersonRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool Create(NPerson person)
        {
            try
            {
                string sql = "INSERT INTO NPerson (Lastname, Firstname, BirthDate, Email, Address_Street, Address_Nbr, PostalCode, Address_City, Address_Country, Telephone, Gsm) VALUES" +
                "(@Lastname, @Firstname, @BirthDate, @Email, @Address_Street, @Address_Nbr, @PostalCode, @Address_City, @Address_Country, @Telephone, @Gsm)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Lastname", person.Lastname);
                parameters.Add("@Firstname", person.Firstname);
                parameters.Add("@BirthDate", person.BirthDate);
                parameters.Add("@Email", person.Email);
                parameters.Add("@Address_Street", person.Address_Street);
                parameters.Add("@Address_Nbr", person.Address_Nbr);
                parameters.Add("@PostalCode", person.PostalCode);
                parameters.Add("@Address_City", person.Address_City);
                parameters.Add("@Address_Country", person.Address_Country);
                parameters.Add("@Telephone", person.Telephone);
                parameters.Add("@Gsm", person.Gsm);
                return _connection.Execute(sql, parameters) > 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error encoding New Person: {ex.ToString}");
            }
            return false;
        }

        public void CreateNPerson(NPerson person)
        {
            try
            {
                string sql = "INSERT INTO NPerson (Lastname, Firstname, BirthDate, Email, Address_Street, Address_Nbr, PostalCode, Address_City, Address_Country, Telephone, Gsm) " +
                    "VALUES (@lastname, @firstname, @birthDate, @email, @address_Street, @address_Nbr, @postalCode, @address_City, @address_Country, @telephone, @gsm)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("lastname", person.Lastname);
                parameters.Add("firstname", person.Firstname);
                parameters.Add("birthDate", person.BirthDate);
                parameters.Add("email", person.Email);
                parameters.Add("address_Street", person.Address_Street);
                parameters.Add("address_Nbr", person.Address_Nbr);
                parameters.Add("postalCode", person.PostalCode);
                parameters.Add("address_City", person.Address_City);
                parameters.Add("@address_Country", person.Address_Country);
                parameters.Add("@telephone", person.Telephone);
                parameters.Add("@gsm", person.Gsm);
                _connection.Execute(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating New Person: {ex.ToString}");
            }
        }

        public NPerson? Delete(int nPerson_Id)
        {
            try
            {
                string sql = "DELETE FROM NPerson WHERE NPerson_Id = @nPerson_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@nPerson_Id", nPerson_Id);
                return _connection.QueryFirst<NPerson>(sql, parameters);    
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting Person: {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<NPerson?> GetAll()
        {
            string sql = "SELECT * FROM NPerson";
            return _connection.Query<NPerson?>(sql);
        }

        public NPerson? GetById(int nPerson_Id)
        {
            try
            {
                string sql = "SELECT * FROM NPerson WHERE NPerson_Id = @nPerson_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@nPerson_Id", nPerson_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Person: {ex.ToString}");
            }
            return null;
        }

        public NPerson? Update(int nPerson_Id, string lastname, string firstname, DateTime birthDate, string email, string address_Street, string address_Nbr, string postalCode, string address_City, string address_Country, string telephone, string gsm)
        {
            try
            {
                string sql = "Update NPerson SET Lastname = @lastname, Firstname = @firstname, BirthDate = @birthdate, Email = @email, Address_Street = @address_Street, Address_Nbr = @address_Nbr, PostalCode = @postalCode, Address_City = @address_City, Address_Country = @address_Country, Telephone = @telephone, Gsm = @gsm WHERE NPerson_Id = @nPerson_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@nPerson_Id", nPerson_Id);
                parameters.Add("@lastname", lastname);
                parameters.Add("@firstname", firstname);
                parameters.Add("@birthDate", birthDate);
                parameters.Add("@email", email);
                parameters.Add("@address_Street", address_Street);
                parameters.Add("@address_Nbr", address_Nbr);
                parameters.Add("@postalCode", postalCode);
                parameters.Add("@address_City", address_City);
                parameters.Add("@address_Country", address_Country);
                parameters.Add("@telephone", telephone);
                parameters.Add("@gsm", gsm);
                return _connection.QueryFirst<NPerson>(sql, parameters);
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Person: {ex}");
            }
            return new NPerson();
        }
    }
}

