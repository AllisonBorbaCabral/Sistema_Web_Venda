using System.ComponentModel.DataAnnotations;
using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class ModalProdutoViewModel
{
    [Display(Name = "Código")]
    public int Id { get; set; }
    [Display(Name = "Produto")]
    public string DsProduto { get; set; } = string.Empty;
    [Display(Name = "NCM")]
    public int Ncm { get; set; }
    [Display(Name = "UND")]
    public string Und { get; set; } = string.Empty;
    [Display(Name = "Cód. Grade de Cores")]
    public GradeCor gradeCor { get; set; }
    [Display(Name = "Cód. Grade de Tamanhos")]
    public GradeTamanho gradeTamanho { get; set; }
    [Display(Name = "Data de Cadastro")]
    public DateTime DataCadastro { get; set; }
    [Display(Name = "Data da Última Alteração")]
    public DateTime DataUltAlteracao { get; set; }
}