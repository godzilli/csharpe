using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCSharp.Models
{
    class Context : DbContext
    {

        public Context() : base("DbProjetoCSharp2") { }

        public DbSet<Autonomo> Autonomos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Solicitacao> Solicitacoes { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }

    }
}
