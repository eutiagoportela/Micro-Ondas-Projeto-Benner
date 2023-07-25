using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;

namespace Micro.WebUI.ViewModal;

public class RegistrarViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Senha { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirme a senha")]
    [Compare("Senha", ErrorMessage = "As senhas não correspondem")]
    public string ConfirmPassword { get; set; }
}
