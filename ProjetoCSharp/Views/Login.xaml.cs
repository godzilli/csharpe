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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        Cliente cliente = new Cliente();
        Autonomo autonomo = new Autonomo();

        public Login()
        {

            InitializeComponent();

        }

        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string senha = txtSenha.Text;

            cliente = UsuarioDAO.autenticarCliente(email, senha);
            autonomo = UsuarioDAO.autenticarAutonomo(email, senha);
            
            if (cliente!=null)
            {
                MessageBox.Show("foi");
                
                PerfilC pc = new PerfilC(cliente);
                pc.ShowDialog();
            }
            else if (autonomo!=null)
            {
                MessageBox.Show("foi");
                PerfilAuto pa = new PerfilAuto(autonomo);
                pa.ShowDialog();
            }
            else
            {
                MessageBox.Show("Não há cadastro de usuário com estes dados!", "Login", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

    }

}
