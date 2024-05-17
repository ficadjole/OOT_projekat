using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace OOT_Kursevi
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {   
        private ObservableCollection<Kurs> kursevi;
        private ObservableCollection<Kurs> kursevi_nedosupni;

        public AddWindow(ObservableCollection<Kurs> Kursevi,ObservableCollection<Kurs> Kursevi_nedostupni)
        {
            InitializeComponent();
            kursevi = Kursevi;
            kursevi_nedosupni = Kursevi_nedostupni;
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;
            dlg.Multiselect = false;

            if(dlg.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(dlg.FileName);
                bitmap.EndInit();
                imgIkonica.Source = bitmap;

            }

        }

        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDodajKurs_Click(object sender, RoutedEventArgs e)
        {
            Kurs kurs = new Kurs();
            int id,cena;

            if(rdBtnDostupan.IsChecked == true && txtBoxID.Text != null && txtBoxNaziv.Text != null && txtBoxCena.Text != null && txtBoxVrsta != null && txtBoxOpis != null && imgIkonica.Source != null)
            {
                if (Int32.TryParse(txtBoxID.Text, out id) && Int32.TryParse(txtBoxCena.Text,out cena))
                {
                    foreach (Kurs k in kursevi)
                    {
    
                        if(k.ID == id)
                        {
                            MessageBox.Show("ID: " + txtBoxID.Text + " je trenutno zauzet");
                            return;
                        }
                    

                        if (k.Naziv.Equals(txtBoxNaziv.Text))
                        {
                            MessageBox.Show("Kurs sa imenom: " + txtBoxNaziv.Text + " vec postoji");
                            return;
                        
                        }
                    }

                    TextRange textRange = new TextRange(txtBoxOpis.Document.ContentStart, txtBoxOpis.Document.ContentEnd);

                    kurs.ID = id;
                    kurs.Cena = cena;
                    kurs.Naziv = txtBoxNaziv.Text;
                    kurs.Vrsta = txtBoxVrsta.Text;
                    kurs.Dostupnost = (bool)rdBtnDostupan.IsChecked;
                    kurs.Opis = textRange.Text;
                    kurs.Slika = imgIkonica;

                    kursevi.Add(kurs);

                }
                else
                {
                    MessageBox.Show("Niste uneli ID ili cenu u dobrom formatu");
                    return;
                }

            }else if(rdBtnNedostupan.IsChecked == true && txtBoxID.Text != null && txtBoxNaziv.Text != null && txtBoxCena.Text != null && txtBoxVrsta != null && txtBoxOpis != null && imgIkonica.Source != null)
            {
                if (Int32.TryParse(txtBoxID.Text, out id) && Int32.TryParse(txtBoxCena.Text, out cena))
                {
                    foreach (Kurs k in kursevi_nedosupni)
                    {

                        if (k.ID == id)
                        {
                            MessageBox.Show("ID: " + txtBoxID.Text + " je trenutno zauzet");
                            return;
                        }


                        if (k.Naziv.Equals(txtBoxNaziv.Text))
                        {
                            MessageBox.Show("Kurs sa imenom: " + txtBoxNaziv.Text + " vec postoji");
                            return;

                        }
                    }

                    TextRange textRange = new TextRange(txtBoxOpis.Document.ContentStart, txtBoxOpis.Document.ContentEnd);

                    kurs.ID = id;
                    kurs.Cena = cena;
                    kurs.Naziv = txtBoxNaziv.Text;
                    kurs.Vrsta = txtBoxVrsta.Text;
                    kurs.Dostupnost = (bool)rdBtnDostupan.IsChecked;
                    kurs.Opis = textRange.Text;
                    kurs.Slika = imgIkonica;

                    kursevi_nedosupni.Add(kurs);

                }
                else
                {
                    MessageBox.Show("Niste uneli ID ili cenu u dobrom formatu");
                    return;
                }


            }
            else
            {
                MessageBox.Show("Morate da popunite sva polja pre dodavanja");
                return;
            }
        }
    }
}
