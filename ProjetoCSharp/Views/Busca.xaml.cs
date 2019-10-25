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

    /// Interaction logic for Busca.xaml

    /// </summary>

    public partial class Busca : Window

    {

        private string pesquisa;

        private Servico autonomo1, autonomo2, autonomo3;

        private Cliente cliente;



        public Busca(string p, Cliente cliente)

        {

            InitializeComponent();

            this.cliente = cliente;

            this.pesquisa = p;

        }



        public Busca(string p)

        {

            InitializeComponent();

            this.pesquisa = p;

        }



        private void Window_Loaded(object sender, RoutedEventArgs e)

        {

            List<Servico> ResultadoBuscar = new List<Servico>();

            ResultadoBuscar = UsuarioDAO.buscarAutonomos(pesquisa);

            MessageBox.Show(ResultadoBuscar[0].Autonomo.Agenda.CargaHoraria);





            int i = 0;

            foreach (Servico a in ResultadoBuscar)

            {

                i = i + 1;

                if (i == 1)

                {

                    MessageBox.Show(a.Autonomo.Agenda.CargaHoraria);

                    img1.Source = new BitmapImage(new Uri(a.Autonomo.Foto));

                    lblAutonomo1.Content = a.Categoria;

                    autonomo1 = a;

                    //Acho que vai precisar inserir todos os dados um por um do serviço nos autonomos, tipo colocar

                    //autonomo1.Servico.Descricao = a.Descricao

                }
                else if (i == 2)

                {

                    img2.Source = new BitmapImage(new Uri(a.Autonomo.Foto));

                    lblAutonomo2.Content = a.Categoria;

                    autonomo2 = a;

                }

                else if (i == 3)

                {

                    img2.Source = new BitmapImage(new Uri(a.Autonomo.Foto));

                    lblAutonomo3.Content = a.Categoria;

                    autonomo3 = a;

                }

            }

        }



        private void BtnAgendar1_Click(object sender, RoutedEventArgs e)

        {



            autonomo1.Autonomo = UsuarioDAO.autenticarAutonomo(autonomo1.Autonomo.Email, autonomo1.Autonomo.Senha);



            Agendamento ag = new Agendamento(autonomo1, cliente);



            ag.ShowDialog();



        }



        private void BtnAgendar2_Click(object sender, RoutedEventArgs e)

        {



            Agendamento ag = new Agendamento(autonomo2, cliente);



            ag.ShowDialog();



        }



        private void BtnAgendar3_Click(object sender, RoutedEventArgs e)

        {



            Agendamento ag = new Agendamento(autonomo3, cliente);



            ag.ShowDialog();



        }

    }

}