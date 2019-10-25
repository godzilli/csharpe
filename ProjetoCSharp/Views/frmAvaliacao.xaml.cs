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
    /// Interaction logic for frmAvaliacao.xaml
    /// </summary>
    public partial class frmAvaliacao : Window
    {
        public frmAvaliacao()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;

            double value = slider.Value;

            lblValorDoSld.Content = value.ToString("0.0") + "/" + "10,0";
        }
    }
}

