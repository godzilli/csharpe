using ProjetoCSharp.DAL;
using ProjetoCSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjetoCSharp.Views
{
    /// <summary>
    /// Interaction logic for HistoricoMensagem.xaml
    /// </summary>
    public partial class HistoricoMensagem : Window
    {
        Mensagem mensagem = new Mensagem();

        public HistoricoMensagem()
        {
            InitializeComponent();
        }

        public HistoricoMensagem(Cliente cliente)
        {
            InitializeComponent();

            List<Mensagem> mensagens = MensagemDAO.buscarMensagens(cliente.Id);
            foreach (Mensagem m in mensagens)
            {
                historico.Content = "\n"+m.Texto + "\n" + m.RemetenteId.ToString();
            }
        }

        private void Fechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
