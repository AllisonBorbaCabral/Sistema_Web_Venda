using System.ComponentModel.DataAnnotations;

namespace AspNetCore.ViewModels;

public class ModalCorViewModel
{
    [Display(Name = "Código")]
    public int Id { get; set; }
    [Display(Name = "Cor")]
    public string DsCor { get; set; } = string.Empty;
    [Display(Name = "Data de Cadastro")]
    public DateTime DataCadastro { get; set; }
    [Display(Name = "Data da Última Alteração")]
    public DateTime DataUltAlteracao { get; set; }
}