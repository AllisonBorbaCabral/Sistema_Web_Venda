using AspNetCore.Models;

namespace AspNetCore.ViewModels;

public class ListCondicaoPagtoViewModel
{
    public ICollection<CondicaoPagto> CondicoesPagto { get; set; } = new List<CondicaoPagto>();
}