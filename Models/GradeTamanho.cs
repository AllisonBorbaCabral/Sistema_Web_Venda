using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Models
{
    [Table("grade_tamanho")]
    public class GradeTamanho:Pai
    {
        public string Descricao { get; set; }
        public ICollection<Tamanho> Tamanhos { get; set; } = new List<Tamanho>();
        public bool IsAtivo { get; set; }

        public GradeTamanho(string descricao, ICollection<Tamanho> tamanhos)
        { 
            Descricao = descricao;
            Tamanhos = tamanhos;
        }
        public GradeTamanho()
        { }
    }
}