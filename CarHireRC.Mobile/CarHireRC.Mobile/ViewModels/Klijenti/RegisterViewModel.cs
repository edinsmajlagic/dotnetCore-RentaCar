using CarHireRC.Mobile.Converters;
using CarHireRC.Mobile.Views;
using CarHireRC.Model.Models;
using CarHireRC.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CarHireRC.Mobile.ViewModels.Klijenti
{
    public class RegisterViewModel:BaseViewModel
    {
        private readonly APIService _serviceKlijent = new APIService("Klijent");
        private readonly APIService _gradoviService = new APIService("Grad");

        public RegisterViewModel()
        {
            InitCommand = new Command(async () => await Init());
            RegisterCommand = new Command(async () => await Register());
            LoginCommand = new Command(()=> Login());

        }


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

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        string _confirmPassword = string.Empty;
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set { SetProperty(ref _confirmPassword, value); }
        }

        string _adresa = string.Empty;
        public string Adresa
        {
            get { return _adresa; }
            set { SetProperty(ref _adresa, value); }
        }

        DateTime _datumRodjenja ;
        public DateTime DatumRodjenja
        {
            get { return _datumRodjenja; }
            set { SetProperty(ref _datumRodjenja, value); }
        }

        public KlijentUpsertRequest klijentUpsert { get; set; } = new KlijentUpsertRequest();
        public ObservableCollection<Grad> Grad { get; set; } = new ObservableCollection<Grad>();


        Grad _selectedGrad = null;

        public Grad SelectedGrad
        {
            get { return _selectedGrad; }
            set
            {
                SetProperty(ref _selectedGrad, value);
            }
        }

        public ICommand RegisterCommand { get; set; }
        public ICommand InitCommand { get; set; }
        public ICommand LoginCommand { get; set; }

       public  void Login()
        {
             Application.Current.MainPage =new LoginPage();
        }
            public async Task Init()
        {
            if (Grad.Count == 0)
            {
                var gradoviList = await _gradoviService.Get<List<Grad>>(null);

                foreach (var grad in gradoviList)
                {
                    Grad.Add(grad);
                }
            }
        }

           public async Task Register()
           {
                IsBusy = true;

            //provjera da li username i email postoje
                bool usernameexists = await CheckUsername(Username);
                bool emailexists = await CheckEmail(Email);

                if (!usernameexists && !emailexists)
                {
                    klijentUpsert.Ime = Ime;
                    klijentUpsert.Prezime = Prezime;
                    klijentUpsert.Email = Email;
                    klijentUpsert.UserName = Username;
                    klijentUpsert.DatumRodjenja = DatumRodjenja;
                    klijentUpsert.DatumRegistracije = DateTime.Now;
                    klijentUpsert.Adresa = Adresa;
                    klijentUpsert.Password = Password;
                    klijentUpsert.PasswordPotvrda = ConfirmPassword;
                    klijentUpsert.GradId = SelectedGrad.GradId;
                    klijentUpsert.Status = true;


                  
                    try
                    {
                        var entity = await _serviceKlijent.Insert<Model.Models.Klijent>(klijentUpsert);
                        if (entity != null)
                        {
                            await Application.Current.MainPage.DisplayAlert("Obavijest", "Uspješno ste se registrovali", "OK");
                            Application.Current.MainPage = new MainPage(entity.KlijentId);
                        }

                    }
                    catch (Exception ex)
                    {
                        string msg = "";
                        if (ex.InnerException != null)
                            msg = ex.InnerException.ToString() + " - ";
                        await Application.Current.MainPage.DisplayAlert("Greška", msg + ex.Message, "OK");
                    }
                }
                else
                 {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Uneseni podaci nisu validni !", "OK");

                 }
        }

        //provjera username-a da li je zauzet
        public async Task<bool> CheckUsername(string text)
        {
            bool postoji = false;
            KlijentSearchRequest klijentSearch = new KlijentSearchRequest()
            {
                Status = true,
                UserName = text
            };


            var users = await _serviceKlijent.Get<List<Model.Models.Klijent>>(klijentSearch);
            if (users.Count > 0)
            {
               postoji = true;
            }

            klijentSearch.Status = false;
            users = await _serviceKlijent.Get<List<Model.Models.Klijent>>(klijentSearch);
            if (users.Count > 0)
            {
                postoji = true;
            }
            return postoji;
        }

        //provjera email-a da li je zauzet
        public async Task<bool> CheckEmail(string text)
        {
            bool postoji = false;
            KlijentSearchRequest klijentSearch = new KlijentSearchRequest()
            {
                Status = true,
                Email = text
            };


            var users = await _serviceKlijent.Get<List<Model.Models.Klijent>>(klijentSearch);
            if (users.Count > 0)
            {
                postoji = true;
            }

            klijentSearch.Status = false;
            users = await _serviceKlijent.Get<List<Model.Models.Klijent>>(klijentSearch);
            if (users.Count > 0)
            {
                postoji = true;
            }
            return postoji;
        }


    }
}
