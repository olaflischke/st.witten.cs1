using EierfarmBl;
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

namespace EierfarmUi
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

        private void btnNeueGans_Click(object sender, RoutedEventArgs e)
        {
            Gans gans = new Gans("Neue Gans");
            cbxTiere.Items.Add(gans);
            cbxTiere.SelectedItem = gans;
        }

        private void btnNeuesHuhn_Click(object sender, RoutedEventArgs e)
        {
            Huhn huhn = new Huhn("Neues Huhn");
            cbxTiere.Items.Add(huhn);
            cbxTiere.SelectedItem = huhn;
        }

        private void btnFuettern_Click(object sender, RoutedEventArgs e)
        {
            IEileger? tier = cbxTiere.SelectedItem as IEileger; // Safe-Cast liefert null, wenn Cast fehlschlägt
            if (tier != null)
            {
                tier.Fressen();

                cbxTiere.SelectedItem = null;
                cbxTiere.SelectedItem = tier;
            }
        }

        private void btnEiLegen_Click(object sender, RoutedEventArgs e)
        {
            if (cbxTiere.SelectedItem is IEileger tier)
            {
                tier.EiLegen();

                cbxTiere.SelectedItem = null;
                cbxTiere.SelectedItem = tier;

            }
        }
    }
}