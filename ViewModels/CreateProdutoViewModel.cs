using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class CreateProdutoViewModel
{
    public string DsProduto { get; set; }
    public int Ncm { get; set; }
    public string Und { get; set; }
    public GradeCor gradeCor { get; set; }
    public GradeTamanho gradeTamanho { get; set; }
}