using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Security.Domain.Users.DTOs;
using Security.Domain.Users.Entities;
using Security.Domain.Users.Interfaces.Repositories;
using Security.Domain.Users.Interfaces.Services;
using Security.Infra.CrossCutting.JWT.Interfaces;

namespace Security.Domain.Users.Services
{
    public class UserService : IUserService
    {
        private readonly ITokenConfiguration _tokenConfiguration;
        private readonly IUserRepository _userRepository;

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        public UserService(ITokenConfiguration tokenConfiguration,
                            IUserRepository userRepository)
        {
            _tokenConfiguration = tokenConfiguration;
            _userRepository = userRepository;
        }

        public async Task<TokenDto> GenerateToken(User user)
        {
            List<Claim> userClaims = await GenerateJWTTokens(user);

            ClaimsIdentity identityClaims = await GenerateIdentitiesClaims(user, userClaims);

            string encodedJwt = await _tokenConfiguration.GenerateToken(identityClaims);

            return new TokenDto(user.UserName, user.Name, encodedJwt, _tokenConfiguration.MinutesValid);
        }

        private async Task<List<Claim>> GenerateJWTTokens(User user)
        {
            return new List<Claim>
            {
                new Claim("primeiroNome", user.Name),
                new Claim("apelido", user.UserName),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64)
            };
        }

        private async Task<ClaimsIdentity> GenerateIdentitiesClaims(User user, List<Claim> userClaims)
        {
            userClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            userClaims.Add(new Claim(ClaimTypes.Name, user.UserName));
            userClaims.Add(new Claim(ClaimTypes.GivenName, user.Name));

            user.RoleList.ToList().ForEach(x => userClaims.Add(new Claim(ClaimTypes.Role, x.Role.Name.ToString())));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(userClaims);

            return identityClaims;
        }

        public Task<User> GetUser(string user, string password)
        {
            var userDb = _userRepository.GetUserIncludeRoles(user, password);

            return userDb;
        }
    }
}
