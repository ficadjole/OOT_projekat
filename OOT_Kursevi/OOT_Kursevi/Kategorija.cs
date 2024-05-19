using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OOT_Kursevi
{
    public class Kategorija : INotifyPropertyChanged
    {
        private int id;
        private string naziv;
        private string opis;
        private List<Kurs> kursevi = new List<Kurs>();
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

        public Kategorija(int id, string naziv, string opis, List<Kurs> kursevi, string putanja_slike)
        {
            this.id = id;
            this.naziv = naziv;
            this.opis = opis;
            this.kursevi = kursevi;
            putanja = new BitmapImage(new Uri(putanja_slike, UriKind.Relative));
            slika = new Image();
            slika.Source = putanja;
        }

        public Kategorija() { }

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

        public string Opis
        {
            get { return this.opis; }
            set
            {
                if (this.opis != value)
                {
                    this.opis = value;
                    this.NotifyPropertyChanged("Opis");
                }
            }
        }

        public List<Kurs> Kursevi
        {
            get { return this.kursevi; }
            set
            {
                if (this.kursevi != value)
                {
                    this.kursevi = value;
                    this.NotifyPropertyChanged("Kursevi");
                }
            }
        }

        public ImageSource PutanjaK
        {
            get { return this.putanja; }
            set
            {
                this.putanja = value;
                this.NotifyPropertyChanged("PutanjaK");
            }
        }
    }
}
