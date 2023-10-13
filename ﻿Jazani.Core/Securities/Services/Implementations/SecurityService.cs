using _Jazani.Core.Securities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _﻿Jazani.Core.Securities.Services.Implementations
{
    public class SecurityService:ISecurityService
    {

        public SecurityService() { }

        public string HashPassword(string userName, string hashedPassword)
        {
            //throw new NotImplementedException();

            PasswordHasher<string?> passwordHasher= new PasswordHasher<string>();

            return passwordHasher.HashPassword(userName, hashedPassword);
        }


        public bool VerifyHashedPassword(string userName, string hashedPassword, string providerPassword)
        {
            //throw new NotImplementedException();
            PasswordHasher<string?> passwordHasher = new PasswordHasher<string>();

            PasswordVerificationResult? result = passwordHasher.VerifyHashedPassword(userName, hashedPassword, providerPassword);

            if (result == PasswordVerificationResult.Success) return true;

            return false;

        }

        public SecurityEntity JwtSecurity(string jwtSecrectKey)
        {
            // Obtiene la hora actual en formato UTC
            DateTime utcNow = DateTime.UtcNow;

            // Crea una lista de reclamaciones (claims) para el token
            List<Claim?> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, utcNow.ToString())
            };

            // Define la fecha y hora de vencimiento del token (1 día a partir de la hora actual)
            DateTime expireDateTime = utcNow.AddDays(1);

            // Crea un manejador de tokens JWT
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            //// Key + credentials
            // Convierte la clave secreta en bytes.
            byte[] key = Encoding.ASCII.GetBytes(jwtSecrectKey);
            // Crea una clave simétrica de seguridad a partir de la clave secreta
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(key);
            // Define las credenciales de firma para el token
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            // Crea el token JWT con las reclamaciones y las credenciales de firma.
            JwtSecurityToken? jwtSecurityToken = new JwtSecurityToken(
                claims: claims,
                expires: expireDateTime,
                notBefore: utcNow,
                signingCredentials: signingCredentials
            );

            // Genera el token en formato JWT como una cadena.
            string token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);


            // Crea y retorna una entidad SecurityEntity que contiene el token y detalles relacionados.
            return new SecurityEntity()
            {
                TokenType = "Bearer",
                AccesToken = token,
                ExpireOn = expireDateTime
            };
        }


    }
}
