//using System.Data;
//using BelgianCaveRegister_Api.Dto.Forms;
//using BelgianCaveRegister_Api.Models;

//namespace BelgianCaveRegister_Api.Mappers
//{
//    internal static class DataRecordExtentions
//    {
//        internal static BibliographyDTO ToBibliography(this IDataRecord record)
//        {
//            return new BibliographyDTO()
//            {
//                Bibliography_Id = (int)record["Bibliography_Id"],
//                Title = (string)record["Title"],
//                Author = (string)record["Author"],
//                ISBN = (int)record["ISBN"],
//                DataType = (string)record["DataType"],
//                Detail = (string)record["Detail"],
//                Active = (bool)record["active"],
//            };
//        }
//        internal static LambdaDataDTO ToLambdadata(this IDataRecord record)
//        {
//            return new LambdaDataDTO()
//            {
//                DonneesLambda_Id = (int)record["DonneesLambda_Id"],
//                Localisation = (string)record["Localisation"],
//                Topo = (string)record["Topo"],
//                Acces = (string)record["Acces"],
//                EquipementSheet = (string)record["EquipementSheet"],
//                PracticalInformation = (string)record["PracticalInformation"],
//                Description = (string)record["Description"],
//                Active = (bool)record["active"]
//            };
//        }
//        internal static NUserDTO ToNuser(this IDataRecord record)
//        {
//            return new NUserDTO()
//            {
//                NUser_Id = (Guid)record["NUser_Id"],
//                Pseudo = (string)record["Pseudo"],
//                PasswordHash = (string)record["Password"],
//                Email = (string)record["Email"],
//                Role_Id = (int)record["Role_Id"],
//                NPerson_Id = (int)record["NPerson_Id"],
//                Active = (bool)record["Active"]
//            };
//        }
//        //internal static NPersonDTO ToPerson(this IDataRecord record)
//        //{
//        //    return new NPersonDTO()
//        //    {
//        //        NPerson_Id = (int)record["NPerson_Id"],
//        //        Lastname = (string)record["Lastname"],
//        //        Firstname = (string)record["Firstname"],
//        //        BirthDate = (DateTime)record["BirthDate"],
//        //        Address_Street = (string)record["Address_Street"],
//        //        Address_Nbr = (int)record["Record"],
//        //        PostalCode = (int)record["PostalCode"],
//        //        Address_City = (string)record["address_City"],
//        //        Telephone = (int)record["Telephone"],
//        //        Gsm = (int)record["Gsm"],
//        //        Active = (bool)record["Active"]
//        //    };
//        //}
//        internal static NUserDTO ApiToBll(this NUserRegisterForm form)
//        {
//            return new NUserDTO()
//            {
//                Pseudo = form.Pseudo,
//                Email = form.Email,
//                PasswordHash = form.PasswordHash,
//            };
//        }
//        internal static NUserViewModel BllToApi(this NUserDTO nUser)
//        {
//            return new NUserViewModel()
//            {
//                NUser_Id = nUser.NUser_Id,
//                Pseudo = nUser.Pseudo,
//                Email = nUser.Email,
//            };
//        }
//        internal static NUserViewModel BllToApi(this NUserPOCO nUser)
//        {
//            return new NUserViewModel()
//            {
//                NUser_Id = nUser.NUser_Id,
//                Pseudo = nUser.Pseudo,
//                Email = nUser.Email,
//            };
//        }
//        internal static NUserLogin NuBllToApi(this NUserPOCO nUser)
//        {
//            return new NUserLogin()
//            {
//                Email = nUser.Email,
//                PasswordHash = nUser.PasswordHash
//            };
//        }
//        internal static NUserLogin NuApiToBll(this NUserDTO nUser)
//        {
//            if (nUser is null) return null;
//            return new NUserLogin()
//            {
//                Email = nUser.Email,
//                PasswordHash = nUser.PasswordHash,
//            };
//        }
//        internal static NOwnerDTO ToNOwner(this IDataRecord record)
//        {
//            return new NOwnerDTO()
//            {
//                NOwner_Id = (int)record["NOwner_Id"],
//                Status = (string)record["Status"],
//                Agreement = (string)record["Agreement"],
//                Active = (bool)record["active"]
//            };
//        }
//        internal static ScientificDataDTO ToScientificData(this IDataRecord record)
//        {
//            return new ScientificDataDTO()
//            {
//                ScientificData_Id = (int)record["ScientificData_Id"],
//                DataType = (string)record["Datatype"],
//                DetailData = (string)record["DetailData"],
//                ReferenceData = (string)record["ReferenceData"],
//                Active = (bool)record["active"]
//            };
//        }
//        internal static SiteDTO ToSite(this IDataRecord record)
//        {
//            return new SiteDTO()
//            {
//                Site_Id = (int)record["Site_Id"],
//                Site_Name = (string)record["Site_Name"],
//                Site_Description = (string)record["Site_Description"],
//                Latitude = (double)record["Latitude"],
//                Longitude = (double)record["Longitude"],
//                Length = (decimal)record["Length"],
//                Depth = (decimal)record["Depth"],
//                AccessRequirement = (string)record["AccessRequirement"],
//                PracticalInformation = (string)record["PracticalInformation"],
//                DonneesLambda_Id = (int)record["DonneesLambda_Id"],
//                NOwner_Id = (int)record["Owner_Id"],
//                ScientificData_Id = (int)record["ScientificData_Id"],
//                Bibliography_Id = (int)record["Bibliography"],
//                Active = (bool)record["Active"]
//            };
//        }
//    }
//}

