using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Security.Application.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Usuário obrigatorio.")]
        public string User { get; set; }

        [Required(ErrorMessage = "Senha obrigatoria.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
