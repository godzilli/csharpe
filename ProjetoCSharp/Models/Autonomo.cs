using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCSharp.Models
{

    [Table("Autonomo")]
    public partial class Autonomo : Usuario
    {

        public Autonomo()
        {

            CriadoEm = DateTime.Now;
            Servico = new List<Servico>();
            Agenda = new Agenda();

        }

        [Required]
        public List<Servico> Servico { get; set; }  
        [Required]
        public Agenda Agenda { get; set; }

    }
}
