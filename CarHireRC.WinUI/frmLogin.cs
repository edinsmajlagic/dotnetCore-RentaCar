using CarHireRC.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarHireRC.WinUI
{
    public partial class frmLogin : Form
    {
        APIService _service = new APIService("Korisnik");
        private readonly APIService _korisniciUlogeService = new APIService("KorisniciUloga");

        private bool ulogaAdmin = false, ulogaMenadzer = false, ulogaUposlenik = false;
        public frmLogin()
        {
            InitializeComponent();
        }

     

     

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                APIService.Username = txtUsername.Text;
                APIService.Password = txtPassword.Text;
                await _service.Get<dynamic>(null);
                string username = txtUsername.Text;

                KorisniciSearchRequest korisniciSearch = new KorisniciSearchRequest();
                korisniciSearch.UserName = APIService.Username;
                korisniciSearch.Status = true;

                var korisnici = await _service.Get<List<Model.Models.Korisnici>>(korisniciSearch);


                var k = korisnici.FirstOrDefault();
                if (k == null)
                {
                    throw new Exception("Unos nije ispravan");
                }
                else
                {
                    string pwHash = GenerateHash(k.LozinkaSalt, APIService.Password);

                    if (k.UserName == korisniciSearch.UserName && k.LozinkaHash == pwHash)
                    {
                        this.Visible = false;

                        KorisniciUlogeSearchRequest korisniciUlogeSearch = new KorisniciUlogeSearchRequest()
                        {
                            KorisnikId = k.KorisnikId
                        };

                        //Dobavljanje svih uloga od korisnika
                        //inicijalizacija labele uloge logiranog korisnika
                        var uloge = await _korisniciUlogeService.Get<List<Model.Models.KorisniciUloge>>(korisniciUlogeSearch);
                        foreach (var uloga in uloge)
                        {
                            if (uloga.Uloga.Naziv == "Administrator")
                            {
                                ulogaAdmin = true;
                            }
                            else if (uloga.Uloga.Naziv == "Menadžer")
                            {
                                ulogaMenadzer = true;
                            }
                            else
                            {
                                ulogaUposlenik = true;
                            }

                        }


                        DashboardForm frm = new DashboardForm(username,ulogaAdmin,ulogaMenadzer,ulogaUposlenik);
                        frm.Show();
                    }
                    else
                        throw new Exception("Unos nije ispravan");
               }

               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Authentifikacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
