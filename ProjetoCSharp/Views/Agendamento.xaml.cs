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

    /// Interaction logic for Agendamento.xaml

    /// </summary>

    public partial class Agendamento : Window

    {



        private Servico a = new Servico();

        private Cliente c = new Cliente();

        private List<double> horario = new List<double>();

        private StringBuilder inf = new StringBuilder();

        private StringBuilder marcar = new StringBuilder();

        string agendamento;

        DateTime agenda = new DateTime();

        double ie = 0;

        int ch = 0;



        public Agendamento(Servico autonomo, Cliente cliente)

        {

            InitializeComponent();



            a = autonomo;

            c = cliente;



        }



        private void Agenda_Loaded(object sender, RoutedEventArgs e)

        {

            MessageBox.Show(a.Autonomo.Agenda.CargaHoraria);

            MessageBox.Show(a.Autonomo.Agenda.InicioExpediente);

            cadData.DisplayDateStart = DateTime.Today;



            ie = Convert.ToDouble(a.Autonomo.Agenda.InicioExpediente);

            ch = Convert.ToInt32(a.Autonomo.Agenda.CargaHoraria);



            inf.Append("\t" + a.Autonomo.Nome);

            inf.Append("\n\tServiço Oferecido: " + a.Descricao);

            inf.Append("\n\tHorário de Atendimento: " + ie + " às" + (ie + ch));

            info.Content = inf.ToString();



            valorbase.Content = Convert.ToString(a.Valor.ToString());



            if (a.Autonomo.Foto != null)

            {

                imgPerfil.Source = new BitmapImage(new Uri(a.Autonomo.Foto));

            }

            else

            {

                imgPerfil.Source = new BitmapImage(new Uri("Imagens/autonomo.png"));

            }



            for (int i = 0; i <= ch; i++)

            {

                horario.Add(Convert.ToDouble(ie + (ch - i)));

            }



            for (int i = 0; i <= ch; i++)

            {



                cboHorario.Items.Add(horario[i] + ":00");



            }







        }



        private void Mensagem_Click(object sender, RoutedEventArgs e)

        {

            //Chat chat = new Chat(a, c);

            //chat.ShowDialog();

        }



        private void Agendar_Click(object sender, RoutedEventArgs e)

        {

            marcar = new StringBuilder();

            if (cadData.SelectedDate.HasValue)

            {



                //Data e hor



                //nascimento = nascimento.Value.AddHours(hora);

                //sb.Append("\nData e hora: " + nascimento);





                agenda = cadData.SelectedDate.Value;

                marcar.Append(agenda.ToLongDateString());

                marcar.Append(" " + cboHorario.SelectedItem.ToString());

                string semana = Convert.ToString(cadData.SelectedDate.Value.DayOfWeek);

                MessageBox.Show(marcar.ToString());

                MessageBox.Show(semana);



                if (a.Autonomo.Agenda.Semana.Contains(semana))

                {

                    MessageBox.Show("toctoc");

                    Solicitacao consulta = SolicitacaoDAO.ConsultarAgenda(marcar, semana, a.Autonomo);

                    if (consulta != null)

                    {

                        MessageBox.Show("Este horário não está disponível");

                    }

                    else

                    {

                        Solicitacao s = new Solicitacao();

                        s.Agendamento = Convert.ToString(marcar);

                        s.Autonomo = a.Autonomo;

                        s.Cliente = c;

                        s.Formulario = a;

                        SolicitacaoDAO.SalvarAgendamento(s);

                    }

                }

                else

                {

                    MessageBox.Show("UHASUHUDAHU");

                }





                //agendamento.AddHours(Convert.ToDateTime(horario[i]);

                //essageBox.Show(agendamento.ToLongDateString());



            }

            else

            {

                MessageBox.Show("Informe uma data para prosseguir");

            }





        }



    }

}