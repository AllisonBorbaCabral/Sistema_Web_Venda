using System.ComponentModel.DataAnnotations;
using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class ModalEstoqueViewModel
{
    [Display(Name = "Referência")]
    public int Referencia { get; set; }
    [Display(Name = "Produto")]
    public Produto produto { get; set; }
    [Display(Name = "Cor")]
    public Cor cor { get; set; }
    [Display(Name = "Tamanho")]
    public Tamanho tamanho { get; set; }
    [Display(Name = "Quantidade")]
    public int Qtd { get; set; }
    [Display(Name = "Valor de Compra")]
    public decimal VlrCompra { get; set; }
    [Display(Name = "Valor de Venda")]
    public decimal VlrVenda { get; set; }
    [Display(Name = "Percentual de Venda")]
    public decimal PercVenda { get; set; }
    [Display(Name = "Data de Cadastro")]
    public DateTime DataCadastro { get; set; }
    [Display(Name = "Data da Última Alteração")]
    public DateTime DataUltAlteracao { get; set; }
}