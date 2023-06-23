using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Models
{
    [Table("forma_pagto")]
    public class FormaPagto
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }
        public string DsFormaPagto { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltAlteracao { get; set; }
        public bool IsAtivo { get; set; }

        public FormaPagto(string dsFormaPagto)
        {
            DsFormaPagto = dsFormaPagto;
        }

        public FormaPagto()
        {

        }
    }
}