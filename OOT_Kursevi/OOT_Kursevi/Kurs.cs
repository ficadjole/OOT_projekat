using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOT_Kursevi
{
    class Kurs : INotifyPropertyChanged
    {
        private string naziv;
        private int cena;
        private string vrsta;
        private bool dostupnost;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string v)
        {
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        public Kurs(string naziv, int cena, string vrsta, bool dostupnost)
        {
            this.naziv = naziv;
            this.cena = cena;
            this.vrsta = vrsta;
            this.dostupnost = dostupnost;
        }

        public Kurs() { }

        public string Naziv { 
            get { return this.naziv; }
            set
            {
                if(this.naziv != value)
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
                if(this.cena != value)
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
                if(this.vrsta != value)
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
                if(this.dostupnost != value)
                {
                    this.dostupnost = value;
                    this.NotifyPropertyChanged("Dostupnost");
                }
            }
    }
}
