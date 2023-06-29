using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class CreateEstadoViewModel
{
    public int Id { get; set; }
    public string NmEstado { get; set; }
    public string Uf { get; set; }
    public Pais pais { get; set; }
}
