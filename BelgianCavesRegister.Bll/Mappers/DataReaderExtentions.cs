using BelgianCavesRegister.Bll.Entities;
using BelgianCavesRegister.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BelgianCavesRegister.Bll.Mappers
{
    internal static class DataReaderExtentions
    {
        internal static BibliographyDTO BiBllToDal(this BibliographyPOCO model)
        {
            return new BibliographyDTO()
            {
                Bibliography_Id = model.Bibliography_Id,
                Title = model.Title,
                Author = model.Author,
                ISBN = model.ISBN,
                DataType = model.DataType,
                Detail = model.Detail,
                Active = model.Active,
            };
        }
        internal static BibliographyPOCO BiDalToBll(this BibliographyDTO entity)
        {
            if (entity is null) return null;
            return new BibliographyPOCO()
            {
                Bibliography_Id = entity.Bibliography_Id,
                Title = entity.Title,
                Author = entity.Author,
                ISBN = entity.ISBN,
                DataType = entity.DataType,
                Detail = entity.Detail,
                Active = entity.Active,
            };
        }
        internal static LambdaDataDTO LaBllToDal(this LambdaDataPOCO model)
        {
            return new LambdaDataDTO()
            {
                DonneesLambda_Id = model.DonneesLambda_Id,
                Localisation = model.Localisation,
                Topo = model.Topo,
                Acces = model.Acces,
                EquipementSheet = model.EquipementSheet,
                PracticalInformation = model.PracticalInformation,
                Description = model.Description,
                Active = model.Active
            };
        }
        internal static LambdaDataPOCO LaDalToBll(this LambdaDataDTO entity)
        {
            if (entity is null) return null;
            return new LambdaDataPOCO()
            {
                DonneesLambda_Id = entity.DonneesLambda_Id,
                Localisation = entity.Localisation,
                Topo = entity.Topo,
                Acces = entity.Acces,
                EquipementSheet = entity.EquipementSheet,
                PracticalInformation = entity.PracticalInformation,
                Description = entity.Description,
                Active = entity.Active
            };
        }
        internal static NUserDTO NuBllToDal(this NUserPOCO model)
        {
            return new NUserDTO()
            {
                NUser_Id = model.NUser_Id,
                Pseudo = model.Pseudo,
                Email = model.Email,
                PasswordHash = model.PasswordHash,
                NPerson_Id = model.NPerson_Id,
                Active = model.Active
            };
        }
        internal static NUserPOCO NuDalTaBll(this NUserDTO entity)
        {
            if (entity is null) return null;
            return new NUserPOCO()
            {
                NUser_Id = entity.NUser_Id,
                Pseudo = entity.Pseudo,
                Email = entity.Email,
                PasswordHash = entity.PasswordHash,
                NPerson_Id = entity.NPerson_Id,
                Active = entity.Active
            };
        }
        //internal static NPersonDTO NpBllToDal(this NPersonPOCO newPoco)
        //{
        //    return new NPersonDTO()
        //    {
        //        NPerson_Id = newPoco.NPerson_Id,
        //        Lastname = newPoco.Lastname,
        //        Firstname = newPoco.Firstname,
        //        BirthDate = newPoco.BirthDate,
        //        Address_Street = newPoco.Address_Street,
        //        Address_Nbr = newPoco.Address_Nbr,
        //        PostalCode = newPoco.PostalCode,
        //        Address_City = newPoco.Address_City,
        //        Address_Country = newPoco.Address_Country,
        //        Active = newPoco.Active
        //    };
        //}
        //internal static NPersonPOCO NpDalToBll(this NPersonDTO newDto)
        //{
        //    if (newDto is null) return null;
        //    return new NPersonPOCO()
        //    {
        //        NPerson_Id = newDto.NPerson_Id,
        //        Lastname = newDto.Lastname,
        //        Firstname = newDto.Firstname,
        //        BirthDate = newDto.BirthDate,
        //        Address_Street = newDto.Address_Street,
        //        Address_Nbr = newDto.Address_Nbr,
        //        PostalCode = newDto.PostalCode,
        //        Address_City = newDto.Address_City,
        //        Address_Country = newDto.Address_Country,
        //        Active = newDto.Active
        //    };
        //}
        internal static NOwnerDTO NoBllToDal(this NOwnerPOCO model)
        {
            return new NOwnerDTO()
            {
                NOwner_Id = model.NOwner_Id,
                Status = model.Status,
                Agreement = model.Agreement,
                Active = model.Active
            };
        }
        internal static NOwnerPOCO NoDalToBll(this NOwnerDTO entity)
        {
            if (entity is null) return null;
            return new NOwnerPOCO()
            {
                NOwner_Id = entity.NOwner_Id,
                Status = entity.Status,
                Agreement = entity.Agreement,
                Active = entity.Active
            };
        }
        internal static ScientificDataDTO ScBllToDal(this ScientificDataPOCO model)
        {
            return new ScientificDataDTO()
            {
                ScientificData_Id = model.ScientificData_Id,
                DataType = model.DataType,
                DetailsData = model.DetailsData,
                ReferenceData = model.ReferenceData,
                Active = model.Active
            };
        }
        internal static ScientificDataPOCO ScDalToBll(this ScientificDataDTO entity)
        {
            if (entity is null) return null;
            return new ScientificDataPOCO()
            {
                ScientificData_Id = entity.ScientificData_Id,
                DataType = entity.DataType,
                DetailsData = entity.DetailsData,
                ReferenceData = entity.ReferenceData,
                Active = entity.Active
            };
        }
        internal static SiteDTO SiBllToDal(this SitePOCO model)
        {
            return new SiteDTO()
            {
                Site_Id = model.Site_Id,
                Site_Name = model.Site_Name,
                Site_Description = model.Site_Description,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Length = model.Length,
                Depth = model.Depth,
                AccessRequirement = model.AccessRequirement,
                PracticalInformation = model.PracticalInformation,
                DonneesLambda_Id = model.DonneesLambda_Id,
                NOwner_Id = model.NOwner_Id,
                ScientificData_Id = model.ScientificData_Id,
                Bibliography_Id = model.Bibliography_Id,
                Active = model.Active
            };
        }
        internal static SitePOCO SiDalToBll(this SiteDTO entity)
        {
            if (entity is null) return null;
            return new SitePOCO()
            {
                Site_Id = entity.Site_Id,
                Site_Name = entity.Site_Name,
                Site_Description = entity.Site_Description,
                Latitude = entity.Latitude,
                Longitude = entity.Longitude,
                Length = entity.Length,
                Depth = entity.Depth,
                AccessRequirement = entity.AccessRequirement,
                PracticalInformation = entity.PracticalInformation,
                DonneesLambda_Id = entity.DonneesLambda_Id,
                NOwner_Id = entity.NOwner_Id,
                ScientificData_Id = entity.ScientificData_Id,
                Bibliography_Id = entity.Bibliography_Id,
                Active = entity.Active
            };
        }
    }
}

