using ProjetoCSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCSharp.DAL
{
    class MensagemDAO
    {
        private static Context context = new Context();
        public static List<Mensagem>buscarMensagens(int idDestin) {
            return context.Mensagens.Where(x => x.DestinatarioId.Equals(idDestin)).ToList();
        }

        public static void cadastrarMensagem (Mensagem mensagem)
        {
            context.Mensagens.Add(mensagem);

        }
    }
}
