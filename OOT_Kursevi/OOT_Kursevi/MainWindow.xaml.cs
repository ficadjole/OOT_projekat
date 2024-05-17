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
        Point startPoint = new Point();

        private ObservableCollection<Kategorija> sport = new ObservableCollection<Kategorija>();
        
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            List<Kurs> l = new List<Kurs>();
            List<Kurs> l2 = new List<Kurs>();
            l.Add(new Kurs(1,"Ronjenje",3000,"Sport","Ronjenje na dah",true, ".\\OOT_Kursevi\\slike\\C.webp"));
            l.Add(new Kurs(2,"Teretana",5200,"Sport","Personalni trening",true,".\\OOT_Kursevi\\slike\\gym.jpg"));
            
            l2.Add(new Kurs(2, "Pravljenje paste", 2500, "Hrana", "Italijanska receptura", false, ".\\OOT_Kursevi\\slike\\C.webp"));
            
            Kursevi = new ObservableCollection<Kurs>(l);
            Kursevi_nedostupno = new ObservableCollection<Kurs>(l2);
            dtGrid_dostupni.ItemsSource = Kursevi;
            dtGrid_nedostupni.ItemsSource = Kursevi_nedostupno;
        }

        public ObservableCollection<Kurs> Kursevi
        {
            get;
            set;
        }

        public ObservableCollection <Kurs> Kursevi_nedostupno
        {
            get;
            set;
        }

        private void BTN_DodajClick(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_PotvrdiClick(object sender, RoutedEventArgs e)
        {

        }

        private void dtGrid_dostupni_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void dtGrid_dostupni_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);   
            Vector diff = startPoint - mousePos;
            var dg = sender as DataGrid;

            if(e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance)) 
            {

                var DataGridRow = FindAnchestor<DataGridRow>((DependencyObject)e.OriginalSource);

                if(DataGridRow == null) { return; }

                var dataTodrop = (Kurs)dg.ItemContainerGenerator.ItemFromContainer(DataGridRow);

                if(dataTodrop == null) { return; }

                var dataObj = new DataObject("myFormat",dataTodrop);

                DragDrop.DoDragDrop(dg, dataObj, DragDropEffects.Move);

            }



        }

        private void dtGrid_nedostupni_DragEnter(object sender, DragEventArgs e)
        {
            if(!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void dtGrid_nedostupni_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Kurs kurs = e.Data.GetData("myFormat") as Kurs;
                kurs.Dostupnost = false;
                Kursevi.Remove(kurs);
                Kursevi_nedostupno.Add(kurs);

            }

        }

        private void dtGrid_nedostupni_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void dtGrid_nedostupni_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;
            var dg = sender as DataGrid;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {

                var DataGridRow = FindAnchestor<DataGridRow>((DependencyObject)e.OriginalSource);

                if (DataGridRow == null) { return; }

                var dataTodrop = (Kurs)dg.ItemContainerGenerator.ItemFromContainer(DataGridRow);

                if (dataTodrop == null) { return; }

                var dataObj = new DataObject("myFormat", dataTodrop);

                DragDrop.DoDragDrop(dg, dataObj, DragDropEffects.Move);

            }
        }

        private void dtGrid_dostupni_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void dtGrid_dostupni_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Kurs kurs = e.Data.GetData("myFormat") as Kurs;
                kurs.Dostupnost = true;

                Kursevi_nedostupno.Remove(kurs);
                Kursevi.Add(kurs);

            }
        }

        private static T FindAnchestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }

                current = VisualTreeHelper.GetParent(current);

            } while (current != null);
            return null;
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if(dtGrid_dostupni.SelectedItem != null)
            {
                Kurs selektovanKurs = (Kurs)dtGrid_dostupni.SelectedItem;
                Kursevi.Remove(selektovanKurs);
            }else if(dtGrid_nedostupni.SelectedItem != null)
            {
                Kurs selektovanKurs = (Kurs)dtGrid_nedostupni.SelectedItem;
                Kursevi_nedostupno.Remove(selektovanKurs);
            }
            else
            {
                MessageBox.Show("Niste nista selektovali");
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow(Kursevi,Kursevi_nedostupno);
            addWindow.Show();
        }
    }
}