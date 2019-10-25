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
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class Chat : Window
    {
        Mensagem mensagem = new Mensagem();
        Login login = new Login();
        Autonomo au = new Autonomo();
        Cliente cli = new Cliente();

        public Chat()
        {
            InitializeComponent();
        }

        public Chat(Autonomo a, Cliente c)
        {
            InitializeComponent();
            au = a;
            cli = c;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void BtnEnviarMsg_Click(object sender, RoutedEventArgs e)
        {

            Mensagem mensagem = new Mensagem()
            {
                //enviar ao banco como remetendeID e DestinatarioID
                Texto = txtMsg.Text,
                DestinatarioId = au.Id,
                RemetenteId = cli.Id,
                CriadoEm = DateTime.Now
            };

            MensagemDAO.cadastrarMensagem(mensagem);
            MessageBox.Show("Mensagem enviada com sucesso!",
                    "DIJJ Variedades", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            LimparCampo();
        }

        private void LimparCampo()
        {
            txtMsg.Clear();
        }

        private void Historico_Click(object sender, RoutedEventArgs e)
        {
            HistoricoMensagem hm = new HistoricoMensagem();
            hm.ShowDialog();
        }

    }
}
