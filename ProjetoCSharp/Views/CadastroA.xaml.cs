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
    /// Interaction logic for CadastroA.xaml
    /// </summary>
    public partial class CadastroA : Window
    {
        Autonomo autonomo = new Autonomo();
        string cargahoraria = "";
        public CadastroA()
        {
            InitializeComponent();
        }

        public CadastroA(Autonomo a)
        {
            InitializeComponent();
            autonomo = a;
            imgPerfil.Source = new BitmapImage(new Uri(a.Foto));

            txtNome.Text = a.Nome;
            txtCPF.Text = a.Cpf;
            txtCEP.Text = a.Cep;
            txtEndereco.Text = a.Rua;

            txtNum.Text = a.NumCasa;

            txtBairro.Text = a.Bairro;
            txtCidade.Text = a.Cidade;
            txtUF.Text = a.Estado;
            txtEmail.Text = a.Email;
            txtSenha.Text = a.Senha;

            txtTelefone.Text = a.Telefone;

            txtDescricao.Text = a.Servico[0].Descricao;
            cboCategoria.SelectedValue = a.Servico[0].Categoria;
            txtValor.Text = a.Servico[0].Valor.ToString();

            txtHora.Text = a.Agenda.InicioExpediente;

            if (a.Agenda.CargaHoraria.Equals("4"))
            {
                rdbQuatro.IsChecked = true;
            }

            else if (a.Agenda.CargaHoraria.Equals("6"))
            {
                rdbSeis.IsChecked = true;
            }
            else if (a.Agenda.CargaHoraria.Equals("8"))
            {
                rdbOito.IsChecked = true;
            }

            else if (a.Agenda.CargaHoraria.Equals("10"))
            {
                rdbDez.IsChecked = true;
            }
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

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            string semana = (bool)chkSegunda.IsChecked ? "S, " : "";
            semana += (bool)chkTerça.IsChecked ? "T, " : "";
            semana += (bool)chkQuarta.IsChecked ? "Q1, " : "";
            semana += (bool)chkQuinta.IsChecked ? "Q2, " : "";
            semana += (bool)chkSexta.IsChecked ? "S1, " : "";
            semana += (bool)chkSabado.IsChecked ? "S2, " : "";
            semana += (bool)chkDomingo.IsChecked ? "D " : "";

            ComboBoxItem categoria = (ComboBoxItem)cboCategoria.SelectedItem;

            autonomo.Nome = txtNome.Text;
            autonomo.Cpf = txtCPF.Text;
            autonomo.Cep = txtCEP.Text;
            autonomo.Rua = txtEndereco.Text;
            autonomo.NumCasa = txtNum.Text;
            autonomo.Bairro = txtBairro.Text;
            autonomo.Cidade = txtCidade.Text;
            autonomo.Estado = txtUF.Text;
            autonomo.Email = txtEmail.Text;
            autonomo.Senha = txtSenha.Text;
            autonomo.Foto = Convert.ToString(imgPerfil.Source);
            autonomo.Telefone = txtTelefone.Text;

            Servico servico = new Servico()
            {
                Descricao = txtDescricao.Text,
                Categoria = categoria.Content.ToString(),
                Valor = Convert.ToDouble(txtValor.Text)
            };

            Agenda agenda = new Agenda()
            {
                Semana = semana,
                InicioExpediente = txtHora.Text,
                CargaHoraria = cargahoraria
            };

            autonomo.Servico.Add(servico);
            autonomo.Agenda = agenda;

            UsuarioDAO.CadastrarUsuario(autonomo);
            autonomo = new Autonomo();

            Login l = new Login();
            l.ShowDialog();

            // System.Windows.MessageBox.Show(autonomo.Foto);
        }

        private void RdbQuatro_Checked(object sender, RoutedEventArgs e)
        {
            cargahoraria = "4";
        }

        private void RdbOito_Checked(object sender, RoutedEventArgs e)
        {
            cargahoraria = "8";
        }

        private void RdbSeis_Checked(object sender, RoutedEventArgs e)
        {
            cargahoraria = "6";
        }

        private void RdbDez_Checked(object sender, RoutedEventArgs e)
        {
            cargahoraria = "10";
        }

        private void BtnAdicionarServico_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem categoria = (ComboBoxItem)cboCategoria.SelectedItem;

            Servico sb = new Servico()
            {
                Descricao = txtDescricao.Text,
                Categoria = categoria.Content.ToString(),
                Valor = Convert.ToDouble(txtValor.Text)
            };
            autonomo.Servico.Add(sb);
        }
        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            frmPrincipal p = new frmPrincipal();
            p.ShowDialog();
        }
        private void TxtTelefone_TextChanged(object sender, TextChangedEventArgs e)
        {
            System.Windows.MessageBox.Show("Não nos responsabilizamos pelo conteúdo das trocas de mensagens futuras!",
                   "DIJJ Variedades - ATENÇÃO!", MessageBoxButton.OK,
                   MessageBoxImage.Information);
        }
    }
}