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
    /// Interaction logic for frmPrincipal.xaml
    /// </summary>
    public partial class frmPrincipal : Window
    {

        Cliente cliente;

        public frmPrincipal()
        {
            InitializeComponent();
        }

       public frmPrincipal(Cliente cli)
        {
            InitializeComponent();
            cliente = cli;
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {

            PreCadastro c = new PreCadastro();
            c.ShowDialog();

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login l = new Login();
            l.ShowDialog();
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {

            if (cliente == null)
            {
                string pesquisa = txtBuscar.Text;
                Busca b = new Busca(pesquisa);
                b.ShowDialog();
                string data = Cad.SelectedDate.ToString();
            }
            else
            {

                string pesquisa = txtBuscar.Text;
                Busca b = new Busca(pesquisa, cliente);
                b.ShowDialog();

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //apagar isso depois
            Chat c = new Chat();
            c.ShowDialog();
            
        }
    }

}
