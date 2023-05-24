using System.ComponentModel.DataAnnotations;

namespace AspNetCore.ViewModels;

public class ModalPaisViewModel
{
    [Display(Name = "Código")]
    public int Id { get; set; }
    [Display(Name = "País")]
    public string NmPais { get; set; } = string.Empty;
    [Display(Name = "Sigla")]
    public string SiglaPais { get; set; } = string.Empty;
    [Display(Name = "DDI")]
    public string DdiPais { get; set; } = string.Empty;
    [Display(Name = "Data de Cadastro")]
    public DateTime DataCadastro { get; set; }
    [Display(Name = "Data da Última Alteração")]
    public DateTime DataUltAlteracao { get; set; }
}