using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class ListEstadoViewModel
{
    public ICollection<Estado> Estados { get; set; } = new List<Estado>();
}