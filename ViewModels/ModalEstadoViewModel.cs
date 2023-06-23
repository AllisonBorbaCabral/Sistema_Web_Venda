using System.ComponentModel.DataAnnotations;
using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class ModalEstadoViewModel
{
    [Display(Name = "Código")]
    public int Id { get; set; }
    [Display(Name = "Estado")]
    public string NmEstado { get; set; } = string.Empty;
    [Display(Name = "UF")]
    public string Uf { get; set; } = string.Empty;
    [Display(Name = "País")]
    public Pais pais { get; set; }
    [Display(Name = "Data de Cadastro")]
    public DateTime DataCadastro { get; set; }
    [Display(Name = "Data da Última Alteração")]
    public DateTime DataUltAlteracao { get; set; }
}