using System.ComponentModel.DataAnnotations;

namespace AspNetCore.ViewModels;

public class ModalFormaPagtoViewModel
{
    [Display(Name = "Código")]
    public int Id { get; set; }
    [Display(Name = "Forma de Pagto")]
    public string DsFormaPagto { get; set; } = string.Empty;
    [Display(Name = "Data de Cadastro")]
    public DateTime DataCadastro { get; set; }
    [Display(Name = "Data da Última Alteração")]
    public DateTime DataUltAlteracao { get; set; }
}