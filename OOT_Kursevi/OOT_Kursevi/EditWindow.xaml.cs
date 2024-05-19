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
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {

        private ObservableCollection<Kurs> kursevi;
        private ObservableCollection<Kurs> kursevi_nedosupni;
        Kurs stari_kurs;

        public EditWindow(Kurs k,ObservableCollection<Kurs>Kursevi,ObservableCollection<Kurs>Kursevi_nedostupni)
        {
            InitializeComponent();

            stari_kurs = k;
            kursevi = Kursevi;
            kursevi_nedosupni = Kursevi_nedostupni;

            txtBoxID.Text = k.ID.ToString();
            txtBoxCena.Text = k.Cena.ToString();
            txtBoxNaziv.Text = k.Naziv.ToString();
            txtBoxVrsta.Text = k.Vrsta.ToString();
            rdBtnDostupan.IsChecked = (k.Dostupnost) ? true : false;
            rdBtnNedostupan.IsChecked = (k.Dostupnost) ? false : true;

            txtBoxOpis.Text = k.Opis.ToString();

            imgIkonica.Source = k.Putanja;
            kursevi.Remove(stari_kurs);
            kursevi_nedosupni.Remove(stari_kurs);

        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {

            Kurs kurs = new Kurs();
            int id, cena;

            if (rdBtnDostupan.IsChecked == true && txtBoxID.Text != null && txtBoxNaziv.Text != null && txtBoxCena.Text != null && txtBoxVrsta != null && txtBoxOpis != null && imgIkonica.Source != null)
            {
                if (Int32.TryParse(txtBoxID.Text, out id) && Int32.TryParse(txtBoxCena.Text, out cena))
                {
                    foreach (Kurs k in kursevi)
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

                    

                    kurs.ID = id;
                    kurs.Cena = cena;
                    kurs.Naziv = txtBoxNaziv.Text;
                    kurs.Vrsta = txtBoxVrsta.Text;
                    kurs.Dostupnost = (bool)rdBtnDostupan.IsChecked;
                    kurs.Opis = txtBoxOpis.Text;
                    kurs.Putanja = imgIkonica.Source;

                    

                    kursevi.Add(kurs);
                    MessageBox.Show("Uspesno ste promenili kurs");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Niste uneli ID ili cenu u dobrom formatu");
                    return;
                }

            }
            else if (rdBtnNedostupan.IsChecked == true && txtBoxID.Text != null && txtBoxNaziv.Text != null && txtBoxCena.Text != null && txtBoxVrsta != null && txtBoxOpis != null && imgIkonica.Source != null)
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

                    

                    kurs.ID = id;
                    kurs.Cena = cena;
                    kurs.Naziv = txtBoxNaziv.Text;
                    kurs.Vrsta = txtBoxVrsta.Text;
                    kurs.Dostupnost = (bool)rdBtnDostupan.IsChecked;
                    kurs.Opis = txtBoxOpis.Text;
                    kurs.Putanja = imgIkonica.Source;

                    

                    kursevi_nedosupni.Add(kurs);
                    MessageBox.Show("Uspesno ste promenili kurs");
                    this.Close();
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

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;
            dlg.Multiselect = false;

            if (dlg.ShowDialog() == true)
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
    }
}
