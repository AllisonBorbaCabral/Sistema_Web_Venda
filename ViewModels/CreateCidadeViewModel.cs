using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class CreateCidadeViewModel
{
    public string NmCidade { get; set; }
    public string Ddd { get; set; }
    public Estado estado { get; set; }
}