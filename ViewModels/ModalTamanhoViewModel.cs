using System.ComponentModel.DataAnnotations;
using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class ModalTamanhoViewModel
{
    [Display(Name = "Código")]
    public int Id { get; set; }
    [Display(Name = "Cidade")]
    public string DsTamanho { get; set; } = string.Empty;
    [Display(Name = "Data de Cadastro")]
    public DateTime DataCadastro { get; set; }
    [Display(Name = "Data da Última Alteração")]
    public DateTime DataUltAlteracao { get; set; }
}