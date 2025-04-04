using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using static Autoform.Auto;

namespace Autoform
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Betolt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new();

            if(ofd.ShowDialog() is true)
            {
                Autok.Clear();
                LoadCsv(ofd.FileName);
                dgDagiDaganat.ItemsSource = ofd.FileNames;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtGyartasiEv.Text, out int ev))
                return;

            lbIdk.ItemsSource = Autok
                .Where(G => G.GyartasiEv == ev)
                .Select(G => $"{G.Marka} {G.Modell}");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Biztos ki akar lépni?", "Kilépés", MessageBoxButton.OKCancel);

            switch (res)
            {
                case MessageBoxResult.OK:
                    Close();
                    break;
                default:
                    break;
            }
        }
    }
}