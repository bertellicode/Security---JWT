namespace Security.Application.ViewModels
{
    public class LoginReturnViewModel
    {
        public LoginReturnViewModel()
        {
            Succeeded = false;
        }

        public LoginReturnViewModel(TokenViewModel token)
        {
            Succeeded = true;
            Token = token;
        }

        public bool Succeeded { get; set; }

        public TokenViewModel Token { get; set; }
    }
}
