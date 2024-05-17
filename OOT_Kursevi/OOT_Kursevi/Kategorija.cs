using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOT_Kursevi
{
    internal class Kategorija
    {
        private int id;
        private string naziv;
        private string opis;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        public Kategorija(int id, string naziv, string opis)
        {
            this.id = id;
            this.naziv = naziv;
            this.opis = opis;
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
    }
}
