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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetoCSharp.Views
{
    /// <summary>
    /// Interaction logic for PerfilC.xaml
    /// </summary>
    public partial class PerfilC : Window
    {
        Autonomo a = new Autonomo();
        Cliente cliente = new Cliente();

        public object Cad { get; private set; }

        public PerfilC(Cliente cliente)
        {

            InitializeComponent();

            this.cliente = cliente;

            if (cliente.Foto != null)
            {
                imgPerfil.Source = new BitmapImage(new Uri(cliente.Foto));
            }
            else
            {
                imgPerfil.Source = new BitmapImage(new Uri("Imagens/cliente.png"));
            }

        }

        private void Voltar(object sender, RoutedEventArgs e)
        {
            frmPrincipal p = new frmPrincipal();
            p.ShowDialog();
        }

        private void Sair(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PerfilC_Loaded(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            //printar
            NomeC.Content = cliente.Nome.ToString();
            Info.Content += "\n" + cliente.Telefone.ToString();
            Info.Content += "\n" + cliente.Cidade.ToString();
            Info.Content += "\n" + cliente.Email.ToString();
            imgPerfil.Source = new BitmapImage(new Uri(cliente.Foto));

        }

        
        private void Historico_Click(object sender, RoutedEventArgs e)
        {
            HistoricoMensagem hm = new HistoricoMensagem(cliente);
            hm.ShowDialog();
        }

        private void Buscar(object sender, RoutedEventArgs e)
        {
            frmPrincipal p = new frmPrincipal(cliente);
            p.ShowDialog();
        }
    }

}