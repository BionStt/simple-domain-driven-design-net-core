using Microsoft.IdentityModel.Tokens;
using MinimalDDD.Domain.Aggregations.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using TGAuth.Service.Auth;

namespace MinimalDDD.Api.Auth
{
    public static class JWTService
    {
        public async static Task<AuthenticationReturn> JWTAuthorization(
            this User user,
            SigningConfigurations signingConfigurations,
            TokenConfigurations tokenConfigurations)
        {

            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")));
            claims.Add(new Claim(JwtRegisteredClaimNames.Sid, user.Email.ToString()));

            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.Email.ToString(), "Login"), claims);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddDays(1);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            };

            SecurityToken securityToken = handler.CreateToken(securityTokenDescriptor);

            string token = handler.WriteToken(securityToken);

            return new AuthenticationReturn()
            {
                Authenticated = true,
                Created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                AccessToken = token,
                UserAuthorized = user,
                Message = "App Authorized",
            };
        }
    }
}
