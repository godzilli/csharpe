using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCSharp.Models
{
    [Table("Agenda")]
    public partial class Agenda
    {

        public Agenda()
        {
            CriadoEm = DateTime.Now;
        }

        [Key]
        public int AgendaId { get; set; }
        public string Semana { get; set; }
        public string CargaHoraria { get; set; }
        public string InicioExpediente { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
