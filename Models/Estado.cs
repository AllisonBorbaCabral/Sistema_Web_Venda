using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Models
{
    [Table("estado")]
    public class Estado:Pai
    {
        public string NmEstado { get; set; }
        public string Uf { get; set; }
        public Pais pais { get;set; }
        public bool IsAtivo { get; set; }

        public Estado(string nmEstado, string ufEstado, Pais obj)
        {
            NmEstado = nmEstado;
            Uf = ufEstado;
            pais = obj;
        }
        public Estado()
        {

        }
    }
}