using System.ComponentModel.DataAnnotations;
using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class ModalCidadeViewModel
{
    [Display(Name = "Código")]
    public int Id { get; set; }
    [Display(Name = "Cidade")]
    public string NmCidade { get; set; } = string.Empty;
    [Display(Name = "DDD")]
    public string Ddd { get; set; } = string.Empty;
    [Display(Name = "Estado")]
    public Estado estado { get; set; }
    [Display(Name = "Data de Cadastro")]
    public DateTime DataCadastro { get; set; }
    [Display(Name = "Data da Última Alteração")]
    public DateTime DataUltAlteracao { get; set; }
}