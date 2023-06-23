using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Models
{
    [Table("condicao_pagto")]
    public class CondicaoPagto
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }
        public string DsCondicaoPagto { get; set; }
        public decimal Multa { get; set; }
        public decimal Juros { get; set; }
        public decimal DescFinanceiro { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltAlteracao { get; set; }
        public bool IsAtivo { get; set; }

        public CondicaoPagto(string dsCondicaoPagto, decimal multa, decimal juros, decimal descFinanceiro)
        {
            DsCondicaoPagto = dsCondicaoPagto;
            Multa = multa;
            Juros = juros;
            DescFinanceiro = descFinanceiro;
        }

        public CondicaoPagto()
        {

        }
    }
}