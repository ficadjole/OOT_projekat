using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OOT_Kursevi
{
    public class Kurs : INotifyPropertyChanged
    {
        private int id;
        private string naziv;
        private int cena;
        private string vrsta;
        private bool dostupnost;
        private string opis;
        private ImageSource putanja;
        private Image slika;


        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        public Kurs(int iD,string naziv, int cena, string vrsta, string opis, bool dostupnost,string putanja_slike)
        {
            id = iD;
            this.naziv = naziv;
            this.cena = cena;
            this.vrsta = vrsta;
            this.dostupnost = dostupnost;
            this.opis = opis;
            putanja = new BitmapImage(new Uri(putanja_slike, UriKind.Relative));
            slika = new Image();
            slika.Source = putanja;

        }

        public Kurs() { }

        public int ID
        {
            get { return this.id; }
            set
            {
                if (this.id != value)
                {
                    this.id = value;
                    this.NotifyPropertyChanged("ID");
                }
            }
        }

        public string Naziv
        {
            get { return this.naziv; }
            set
            {
                if (this.naziv != value)
                {
                    this.naziv = value;
                    this.NotifyPropertyChanged("Naziv");
                }
            }
        }

        public int Cena
        {
            get { return this.cena; }
            set
            {
                if (this.cena != value)
                {
                    this.cena = value;
                    this.NotifyPropertyChanged("Cena");
                }
            }
        }

        public string Vrsta
        {
            get { return this.vrsta; }
            set
            {
                if (this.vrsta != value)
                {
                    this.vrsta = value;
                    this.NotifyPropertyChanged("Vrsta");
                }
            }
        }

        public bool Dostupnost
        {
            get { return this.dostupnost; }
            set
            {
                if (this.dostupnost != value)
                {
                    this.dostupnost = value;
                    this.NotifyPropertyChanged("Dostupnost");
                }
            }
        }

        public string Opis
        {
            get { return this.opis; }
            set
            {
                if(this.opis != value)
                {
                    this.opis = value;
                    this.NotifyPropertyChanged("Opis");
                }
            }
        }

        public ImageSource Putanja
        {
            get { return this.putanja; }
            set
            {
                this.putanja = value;
                this.NotifyPropertyChanged("Putanja");
            }
        }
    }
}
