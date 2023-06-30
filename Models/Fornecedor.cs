using AspNetCore.Models;

namespace AspNetCore
{
    class Fornecedor:Pessoa
    {
        public CondicaoPagto CondPag { get; set; }
        public string Observacao { get; set; }
    }
}