using ProjetoCSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ProjetoCSharp.DAL
{

    class UsuarioDAO
    {
        private static Context context = new Context();

        private UsuarioDAO()
        {

        }

        public static Cliente autenticarCliente(string email, string senha)
        {
            return context.Clientes.FirstOrDefault(x => x.Email.Equals(email) && x.Senha.Equals(senha));
        }

        public static Autonomo autenticarAutonomo(string email, string senha)
        {
            //public static List<Produto> ListarProdutos() => ctx.Produtos.Include("Categoria").ToList();
            return context.Autonomos.Include("Servico").Include("Agenda").FirstOrDefault(x => x.Email.Equals(email) && x.Senha.Equals(senha));
      
        }

        public static void CadastrarUsuario(Cliente cliente)
        {
            context.Clientes.Add(cliente);
            context.SaveChanges();
        }

        public static void CadastrarUsuario(Autonomo autonomo)
        {
            Autonomo ai = new Autonomo();

            ai = context.Autonomos.FirstOrDefault(x => x.Id == autonomo.Id);
            if (ai != null)

            {
                ai.Nome = autonomo.Nome;
                ai.Cpf = autonomo.Cpf;
                ai.Cep = autonomo.Cep;
                ai.Rua = autonomo.Rua;
                ai.NumCasa = autonomo.NumCasa;
                ai.Bairro = autonomo.Bairro;
                ai.Cidade = autonomo.Cidade;
                ai.Estado = autonomo.Estado;
                ai.Email = autonomo.Email;
                ai.Senha = autonomo.Senha;
                ai.Foto = autonomo.Foto;
                ai.Telefone = autonomo.Telefone;
                
                context.SaveChanges();
            }

            else
            {
                context.Autonomos.Add(autonomo);
                context.SaveChanges();
            }
        }

        public static List<Servico> buscarAutonomos(string pesquisa)
        {
            return context.Servicos.Include("Autonomo").Where(x => x.Descricao.Contains(pesquisa)).ToList();
        }

        public static Servico buscarAutonomos(Autonomo autonomo)
        {
            //É tipo quando puxamos o autonomo do bd mas o contrário, mas estou em dúvida a respeito daquele tolist
            //É tipo quando puxamos o autonomo do bd mas o contrário, mas estou em dúvida a respeito daquele tolist
            return context.Servicos.Include("Autonomo").FirstOrDefault(x => x.Autonomo.Id.Equals(autonomo.Id));

        }

        public static int quantRegistros()
        {
            return context.Autonomos.Count();
        }

        public static void mensagem(Mensagem mensagem)
        {
            context.Mensagens.Add(mensagem);
            context.SaveChanges();
        }
    }

}
