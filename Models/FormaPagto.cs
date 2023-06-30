using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Models
{
    [Table("forma_pagto")]
    public class FormaPagto:Pai
    {
        public string DsFormaPagto { get; set; }
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