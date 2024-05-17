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

namespace OOT_Kursevi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ObservableCollection<Kurs> kursevi = new ObservableCollection<Kurs>();
        private ObservableCollection<Kurs> kursevi2 = new ObservableCollection<Kurs>();

        public MainWindow()
        {
            InitializeComponent();
            kursevi.Add(new Kurs(123,"Ronjenje",3000,"Sport","Ronjenje na dah",true,"C:\\Users\\win 10\\Desktop\\SnapShot1.jpg"));
            kursevi2.Add(new Kurs(123, "Ronjenje", 3000, "Sport", "Ronjenje na dah", false, "C:\\Users\\win 10\\Desktop\\SnapShot1.jpg"));
            dtGrid_dostupni.ItemsSource = kursevi;
            dtGrid_nedostupni.ItemsSource = kursevi2;
        }

        private void BTN_DodajClick(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_PotvrdiClick(object sender, RoutedEventArgs e)
        {

        }
    }
}