using CarHireRC.Model.Models;
using CarHireRC.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CarHireRC.Mobile.ViewModels.Rezervacije
{
    public class RezervacijeViewModel:BaseViewModel
    {
        private readonly APIService _rezervacijeService = new APIService("RezervacijaRentanja");

        public int KlijentID;

        public RezervacijeViewModel(int Klijent)
        {
            KlijentID = Klijent;
            InitCommand = new Command(async () => await Init());

        }
        public RezervacijeViewModel()
        {
            InitCommand = new Command(async () => await Init());

        }
        public ObservableCollection<RezervacijaRentanja> RezervacijeRetanjaList { get; set; } = new ObservableCollection<RezervacijaRentanja>();
        public ObservableCollection<RezervacijaRentanja> RezervacijeRetanjaListZavrsene { get; set; } = new ObservableCollection<RezervacijaRentanja>();
      
        public ICommand InitCommand { get; set; }


        private int ukupnoRezervacija;
        private int ukupnoRezervacijaUToku;
        private int ukupnoRezervacijaZavrsenih;
        private decimal ukupnoUtroseno;

        public int UkupnoRezervacija
        {
            set { SetProperty(ref ukupnoRezervacija, value); }
            get { return ukupnoRezervacija; }
        }
        public int UkupnoRezervacijaUToku
        {
            set { SetProperty(ref ukupnoRezervacijaUToku, value); }
            get { return ukupnoRezervacijaUToku; }
        }
        public int UkupnoRezervacijaZavrsenih
        {
            set { SetProperty(ref ukupnoRezervacijaZavrsenih, value); }
            get { return ukupnoRezervacijaZavrsenih; }
        }
        public decimal UkupnoUtroseno
        {
            set { SetProperty(ref ukupnoUtroseno, value); }
            get { return ukupnoUtroseno; }
        }

        public async Task Init()
        {
            if (KlijentID > 0)
            {
                RezervacijaRentanjaSearchRequest searchRequest = new RezervacijaRentanjaSearchRequest();
                searchRequest.KlijentId = KlijentID;
                searchRequest.Otkazana = false;

                var list = await _rezervacijeService.Get<IEnumerable<Model.Models.RezervacijaRentanja>>(searchRequest);
                

                int brojRezervacija=0, uToku=0, Zavrsene = 0;
                decimal ukupno = 0;
                RezervacijeRetanjaList.Clear();
                RezervacijeRetanjaListZavrsene.Clear();
                foreach (var item in list)
                {
                    if (item.RezervacijaOd > DateTime.Now)
                    {
                        RezervacijeRetanjaList.Add(item);
                        uToku++;
                    }
                    else
                    {
                        RezervacijeRetanjaListZavrsene.Add(item);
                        Zavrsene++;
                    }
                    ukupno += item.IznosSaPopustom;
                    brojRezervacija++;
                }

                
                UkupnoRezervacija = brojRezervacija;
                UkupnoRezervacijaUToku = uToku;
                UkupnoRezervacijaZavrsenih = Zavrsene;
                UkupnoUtroseno = ukupno;
            }
        }
    }
}
