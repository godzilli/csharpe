using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCSharp.Models
{
    [Table("Servico")]
    public partial class Servico
    {

        public Servico()
        {
            CriadoEm = DateTime.Now;
        }

        [Key]
        public int ServicoId { get; set; }
        public string Descricao{ get; set; }
        public string Categoria { get; set; }
        public double Valor { get; set; }
        public DateTime CriadoEm { get; set; }
        public Autonomo Autonomo { get; set; }

    }

}
