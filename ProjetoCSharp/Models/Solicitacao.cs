using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCSharp.Models
{
    [Table("Solicitacao")]
    class Solicitacao
    {

        public Solicitacao()
        {
            CriadoEm = DateTime.Now;
        }
        [Key]
        public int SolicitacaoId { get; set; }
        [Required]
        public Cliente Cliente { get; set; }
        [Required]
        public Autonomo Autonomo { get; set; }
        public Servico Formulario { get; set; }
        public String Agendamento { get; set; }
        public double Avaliacao { get; set; }
        public string Comentario { get; set; }
        public DateTime CriadoEm { get; set; }

    }
}
