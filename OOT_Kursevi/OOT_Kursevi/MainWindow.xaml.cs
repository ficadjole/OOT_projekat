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
        private ObservableCollection<Kategorija> sport = new ObservableCollection<Kategorija>();

        public MainWindow()
        {
            InitializeComponent();
            kursevi.Add(new Kurs(1,"Ronjenje",3000,"Sport","Ronjenje na dah",true, ".\\OOT_Kursevi\\slike\\C.webp"));
            kursevi.Add(new Kurs(2,"Teretana",5200,"Sport","Personalni trening",true,".\\OOT_Kursevi\\slike\\gym.jpg"));
            
            kursevi_nedostupni.Add(new Kurs(2, "Pravljenje paste", 2500, "Hrana", "Italijanska receptura", false, ".\\OOT_Kursevi\\slike\\C.webp"));
            
            dtGrid_dostupni.ItemsSource = kursevi;
            dtGrid_nedostupni.ItemsSource = kursevi_nedostupni;
        }

        private void BTN_DodajClick(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_PotvrdiClick(object sender, RoutedEventArgs e)
        {

        }

        private void dtGrid_dostupni_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void dtGrid_dostupni_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void dtGrid_nedostupni_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void dtGrid_nedostupni_Drop(object sender, DragEventArgs e)
        {

        }
    }
}