using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Models
{
    [Table("cidade")]
    public class Cidade
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }
        public string NmCidade { get; set; }
        public string Ddd { get; set; }
        public Estado estado { get;set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltAlteracao { get; set; }
        public bool IsAtivo { get; set; }

        public Cidade(string nmCidade, string dddCidade, Estado obj)
        {
            NmCidade = nmCidade;
            Ddd = dddCidade;
            estado = obj;
        }
        public Cidade()
        {

        }
    }
}