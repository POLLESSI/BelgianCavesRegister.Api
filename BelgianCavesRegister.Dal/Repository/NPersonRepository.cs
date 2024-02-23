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
        public bool Create(NPerson nPerson) 
        {
            try
            {
                string sql = "INSERT INTO NPerson (Lastname, Firstname, BirthDate, Email, Address_Street, Address_Nbr, PostalCode, Address_City, Address_Country, Telephone, Gsm) VALUES" + "(@Lastname, @Firstname, @BirthDate, @Email, @Address_Street, @Address_Nbr, @PostalCode, @Address_City, @Address_Country, @Telephone, @Gsm)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Lastname", nPerson.Lastname);
                parameters.Add("@Firstname", nPerson.Firstname);
                parameters.Add("@BirthDate", nPerson.BirthDate);
                parameters.Add("@Email", nPerson.Email);
                parameters.Add("@Address_Street", nPerson.Address_Street);
                parameters.Add("@Address_Nbr", nPerson.Address_Nbr);
                parameters.Add("@PostalCode", nPerson.PostalCode);
                parameters.Add("@Address_City", nPerson.Address_City);
                parameters.Add("@Address_Country", nPerson.Address_Country);
                parameters.Add("@Telephone", nPerson.Telephone);
                parameters.Add("@Gsm", nPerson.Gsm);
                return _connection.Execute(sql, nPerson) > 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error encoding New Person : {ex.ToString}");
            }
            return false;
        }

        public void CreateNPerson(NPerson nPerson)
        {
            string sql = "INSERT INTO NPerson (Lastname, Firstname, BirthDate, Email, Address_Street, Address_Nbr, PostalCode, Address_City, Address_Country, Telephone, Gsm) " +
                "VALUES (@lastname, @firstname, @birthDate, @email, @address_Street, @address_Nbr, @postalCode, @address_City, @address_Country, @telephone, @gsm)";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@lastname", nPerson.Lastname);
            parameters.Add("@firstname", nPerson.Firstname);
            parameters.Add("@birthDate", nPerson.BirthDate);
            parameters.Add("@email", nPerson.Email);
            parameters.Add("@address_Street", nPerson.Address_Street);
            parameters.Add("@address_Nbr", nPerson.Address_Nbr);
            parameters.Add("@postalCode", nPerson.PostalCode);
            parameters.Add("@address_City", nPerson.Address_City);
            parameters.Add("@address_Country", nPerson.Address_Country);
            parameters.Add("@telephone", nPerson.Telephone);
            parameters.Add("@gsm", nPerson.Gsm);
            _connection.Execute(sql, nPerson);
        }
        public IEnumerable<NPerson> GetAll()
        {
            string sql = "SELECT * FROM NPerson";
            return _connection.Query<NPerson>(sql);
        }
        //async Task<System.Windows.Documents.IEnumerable<NPerson>> INPersonRepository.GetAll()
        //{
        //    using (HttpClient http =  new HttpClient())
        //    {
        //        HttpResponseMessage message = await http.GetAsync("https://BelgianCavesRegister.Dal/Entities/nperson?limit=1000000000");
        //        if (message.IsSuccessStatusCode)
        //        {
        //            NPerson nPerson = await message.Content.ReadFromJsonAsync<NPerson>(); ;
        //        }
        //    }
        //}
        public NPerson? GetById(int nPerson_Id)
        {
            try
            {
                string sql = "SELECT * FROM NPerson WHERE NPerson_Id = @nPerson_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@nPerson_Id");
                return _connection.QueryFirst<NPerson>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Person : {ex.ToString}");
            }
            return new NPerson();
        }
        //async Task<NPerson> INPersonRepository.GetById(int nPerson_Id)
        //{
        //    using (HttpClient http = new HttpClient())
        //    {
        //        HttpResponseMessage message = await http.GetAsync($"https://BelgianCavesRegister.Dal/Entities/NPerson/{nPerson_Id}");
        //        if (message.IsSuccessStatusCode)
        //        {
        //            return await message.Content.ReadFromJsonAsync<NPerson>();
        //        }
        //    }
        //    return null;
        //}
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

                Console.WriteLine($"Error deleting Person : {ex.ToString}");
            }
            return null;
        }
        public NPerson? Update(int nPerson_Id, string lastname, string firstname, DateTime birthDate, string email, string address_Street, string address_Nbr, string postalCode, string address_City, string address_Country, string telephone, string gsm)
        {
            try
            {
                string sql = "UPDATE NPerson SET Lastname = @lastname, Firstname = @firstname, BirthDate = @birthDate, Email = @email, Address_Street = @address_Street, Address_Nbr = @address_Nbr, PostalCode = @postalcode, Address_City = @address_City, Address_Country = @address_Country, Telephone = @telephone, Gsm = @gsm  WHERE NPerson_Id = @nPerson_Id";
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
                Console.WriteLine($"Error updating Person<: {ex}");
            }
            return null;
        }
    }
}

