﻿using System;
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
    public class ScientificDataRepository : IScientificDataRepository
    {
        private readonly /*IDbConnection*/ SqlConnection _connection;

        public ScientificDataRepository(/*IDbConnection*/ SqlConnection connection)
        {
            _connection = connection;
        }
        public bool Create(ScientificData scientificdata) 
        {
            string sql = "INSERT INTO ScientificData (DataType, DetailsData, ReferenceData) VALUES " + "(@DataType, @DetailData, @ReferenceData)";
            var param = new { scientificdata };
            return _connection.Execute(sql, param) > 0;
        }
        public void CreateScientificData(string dataType, string detailsData, string referenceData)
        {
            string sql = "INSERT INTO ScientificData(DataType, DetailsData, ReferenceData) " + " VALUES (@dataType, @detailsData, @referenceData)";
            var param = new { dataType, detailsData, referenceData };
            _connection.Query(sql, param);
        }
        public IEnumerable<ScientificData> GetAll()
        {
            string sql = "SELECT + FROM ScientificData";
            return _connection.Query<ScientificData>(sql);
        }
        //async Task<System.Windows.Documents.IEnumerable<ScientificData>> IScientificDataRepository.GetAll()
        //{
        //    using (HttpClient http = new HttpClient())
        //    {
        //        HttpResponseMessage message = await http.GetAsync("https://BelgianCavesRegister.Dal/Entities/scientificdata?limit=100000");
        //        if (message.IsSuccessStatusCode)
        //        {
        //            ScientificData scientificData = await message.Content.ReadFromJsonAsync<ScientificData>();
        //        }
        //    }
        //}
        public ScientificData? GetById(int scientificData_Id)
        {
           
            string sql = "SELECT * FROM SCIENTIFICDATA WHERE ScientificData_Id = @scientificData_Id";
            return _connection.QueryFirst<ScientificData>(sql, new { scientificData_Id });
        }

        //async Task<ScientificData> IScientificDataRepository.GetById(int scientificData_Id)
        //{
        //    using (HttpClient http = new HttpClient())
        //    {
        //        HttpResponseMessage message = await http.GetAsync($"https://BelgianCavesRegister.Dal/Entities/ScientificData/{scientificData_Id}");

        //        if (message.IsSuccessStatusCode)
        //        {
        //            return await message.Content.ReadFromJsonAsync<ScientificData>();
        //        }
        //    }
        //    return null;
        //}
        public ScientificData? Delete(int scientificData_Id)
        {

            //string ToDelete;
            string sql = "DELETE FROM ScientificData WHERE ScientificData_Id = @scientificData_Id";
            return _connection.QueryFirst<ScientificData>(sql, new { scientificData_Id });
        }
        public ScientificData? Update(int scientificData_Id, string dataType, string detailsData, string referenceData)
        {
   
            //string ToUpdate;
            string sql = "UPDATE ScientificData SET DataType = @dataType, DetailsData = @detailsData, ReferenceData = @referenceData  WHERE ScientificData_Id = @scientificData_Id";
            var param = new { scientificData_Id, dataType, detailsData, referenceData };
            return _connection.QueryFirst<ScientificData>(sql, param);
        }
    }
}
