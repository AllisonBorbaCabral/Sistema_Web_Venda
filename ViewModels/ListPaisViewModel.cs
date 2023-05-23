using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class ListPaisViewModel
{
    public ICollection<Pais> Paises { get; set; } = new List<Pais>();
}