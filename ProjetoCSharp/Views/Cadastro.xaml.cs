using ProjetoCSharp.Models;
using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using ProjetoCSharp.DAL;

namespace ProjetoCSharp.Views
{
    /// <summary>
    /// Interaction logic for Cadastro.xaml
    /// </summary>
    public partial class Cadastro : Window
    {

        //Cliente clienteA;

        public Cadastro()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            frmPrincipal p = new frmPrincipal();
            p.ShowDialog();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            
            Cliente cliente = new Cliente()
            {

                Nome = txtNome.Text,
                Cpf = txtCPF.Text,
                Cep = txtCEP.Text,
                Rua = txtEndereco.Text, 
                NumCasa = txtNum.Text,
                Bairro = txtBairro.Text, 
                Cidade = txtCidade.Text,
                Estado = txtUF.Text,
                Email = txtEmail.Text,
                Senha = txtSenha.Text,
                Foto = Convert.ToString(imgPerfil.Source),
                Telefone = txtTelefone.Text

            };
            System.Windows.MessageBox.Show(cliente.Foto);
            if (txtNome == null  || txtCPF == null || txtCEP == null || txtEndereco == null || 
                txtNum == null || txtBairro == null || txtCidade == null || txtUF == null || 
                txtEmail == null || txtSenha == null || txtTelefone == null || imgPerfil == null)
            {
                System.Windows.MessageBox.Show("Lembre-se de preencher todos os campos!", "Dijj Variedade - Atenção!", MessageBoxButton.OK);
                
            }
            UsuarioDAO.CadastrarUsuario(cliente);
            
            
            Login l = new Login();
            l.ShowDialog();

        }

        private void BtnFoto_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog op = new Microsoft.Win32.OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPerfil.Source = new BitmapImage(new Uri(op.FileName));
            }

        }

        private void TxtTelefone_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            System.Windows.MessageBox.Show("Não nos responsabilizamos pelo conteúdo das trocas de mensagens futuras!",
                    "DIJJ Variedades - ATENÇÃO!", MessageBoxButton.OK,
                    MessageBoxImage.Information);
        }
    }
}
