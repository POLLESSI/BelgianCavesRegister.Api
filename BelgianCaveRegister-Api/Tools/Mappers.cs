using BelgianCavesRegister.Dal.Entities;
using BelgianCaveRegister_Api.Dto.Forms;

namespace BelgianCaveRegister_Api.Tools
{
    public static class Mappers
    {
        public static Bibliography BibliographyToDal(this BibliographyRegisterForm bi)
        {
            return new Bibliography
            {
                Title = bi.Title,
                Author = bi.Author,
                ISBN = bi.ISBN,
                DataType = bi.DataType,
                Detail = bi.Detail,
                //Active = bi.Active
            };
        }
        public static Chat ChatToDal(this Message ch)
        {
            return new Chat
            {
                NewMessage = ch.newMessage,
                Author = ch.Author,
            };
        }
        public static LambdaData LambdaDataToDal(this LambdaDataRegisterForm la) 
        {
            return new LambdaData
            {
                Localisation = la.Localisation,
                Topo = la.Topo,
                Acces = la.Acces,
                EquipementSheet = la.EquipementSheet,
                PracticalInformation = la.PracticalInformation,
                Description = la.Description,
                //Active = la.Active,
            };
        }
        public static NOwner NOwnerToDal(this NOwnerRegisterForm no) 
        {
            return new NOwner
            {
                Status = no.Status,
                Agreement = no.Agreement,
                //Active = no.Active,
            };
        }
        public static NPerson NPersonToDal(this NPersonForm np)
        {
            return new NPerson
            {
                Lastname = np.Lastname,
                Firstname = np.Firstname,
                BirthDate = np.BirthDate,
                Email = np.Email,
                Address_Street = np.Address_Street,
                Address_Nbr = np.Address_Nbr,
                PostalCode = np.PostalCode,
                Address_City = np.Address_City,
                Address_Country = np.Address_Country,
                Telephone = np.Telephone,
                Gsm = np.Gsm,
                Active = np.Active
            };
        }
        public static NUser NUserToDal(this NUserForm nu) 
        {
            return new NUser
            {
                Pseudo = nu.Pseudo,
                PasswordHash = nu.PasswordHash,
                Email = nu.Email,
                NPerson_Id = nu.NPerson_Id,
                Role_Id = nu.Role_Id,
                //Active = nu.Active,
            };
        }
        public static ScientificData ScientificDataToDal(this ScientificDataRegisterForm sc)
        {
            return new ScientificData
            {
                DataType = sc.DataType,
                DetailsData = sc.DetailsData,
                ReferenceData = sc.ReferenceData,
                //Active = sc.Active,
            };
        }
        public static Site SiteToDal(this SiteRegisterForm site)
        {
            return new Site
            {
                Site_Name = site.Site_Name,
                Site_Description = site.Site_Description,
                Latitude = site.Latitude,
                Longitude = site.Longitude,
                Length = site.Length,
                Depth = site.Depth,
                AccessRequirement = site.AccessRequirement,
                PracticalInformation = site.PracticalInformation,
                DonneesLambda_Id = site.DonneesLambda_Id,
                NOwner_Id = site.NOwner_Id,
                ScientificData_Id = site.ScientificData_Id,
                Bibliography_Id = site.Bibliography_Id,
            };
        }
    }
}
