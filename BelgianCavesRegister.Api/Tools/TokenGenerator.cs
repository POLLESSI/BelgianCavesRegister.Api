﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BelgianCavesRegister.Bll.Entities;
using Microsoft.IdentityModel.Tokens;

namespace BelgianCavesRegister.Api.Tools
{
    public class TokenGenerator
    {
        public static string secretKey = "µpiçaezjrkuyjfgk:ghmkjghmiugl:hjfvtFSDMOifnZAE MOVjkµ$)'éàipornjfd ù)'$piç";

        public string GenerateToken(NUserPOCO nu)
        {
            //Génération de la clé de signature du token

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(secretKey));
            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha512);

            //Cr&ation du payload (donnée contenues dans le token)

            Claim[] userInfo = new[]
            {
                new Claim(ClaimTypes.Role,(nu.Role_Id == 3 ? "Admin" : nu.Role_Id == 2 ? "Modo" : "User")),
                new Claim(ClaimTypes.Sid, nu.NUser_Id.ToString()),
                new Claim(ClaimTypes.Email, nu.Email)
            };

            JwtSecurityToken jwt = new JwtSecurityToken(
                claims: userInfo,
                signingCredentials: credentials,
                expires: DateTime.Now.AddDays(1)
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(jwt);
        }
    }
}

