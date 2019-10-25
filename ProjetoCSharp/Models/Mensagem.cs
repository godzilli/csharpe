using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCSharp.Models
{   
    [Table("Mensagem")]
    class Mensagem
    {

        public Mensagem()
        {
            CriadoEm = DateTime.Now;
        }

        [Key]
        public int MensagemId { get; set; }
        public int RemetenteId { get; set; }
        public int DestinatarioId { get; set; }
        public String Texto { get; set; }
        public DateTime CriadoEm { get; set; }

    }
}
