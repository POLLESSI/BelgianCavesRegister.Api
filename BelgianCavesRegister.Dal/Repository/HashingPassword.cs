using System;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.DataProtection;
using System.ComponentModel.DataAnnotations;

namespace BelgianCavesRegister.Dal.Repository
{
    public class HashPwd /*: IHashingPassword*/
    {
        private readonly SqlConnection _connection;

        public HashPwd(SqlConnection connection)
        {
            _connection = connection;
        }
        
        static byte[] GenerateSalt() 
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[16];
                rng.GetBytes(salt);
                return salt;
            }
        }

        public async Task<string> CreateNUser(NUserDTO create)
        {
            string password = create.SecondPassword;

            //byte[] saltBytes = GenerateSalt();
            //// Hache le password avec le sel
            //string hashedPassword = HashPwd(password, saltBytes);
            //string base64Salt = Convert.ToBase64String(saltBytes);

            //byte[] retrievedSaltBytes = Convert.FromBase64String(base64Salt);

            //var nuser = new Models.NUserTest
            //{
            //    Pseudo = create.Pseudo,
            //    PasswordHash = base64Salt,
            //    SecondPassword = password,
            //    Email = "",
            //    Salt = retrievedSaltBytes,
            //    LastActiondatetime = DateTime.Now
            //};
            //_connection.NUsertests.AddAsync(nuser);
            //await _connection/*.SaveChangesAsync*/();

            return "New User added successfully";

        }

        //public async Task<string> NUserVerify(NUserDTO verify)
        //{
        //    //var nuser = _connection.NUsertests.Where(x => x.Email == verify.Email).Select(x => x).FirstOrDefault();
        //    //string storedHashedPassword = nuser.SecondPassword; // Hachage du password de la database;
        //    ////string storedSalt = nuser.Salt; // Sel de la database;
        //    //byte[] storedSaltBytes = nuser.Salt;
        //    //string enteredPassword = verify.SecondPassword; //"Utilisateur entrant password"

        //    //// Convertir le sel stocké en le password entré dans un tableau de bytes
        //    //// byte[] storedSaltBytes = Convert.FromBase64String(nuser.Salt);
        //    //byte[] enteredPasswordBytes = Encoding.UTF8.GetBytes(enteredPassword);

        //    //// Concatene le password entré et le sel stocké
        //    //byte[] saltedPassword = new byte[enteredPasswordBytes.Length + storedSaltBytes.Length];
        //    //Buffer.BlockCopy(enteredPasswordBytes, 0, saltedPassword, 0, enteredPasswordBytes.Length);
        //    //Buffer.BlockCopy(storedSaltBytes, 0, saltedPassword, enteredPasswordBytes.Length, storedSaltBytes.Length);

        //    //// Hacher la valeur concaténée
        //    //string enteredPasswordHash = HashPwd(enteredPassword, storedSaltBytes);

        //    // Compare le password entré haché avec le hachage stocké
        //    //if (enteredPasswordHash == storedHashedPassword)
        //    //{
        //    //    return "Password is correct.";
        //    //}
        //    //else
        //    //{
        //    //    return "Password is incorrect.";
        //    //}
        //}
    }
}
