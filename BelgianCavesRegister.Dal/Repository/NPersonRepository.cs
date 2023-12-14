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
    public class NPersonRepository : INPersonRepository
    {
        private readonly /*IDbConnection*/ SqlConnection _connection;

        public NPersonRepository(/*IDbConnection*/ SqlConnection connection)
        {
            _connection = connection;
        }
        public bool Create(NPerson newperson) 
        {
            string sql = "INSERT INTO NPerson (Lastname, Firstname, BirthDate, Email, Address_Street, Address_Nbr, PostalCode, Address_City, Address_Country, Telephone, Gsm) VALUES" + "(@Lastname, @Firstname, @BirthDate, @Email, @Address_Street, @Address_Nbr, @PostalCode, @Address_City, @Address_Country, @Telephone, @Gsm)";
            var param = new { newperson };
            return _connection.Execute(sql, param) > 0;
        }
        public void CreateNPerson(string lastname, string firstname, DateTime birthDate, string email, string address_Street, int address_Nbr, int postalCode, string address_City, string address_Country, int telephone, int gsm)
        {
            string sql = "INSERT INTO NPerson (Lastname, Firstname, BirthDate, Email, Address_Street, Address_Nbr, PostalCode, Address_City, Address_Country, Telephone, Gsm) " +
                "VALUES (@lastname, @firstname, @birthDate, @email, @address_Street, @address_Nbr, @postalCode, @address_City, @address_Country, @telephone, @gsm)";
            _connection.Query(sql);
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
            
            string sql = "SELECT * FROM NPerson WHERE NPerson_Id = @nPerson_Id";
            var param = new { nPerson_Id };
            return _connection.QueryFirst<NPerson>(sql, param);
           
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
           
            string sql = "DELETE FROM NPerson WHERE NPerson_Id = @nPerson_Id";
            var param = new { nPerson_Id };
            return _connection.QueryFirst<NPerson>(sql, param);
        }
        public NPerson? Update(int nPerson_Id, string lastname, string firstname, DateTime birthDate, string email, string address_Street, int address_Nbr, int postalCode, string address_City, string address_Country, int telephone, int gsm)
        {
            string sql = "UPDATE NPerson SET Lastname = @lastname, Firstname = @firstname, BirthDate = @birthDate, Email = @email, Address_Street = @address_Street, Address_Nbr = @address_Nbr, PostalCode = @postalcode, Address_City = @address_City, Address_Country = @address_Country, Telephone = @telephone, Gsm = @gsm  WHERE NPerson_Id = @nPerson_Id";
            var param = new { nPerson_Id, lastname, firstname, birthDate, email, address_Street, address_Nbr, postalCode, address_City, address_Country, telephone, gsm };
            return _connection.QueryFirst<NPerson>(sql, param);
        }
    }
}

