using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Models
{
    [Table("grade_cor")]
    public class GradeCor:Pai
    {
        public string Descricao { get; set; }
        public ICollection<Cor> Cores { get; set; } = new List<Cor>();
        public bool IsAtivo { get; set; }

        public GradeCor(string descricao, ICollection<Cor> cores)
        { 
            Descricao = descricao;
            Cores = cores;
        }
        public GradeCor()
        {}
    }
}