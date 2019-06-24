using CarHireRC.Model.Models;
using CarHireRC.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CarHireRC.Mobile.ViewModels.Klijenti
{
    public class UserProfileViewModel:BaseViewModel
    {
        private readonly APIService _klijentService = new APIService("Klijent");
        private readonly APIService _gradoviService = new APIService("Grad");

        public UserProfileViewModel()
        {
            InitCommand = new Command(async () => await Init());
            SaveCommand = new Command(async () => await Save());

        }

        public KlijentUpsertRequest klijentUpdateRequest { get; set; } = new KlijentUpsertRequest();
        public ObservableCollection<Grad> Grad { get; set; } = new ObservableCollection<Grad>();

        public int KlijentID { get; set; }

        string _ime = string.Empty;
        public string Ime
        {
            get { return _ime; }
            set { SetProperty(ref _ime, value); }
        }

        string _prezime = string.Empty;
        public string Prezime
        {
            get { return _prezime; }
            set { SetProperty(ref _prezime, value); }
        }

        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
                
        }

        bool _provjera=false ;
        public bool Provjera
        {
            get { return _provjera; }
            set { SetProperty(ref _provjera, value); }
        }

        string _adresa = string.Empty;
        public string Adresa
        {
            get { return _adresa; }
            set { SetProperty(ref _adresa, value); }
        }
        string _telefon = string.Empty;
        public string Telefon
        {
            get { return _telefon; }
            set { SetProperty(ref _telefon, value); }
        }
        DateTime _datumRodjenja;
        public DateTime DatumRodjenja
        {
            get { return _datumRodjenja; }
            set { SetProperty(ref _datumRodjenja, value); }
        }

        public byte[] _posiljaocSlika;
        public byte[] PosiljaocSlika
        {
            get { return _posiljaocSlika; }
            set { SetProperty(ref _posiljaocSlika, value); }
        }


        Grad _selectedGrad = null;

        public Grad SelectedGrad
        {
            get { return _selectedGrad; }
            set
            {
                SetProperty(ref _selectedGrad, value);
            }
        }


        public ICommand SaveCommand { get; set; }
        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            if (Grad.Count == 0)
            {
                var gradoviList = await _gradoviService.Get<List<Grad>>(null);

                foreach (var grad in gradoviList)
                {
                    Grad.Add(grad);
                }

                if (KlijentID > 0)
                {
                    var Klijent = await _klijentService.GetById<Model.Models.Klijent>(KlijentID);
                    klijentUpdateRequest.KlijentId = Klijent.KlijentId;

                    Ime = Klijent.Ime;
                    Prezime = Klijent.Prezime;
                    Username = Klijent.UserName;
                    Email = Klijent.Email;
                    Telefon = Klijent.Telefon;
                    DatumRodjenja = Klijent.DatumRodjenja;
                    klijentUpdateRequest.DatumRegistracije = Klijent.DatumRegistracije;
                    Grad g = await _gradoviService.GetById<Model.Models.Grad>(Klijent.GradId);
                    _selectedGrad = g;
                    SelectedGrad = g;
                    Adresa = Klijent.Adresa;
                    PosiljaocSlika = Klijent.Slika;


                }

            }
        }



        public async Task Save()
        {

            //provjera da li username i email postoje
            bool usernameexists = await CheckUsername(Username);
            bool emailexists = await CheckEmail(Email);

            if (!usernameexists && !emailexists)
            {
                klijentUpdateRequest.KlijentId = KlijentID;
                klijentUpdateRequest.Ime = Ime;
                klijentUpdateRequest.Prezime = Prezime;
                klijentUpdateRequest.UserName = Username;
                klijentUpdateRequest.Email = Email;
                klijentUpdateRequest.Telefon = Telefon;
                klijentUpdateRequest.DatumRodjenja = DatumRodjenja;
                klijentUpdateRequest.GradId = SelectedGrad.GradId;
                klijentUpdateRequest.Adresa = Adresa;
                klijentUpdateRequest.Slika = _posiljaocSlika;
                klijentUpdateRequest.SlikaThumb = _posiljaocSlika;
                klijentUpdateRequest.Status = true;



                try
                {
                    await _klijentService.Update<Model.Models.Klijent>(klijentUpdateRequest.KlijentId, klijentUpdateRequest);

                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");

                }
            }
            else
            {
                _provjera = true;
                await Application.Current.MainPage.DisplayAlert("Greška", "Uneseni podaci nisu validni !", "OK");

            }
        }

        //Provjera da li je username zauzet
        public async Task<bool> CheckUsername(string text)
        {
            bool postoji = false;
            KlijentSearchRequest klijentSearch = new KlijentSearchRequest()
            {
                Status = true,
                UserName = text
            };


            var users = await _klijentService.Get<List<Model.Models.Klijent>>(klijentSearch);
            if (users.Count > 0)
            {
                foreach (var item in users)
                {
                    if (item.KlijentId != KlijentID)
                        postoji = true;

                }
            }

            klijentSearch.Status = false;
            users = await _klijentService.Get<List<Model.Models.Klijent>>(klijentSearch);
            if (users.Count > 0)
            {
                foreach (var item in users)
                {
                    if (item.KlijentId != KlijentID)
                        postoji = true;

                }
            }
            _provjera = postoji;

            return postoji;
        }
        //Provjera da li je email zauzet
        public async Task<bool> CheckEmail(string text)
        {
            bool postoji = false;
            KlijentSearchRequest klijentSearch = new KlijentSearchRequest()
            {
                Status = true,
                Email = text
            };


            var users = await _klijentService.Get<List<Model.Models.Klijent>>(klijentSearch);
            if (users.Count > 0)
            {
                foreach (var item in users)
                {
                    if (item.KlijentId != KlijentID)
                        postoji = true;

                }
            }

            klijentSearch.Status = false;
            users = await _klijentService.Get<List<Model.Models.Klijent>>(klijentSearch);
            if (users.Count > 0)
            {
                foreach (var item in users)
                {
                    if (item.KlijentId != KlijentID)
                        postoji = true;

                }
            }
            _provjera = postoji;
            return postoji;
        }
    }
}
