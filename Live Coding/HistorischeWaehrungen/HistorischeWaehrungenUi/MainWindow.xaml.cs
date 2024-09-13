using HistorischeWaehrungenDal;
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

namespace HistorischeWaehrungenUi
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

                string url = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90.xml";
                Archiv archiv = new Archiv(url);

                this.DataContext = archiv;

            }
            catch (HistorischeWaehrungenDalException ex)
            {

                MessageBox.Show($"Fehler beim Laden der Daten: {ex.Message}\n\r{ex.InnerException?.Message}\n\r{ex.InnerException?.InnerException?.Message}");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}