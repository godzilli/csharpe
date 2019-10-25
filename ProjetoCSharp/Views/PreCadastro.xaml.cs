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
    /// Interaction logic for PreCadastro.xaml
    /// </summary>
    public partial class PreCadastro : Window
    {
        public PreCadastro()
        {
            InitializeComponent();
        }

        private void BtnCliente_Click(object sender, RoutedEventArgs e)
        {

            Cadastro c = new Cadastro();

            c.ShowDialog();

        }

        private void BtnAutonomo_Click(object sender, RoutedEventArgs e)
        {

            CadastroA c = new CadastroA();

            c.ShowDialog();

        }
    }
}
