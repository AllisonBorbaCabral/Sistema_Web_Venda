using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class ListFormaPagtoViewModel
{
    public ICollection<FormaPagto> FormasPagto { get; set; } = new List<FormaPagto>();
}