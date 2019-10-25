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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetoCSharp.Views
{
    /// <summary>
    /// Interaction logic for PerfilAuto.xaml
    /// </summary>
    public partial class PerfilAuto : Window
    {

        Autonomo a = new Autonomo();

        public PerfilAuto(Autonomo autonomo)
        {
            InitializeComponent();
            a = autonomo;

            if (a.Foto != null)
            {
                //imgPerfil.Source = new BitmapImage(new Uri(a.Foto));
            }
            else
            {
                imgPerfil.Source = new BitmapImage(new Uri("Imagens/cliente.png"));
            }
        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            frmPrincipal p = new frmPrincipal();
            p.ShowDialog();
        }

        private void PerfilA_Loaded(object sender, RoutedEventArgs e)
        {

            //Servico s = new Servico();

            Servico s = UsuarioDAO.buscarAutonomos(a);

            NomeA.Content = s.Autonomo.Nome.ToString();
            InfoA.Content += a.Telefone.ToString();
            InfoA.Content += "\n"+a.Cidade.ToString();
            InfoA.Content += "\n"+a.Email.ToString();
            InfoA.Content += "\n" + s.Autonomo.Agenda.CargaHoraria.ToString();
            InfoA.Content += "\n" + s.Categoria.ToString();
            imgPerfil.Source = new BitmapImage(new Uri(a.Foto));

        }

        private void Sair_Click(object sender, RoutedEventArgs e)
        {
            Autonomo autonomo = new Autonomo();
            frmPrincipal f = new frmPrincipal();
            this.Close();
        }

        private void Historico_Click(object sender, RoutedEventArgs e)
        {
            HistoricoMensagem hm = new HistoricoMensagem();
            hm.ShowDialog();
        }
        private void btnAlterarDados_Click(object sender, RoutedEventArgs e)

        {
            CadastroA ca = new CadastroA(a);

            ca.ShowDialog();
        }
    }
}