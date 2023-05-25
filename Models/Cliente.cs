using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace crud_wpf_mvvm.Models;

public class Cliente : ObservableValidator
{
    private string _nome = string.Empty;
    private string _email = string.Empty;

    [Key]
    [Required()]
    public int Id { get; set; }

    [Required(ErrorMessage = "Favor informar o nome!")]
    [MinLength(3, ErrorMessage = "Favor informar pelo menos {1} caracteres!")]
    public string Nome { get => _nome; set => SetProperty(ref _nome, value, true); }

    [Required(ErrorMessage = "Favor informar o e-mail!")]
    [EmailAddress(ErrorMessage = "Favor informar um e-mail válido!")]
    public string Email { get => _email; set => SetProperty(ref _email, value, true); }

    public void ValidateAll()
    {
        ValidateAllProperties();
    }
}