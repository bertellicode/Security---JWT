namespace Security.Application.ViewModels
{
    public class LoginReturnViewModel
    {
        public LoginReturnViewModel()
        {
            Succeeded = false;
        }

        public bool Succeeded { get; set; }

        public TokenViewModel Token { get; set; }
    }
}
