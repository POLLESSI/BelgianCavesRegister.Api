using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelgianCavesRegister.Bll.Models;
using BelgianCavesRegister.Dal.Entities;
using Microsoft.AspNetCore.Identity;

namespace BelgianCavesRegister.Bll.Mappers
{
    public static class Mapper
    {
        internal static NUser BllToDal(this NUserModel model)
        {
            return new NUser()
            {
                NUser_Id = model.NUser_Id,
                Pseudo = model.Pseudo,
                PasswordHash = model.PasswordHash,
                Email = model.Email,
                NPerson_Id = model.NPerson_Id,
                Role_Id = model.Role_Id
            };
        }

        internal static NUserModel DalToBll(this NUser entity) 
        {
            if (entity is null) return null;
            return new NUserModel()
            {
                NUser_Id = entity.NUser_Id,
                Pseudo = entity.Pseudo,
                PasswordHash = entity.PasswordHash,
                Email = entity.Email,
                NPerson_Id = entity.NPerson_Id,
                Role_Id = entity.Role_Id
            };
        }
    }
}
