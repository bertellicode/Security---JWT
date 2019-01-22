using System;
using System.Collections.Generic;
using System.Text;

namespace Security.Domain.Users.DTOs
{
    public class TokenDto
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        public string AccessToken { get; set; }

        public DateTime ExpiresIn { get; set; }

        public TokenDto(string userName, string name, string accessToken, int minutesValid)
        {
            UserName = userName;
            Name = name;
            AccessToken = accessToken;
            ExpiresIn = DateTime.Now.AddMinutes(minutesValid);
        }
    }
}
