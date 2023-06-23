using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class ListTamanhoViewModel
{
    public ICollection<Tamanho> Tamanhos { get; set; } = new List<Tamanho>();
}