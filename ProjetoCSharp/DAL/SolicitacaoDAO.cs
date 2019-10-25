using ProjetoCSharp.Models;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace ProjetoCSharp.DAL

{

    class SolicitacaoDAO

    {

        private static Context context = new Context();



        public static Solicitacao ConsultarAgenda(StringBuilder horario, string semana, Autonomo autonomo)

        {



            string consulta = Convert.ToString(horario);



            return context.Solicitacoes.Include("Autonomo").FirstOrDefault(x => x.Autonomo.Id == autonomo.Id && x.Agendamento.Equals(consulta));



        }



        public static void SalvarAgendamento(Solicitacao solicitacao)

        {



            context.Solicitacoes.Add(solicitacao);

            context.SaveChanges();



        }



    }

}