using System;

namespace Security.Application.ViewModels
{
    public class TokenViewModel
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        public string AccessToken { get; set; }

        public DateTime ExpiresIn { get; set; }
    }
}
