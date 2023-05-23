using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Models
{
    [Table("pais")]
    public class Pais
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }
        public string NmPais { get; set; }
        public string SiglaPais { get; set; }
        public string DdiPais { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltAlteracao { get; set; }
        public bool IsAtivo { get; set; }

        public Pais(string nmPais, string siglaPais, string ddiPais)
        {
            NmPais = nmPais;
            SiglaPais = siglaPais;
            DdiPais = ddiPais;
        }
        public Pais()
        {

        }
    }
}