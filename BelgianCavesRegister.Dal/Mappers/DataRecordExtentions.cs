using BelgianCavesRegister.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BelgianCavesRegister.Dal.Mappers
{
    internal static class DataRecordExtentions
    {
        internal static BibliographyDTO DbToBibliography(this IDataRecord record)
        {
            return new BibliographyDTO()
            {
                Title = (string)record["Title"],
                Author = (string)record["Author"],
                ISBN = (int)record["ISBN"],
                DataType = (string)record["DateType"],
                Detail = (string)record["Detail"],
                Active = (bool)record["Active"]
            };
        }
        internal static LambdaDataDTO DbToLambdaData(this IDataRecord record)
        {
            return new LambdaDataDTO()
            {
                Localisation = (string)record["Localisation"],
                Topo = (string)record["Topo"],
                Acces = (string)record["Acces"],
                EquipementSheet = (string)record["EquiêmentSheet"],
                PracticalInformation = (string)record["PracticalInformation"],
                Description = (string)record["Description"],
                Active = (bool)record["Active"]
            };
        }
        internal static NUserDTO DbToNUser(this IDataRecord record)
        {
            return new NUserDTO()
            {
                Pseudo = (string)record["Pseudo"],
                Email = (string)record["Email"],
                NPerson_Id = (int)record["NPerson_Id"],
                Role_Id = (int)record["IsAdmin"],
                Active = (bool)record["Active"],
            };
        }
        internal static NPersonDTO DbToNPerson(this IDataRecord record)
        {
            return new NPersonDTO()
            {
                Lastname = (string)record["Lastname"],
                Firstname = (string)record["Firstname"],
                BirthDate = (DateTime)record["BirthDate"],
                Address_Street = (string)record["Address_Street"],
                Address_Nbr = (int)record["Addess_Nbr"],
                PostalCode = (int)record["PostalCode"],
                Address_City = (string)record["Address_City"],
                Telephone = (int)record["Telephone"],
                Gsm = (int)record["Gsm"],
                Active = (bool)record["Active"]
            };
        }
        internal static NOwnerDTO DbToNOwner(this IDataRecord record)
        {
            return new NOwnerDTO()
            {
                Status = (string)record["Status"],
                Agreement = (string)record["Agreement"],
                Active = (bool)record["Active"]
            };
        }
        internal static ScientificDataDTO DbToScientificData(this IDataRecord record)
        {
            return new ScientificDataDTO()
            {
                DataType = (string)record["DataType"],
                DetailsData = (string)record["DetailsData"],
                ReferenceData = (string)record["ReferenceData"],
                Active = (bool)record["Active"]
            };
        }
        internal static SiteDTO DbToSite(this IDataRecord record)
        {
            return new SiteDTO()
            {
                Site_Name = (string)record["Site_Name"],
                Site_Description = (string)record["Site_Description"],
                Latitude = (double)record["Latitude"],
                Longitude = (double)record["Longitude"],
                Length = (decimal)record["Length"],
                Depth = (decimal)record["Depth"],
                AccessRequirement = (string)record["AccessRequirement"],
                PracticalInformation = (string)record["PracticalInformation"],
                DonneesLambda_Id = (int)record["DpnneesLambda_Id"],
                NOwner_Id = (int)record["Owner_Id"],
                ScientificData_Id = (int)record["ScientificData_Id"],
                Active = (bool)record["Active"],
            };
        }
    }
}

