using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Models
{
    [Table("estoque")]
    public class Estoque
    {
        
        public int Referencia { get; set; }
        public Produto produto { get; set; }
        public Cor cor { get; set; }
        public Tamanho tamanho { get; set; }
        public int Qtd { get; set; }
        public decimal VlrCompra { get; set; }
        public decimal VlrVenda { get; set; }
        public decimal PercVenda { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltAlteracao { get; set; }
        public bool IsAtivo { get; set; }

        public Estoque(int referencia, Produto objProd, Cor objCor, Tamanho objTamanho, int qtd, decimal vlrCompra, decimal vlrVenda, decimal percVenda)
        {
            Referencia = referencia;
            produto = objProd;
            cor = objCor;
            tamanho = objTamanho;
            Qtd = qtd;
            VlrCompra = vlrCompra;
            VlrVenda = vlrVenda;
            PercVenda = percVenda;
        }

        public Estoque()
        {

        }
    }
}