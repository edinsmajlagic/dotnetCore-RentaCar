using CarHireRC.Model.Requests;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CarHireRC.Mobile.ViewModels.Klijenti
{
    public class PasswordChangeViewModel:BaseViewModel
    {
        private readonly APIService _klijentService = new APIService("Klijent");

        public PasswordChangeViewModel()
        {
            SaveCommand = new Command(async () => await Save());
            OldPasswordCheckCommand = new Command(async () => await OldPasswordCheck());

        }

        public int KlijentID { get; set; }
        public KlijentUpsertRequest klijentUpdateRequest { get; set; } = new KlijentUpsertRequest();

        string _Oldpassword = string.Empty;
        public string OldPassword
        {
            get { return _Oldpassword; }
            set {
                SetProperty(ref _Oldpassword, value);
            
            }
        }

        public async Task OldPasswordCheck()
        {
            var klijent = await _klijentService.GetById<Model.Models.Klijent>(KlijentID);

            string Hash = GenerateHash(klijent.LozinkaSalt, OldPassword);

            if (Hash != klijent.LozinkaHash)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Stara lozinka nije ispravna", "OK");
            }
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


        public ICommand SaveCommand { get; set; }
        public ICommand OldPasswordCheckCommand { get; set; }


        public async Task Save()
        {
            var klijent = await _klijentService.GetById<Model.Models.Klijent>(KlijentID);

            klijentUpdateRequest.KlijentId = KlijentID;
            klijentUpdateRequest.Ime = klijent.Ime;
            klijentUpdateRequest.Prezime = klijent.Prezime;
            klijentUpdateRequest.UserName = klijent.UserName;
            klijentUpdateRequest.Email = klijent.Email;
            klijentUpdateRequest.Telefon = klijent.Telefon;
            klijentUpdateRequest.DatumRodjenja = klijent.DatumRodjenja;
            klijentUpdateRequest.DatumRegistracije = klijent.DatumRegistracije;
            klijentUpdateRequest.GradId = klijent.GradId;
            klijentUpdateRequest.Adresa = klijent.Adresa;
            klijentUpdateRequest.Slika = klijent.Slika;
            klijentUpdateRequest.SlikaThumb = klijent.SlikaThumb;
            klijentUpdateRequest.Status = true;

            if (!string.IsNullOrEmpty(Password))
            {
                klijentUpdateRequest.Password = Password;
                klijentUpdateRequest.PasswordPotvrda = ConfirmPassword;
            }

            //provjera stare lozinke
            string Hash = GenerateHash(klijent.LozinkaSalt, OldPassword);

            if (Hash == klijent.LozinkaHash)
            {
                try
                {
                    await _klijentService.Update<Model.Models.Klijent>(klijentUpdateRequest.KlijentId, klijentUpdateRequest);

                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");

                }
            }
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
    }
}
