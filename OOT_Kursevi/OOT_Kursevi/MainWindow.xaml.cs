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

        public ObservableCollection<Kurs> Korpa { get; set; } = new ObservableCollection<Kurs>();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            List<Kurs> l = new List<Kurs>();
            List<Kurs> l2 = new List<Kurs>();

            l.Add(new Kurs(1,"Ronjenje",3000,"Sport","Ronjenje na dah",true, ".\\OOT_Kursevi\\slike\\C.webp"));
            l.Add(new Kurs(2,"Teretana",5200,"Sport","Personalni trening",true,".\\OOT_Kursevi\\slike\\gym.jpg"));
            l.Add(new Kurs(3, "Skijanje", 6000, "Sport", "Simulacija skijanja", true, ".\\OOT_Kursevi\\slike\\skijanje.jpg"));
            
            
            l2.Add(new Kurs(5, "Pravljenje paste", 2500, "Hrana", "Italijanska receptura", false, ".\\OOT_Kursevi\\slike\\pasta.jpg"));
            l.Add(new Kurs(4, "Pravljenje pice", 2000, "Hrana", "Pizza Italiana", true, ".\\OOT_Kursevi\\slike\\pizza.jpg"));

            l.Add(new Kurs(6, "Programski jezik C", 4000, "Programiranje", "Programiranje za pocetnike", true, ".\\OOT_Kursevi\\slike\\C.webp"));
            l.Add(new Kurs(7, "Python", 5500, "Programiranje" , "Python kurs za sve", true, ".\\OOT_Kursevi\\slike\\python.png"));
            l2.Add(new Kurs(8, "C#", 3500, "Programiranje", "Objektno Orijentisano Programiranje", false, ".\\OOT_Kursevi\\slike\\c_sharp.jpg"));


            List<Kurs> l1Sport = new List<Kurs>();
            l1Sport.Add(new Kurs(1, "Ronjenje", 3000, "Sport", "Ronjenje na dah", true, ".\\OOT_Kursevi\\slike\\C.webp"));
            l1Sport.Add(new Kurs(2, "Teretana", 5200, "Sport", "Personalni trening", true, ".\\OOT_Kursevi\\slike\\gym.jpg"));
            l1Sport.Add(new Kurs(3, "Skijanje", 6000, "Sport", "Simulacija skijanja", true, ".\\OOT_Kursevi\\slike\\skijanje.jpg"));
            Kategorija sport = new Kategorija(1, "Sport", "Kursevi za sport", l1Sport);

            List<Kurs> l1Programiranje = new List<Kurs>();
            l1Programiranje.Add(new Kurs(6, "Programski jezik C", 4000, "Programiranje", "Programiranje za pocetnike", true, ".\\OOT_Kursevi\\slike\\C.webp"));
            l1Programiranje.Add(new Kurs(7, "Python", 5500, "Programiranje", "Python kurs za sve", true, ".\\OOT_Kursevi\\slike\\python.png"));
            l1Programiranje.Add(new Kurs(8, "C#", 3500, "Programiranje", "Objektno Orijentisano Programiranje", false, ".\\OOT_Kursevi\\slike\\c_sharp.jpg"));
            Kategorija programiranje = new Kategorija(1, "Programiranje", "Kursevi za sport", l1Programiranje);

            List<Kurs> l1Kuvanje = new List<Kurs>();
            l1Kuvanje.Add(new Kurs(5, "Pravljenje paste", 2500, "Hrana", "Italijanska receptura", false, ".\\OOT_Kursevi\\slike\\pasta.jpg"));
            l1Kuvanje.Add(new Kurs(4, "Pravljenje pice", 2000, "Hrana", "Pizza Italiana", true, ".\\OOT_Kursevi\\slike\\pizza.jpg"));
            Kategorija hrana = new Kategorija(2, "Hrana", "Kursevi za pravljenje hrane", l1Kuvanje);

            Kategorije = new ObservableCollection<Kategorija> { sport, hrana, programiranje };
            Kursevi = new ObservableCollection<Kurs>(l);
            Kursevi_nedostupno = new ObservableCollection<Kurs>(l2);
            dtGrid_dostupni.ItemsSource = Kursevi;
            dtGrid_nedostupni.ItemsSource = Kursevi_nedostupno;
        }

        public ObservableCollection<Kategorija> Kategorije 
        { 
            get; 
            set; 
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
            var izabraniKursevi = GetSelectedCoursesFromTreeView(TreeViewKursevi);
            foreach (var kurs in izabraniKursevi)
            {
                if (!Korpa.Contains(kurs))
                {
                    Korpa.Add(kurs);
                    MessageBox.Show($"Kurs '{kurs.Naziv}' je uspešno dodat u korpu.", "Kurs dodat", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show($"Kurs '{kurs.Naziv}' je već u korpi.", "Kurs već dodat", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private List<Kurs> GetSelectedCoursesFromTreeView(TreeView treeView)
        {
            var izabraniKursevi = new List<Kurs>();
            foreach (var item in treeView.Items)
            {
                var treeViewItem = treeView.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
                if (treeViewItem != null && treeViewItem.IsSelected)
                {
                    izabraniKursevi.Add(treeViewItem.DataContext as Kurs);
                }
                GetSelectedCoursesFromTreeViewItem(treeViewItem, izabraniKursevi);
            }
            return izabraniKursevi;
        }

        private void GetSelectedCoursesFromTreeViewItem(TreeViewItem item, List<Kurs> izabraniKursevi)
        {
            if (item == null) return;
            foreach (var subItem in item.Items)
            {
                var subTreeViewItem = item.ItemContainerGenerator.ContainerFromItem(subItem) as TreeViewItem;
                if (subTreeViewItem != null && subTreeViewItem.IsSelected)
                {
                    izabraniKursevi.Add(subTreeViewItem.DataContext as Kurs);
                }
                GetSelectedCoursesFromTreeViewItem(subTreeViewItem, izabraniKursevi);
            }
        }

        private void BTN_PotvrdiClick(object sender, RoutedEventArgs e)
        {
            var courseDetailsWindow = new PotvrdiWindow(Korpa);
            courseDetailsWindow.Show();
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

        private void btnIzmeniti_Click(object sender, RoutedEventArgs e)
        {
            if (dtGrid_dostupni.SelectedIndex != -1)
            {
                Kurs k = (Kurs)dtGrid_dostupni.SelectedItem;

                EditWindow editWindow = new EditWindow(k,Kursevi,Kursevi_nedostupno);
                editWindow.Show();

            } else if (dtGrid_nedostupni.SelectedIndex != -1)
            {
                Kurs k = (Kurs)dtGrid_nedostupni.SelectedItem;

                EditWindow ed = new EditWindow(k, Kursevi, Kursevi_nedostupno);
                ed.Show();
            }
            else
            {
                MessageBox.Show("Niste selektovali niti jedan kurs");
            }
        }

        private void btnPretraga_Click(object sender, RoutedEventArgs e)
        {

            var pretraga1 = Kursevi.Where(Kurs => Kurs.Vrsta.StartsWith(txtBoxPretraga.Text));
            var pretraga2 = Kursevi_nedostupno.Where(Kurs => Kurs.Vrsta.StartsWith(txtBoxPretraga.Text));

            if (pretraga1.Any())
            {
            dtGrid_dostupni.ItemsSource = pretraga1;

            }
            else if (pretraga2.Any())
            {
               dtGrid_nedostupni.ItemsSource = pretraga2;
            }
            else
            {
               txtBoxPretraga.Clear();
                MessageBox.Show("Vrsta: " + txtBoxPretraga.Text + " nije dostupna");
            }

        }

        private void txtBoxPretraga_KeyUp(object sender, KeyEventArgs e)
        {
            //var pretraga1 = Kursevi.Where(Kurs => Kurs.Vrsta.StartsWith(txtBoxPretraga.Text));
            //var pretraga2 = Kursevi_nedostupno.Where(Kurs => Kurs.Vrsta.StartsWith(txtBoxPretraga.Text));

            //if (pretraga1.Any())
            //{
            //    dtGrid_dostupni.ItemsSource = pretraga1;

            //}
            //else if (pretraga2.Any())
            //{
            //    dtGrid_nedostupni.ItemsSource = pretraga2;
            //}
            //else
            //{
            //    txtBoxPretraga.Clear();
            //    MessageBox.Show("Vrsta: " + txtBoxPretraga.Text + " nije dostupna");
            //}
        }
    }
}