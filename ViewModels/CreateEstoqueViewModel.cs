using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class CreateEstoqueViewModel
{
    public int Referencia { get; set; }
    public Produto produto { get; set; }
    public Cor cor { get; set; }
    public Tamanho tamanho { get; set; }
    public int Qtd { get; set; }
    public decimal VlrCompra { get; set; }
    public decimal VlrVenda { get; set; }
    public decimal PercVenda { get; set; }
}