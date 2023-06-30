using AspNetCore.Models;

namespace AspNetCore
{
    class Cliente:Pessoa
    {
        public CondicaoPagto CondPagto { get; set; }
    }
}