using System.ComponentModel.DataAnnotations;

namespace AspNetCore.ViewModels;

public class ModalCondicaoPagtoViewModel
{
    [Display(Name = "Código")]
    public int Id { get; set; }
    [Display(Name = "Condição de Pagto")]
    public string DsCondicaoPagto { get; set; } = string.Empty;
    [Display(Name = "Multa")]
    public decimal Multa { get; set; }
    [Display(Name = "Juros")]
    public decimal Juros { get; set; }
    [Display(Name = "Desconto Financeiro")]
    public decimal DescFinanceiro { get; set; }
    [Display(Name = "Data de Cadastro")]
    public DateTime DataCadastro { get; set; }
    [Display(Name = "Data da Última Alteração")]
    public DateTime DataUltAlteracao { get; set; }
}