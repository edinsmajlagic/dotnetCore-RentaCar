using CarHireRC.Model.Requests;
using CarHireRC.WinUI.Automobili;
using CarHireRC.WinUI.Home;
using CarHireRC.WinUI.Klijenti;
using CarHireRC.WinUI.Korisnici;
using CarHireRC.WinUI.Poruka;
using CarHireRC.WinUI.RezervacijeVozila;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CarHireRC.WinUI
{
    public partial class DashboardForm : Form
    {
        private readonly APIService _KorisnikService = new APIService("Korisnik");
        private readonly APIService _korisniciUlogeService = new APIService("KorisniciUloga");

        public string _username=null;
        public int KorisnikId;
        private bool ulogaAdmin = false, ulogaMenadzer = false, ulogaUposlenik = false;

        public KorisniciSearchRequest _searchRequest = new KorisniciSearchRequest();

        public DashboardForm(string username, bool ulogaA, bool ulogaM, bool ulogaU)
        {
            _username = username;
            _searchRequest.UserName = username;
            ulogaAdmin = ulogaA;
            ulogaMenadzer = ulogaM;
            ulogaUposlenik = ulogaU;
            InitializeComponent();
        }

        //Ucitavanje dashboard forme
        private async void DashboardForm_Load(object sender, EventArgs e)
        {
            _searchRequest.Status = true;
            var users = await _KorisnikService.Get<List<Model.Models.Korisnici>>(_searchRequest);

            var user = users.FirstOrDefault();


            if (user != null)
            {

                lblKorisnik.Text = user.Ime + ' ' + user.Prezime;
                KorisnikId = user.KorisnikId;
                lblKorisnikId.Text = KorisnikId.ToString();

                if (user.Slika != null)
                {
                    byte[] slika = user.Slika;

                    MemoryStream memoryStream = new MemoryStream(slika);
                    pictureBox1.Image = Image.FromStream(memoryStream);
                }
                //Dobavljanje svih uloga od korisnika
                //inicijalizacija labele uloge logiranog korisnika

                if (ulogaAdmin)
                {
                    lblUloga.Text = "Administrator";

                }
                else if (ulogaMenadzer)
                {
                    lblUloga.Text = "Menadžer";

                }
                else
                {
                    lblUloga.Text = "Uposlenik";
                }



                pnlStats.Top = btnHome.Top;
                pnlStats.Height = btnHome.Height;
                frmHome frm = new frmHome(KorisnikId, ulogaAdmin, ulogaMenadzer, ulogaUposlenik);
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                frm.TopLevel = false;
                pnlMjesto.Controls.Clear();

                pnlMjesto.Controls.Add(frm);
                frm.Dock = DockStyle.Fill;
                frm.Show();


            }
        }

        //Pregled home tab-a
        private void btnHome_Click(object sender, EventArgs e)
        {
            pnlStats.Top = btnHome.Top;
            pnlStats.Height = btnHome.Height;
            frmHome frm = new frmHome(KorisnikId,ulogaAdmin,ulogaMenadzer,ulogaUposlenik);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.TopLevel = false;
            pnlMjesto.Controls.Clear();

            pnlMjesto.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();

        }

        //Pregled ličnih poruka
        private void btnPoruke_Click(object sender, EventArgs e)
        {
            pnlStats.Top = btnPoruke.Top;
            pnlStats.Height = btnPoruke.Height;
            frmPoruke frm = new frmPoruke(KorisnikId);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.TopLevel = false;
            pnlMjesto.Controls.Clear();

            pnlMjesto.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();

        }

        //Pregled korisnika
        private void btnKorisnici_Click(object sender, EventArgs e)
        {
            pnlStats.Top = btnKorisnici.Top;
            pnlStats.Height = btnKorisnici.Height;
            frmKorisnici frm = new frmKorisnici( ulogaAdmin, ulogaMenadzer, ulogaUposlenik);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.TopLevel = false;
            pnlMjesto.Controls.Clear();

            pnlMjesto.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        //Pregled klijenata
        private void btnKlijenti_Click(object sender, EventArgs e)
        {
            pnlStats.Top = btnKlijenti.Top;
            pnlStats.Height = btnKlijenti.Height;
            frmKlijenti frm = new frmKlijenti( ulogaAdmin, ulogaMenadzer, ulogaUposlenik);
            frm.TopLevel = false;
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            pnlMjesto.Controls.Clear();
            pnlMjesto.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();

        }

        //Pregled vozila
        private void btnVozila_Click(object sender, EventArgs e)
        {
            pnlStats.Top = btnVozila.Top;
            pnlStats.Height = btnVozila.Height;
            frmVozila frm = new frmVozila(KorisnikId, ulogaAdmin, ulogaMenadzer, ulogaUposlenik);
            frm.TopLevel = false;
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            pnlMjesto.Controls.Clear();
            pnlMjesto.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            
            frm.Show();
        }

        //Pregled rezervacija
        private void btnRezervacije_Click(object sender, EventArgs e)
        {
            pnlStats.Top = btnRezervacije.Top;
            pnlStats.Height = btnRezervacije.Height;
            frmRezervacije frm = new frmRezervacije(KorisnikId, ulogaAdmin, ulogaMenadzer, ulogaUposlenik);
            frm.TopLevel = false;
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            pnlMjesto.Controls.Clear();
            pnlMjesto.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();


        }

        //Pregled profila prijavljenog korisnika
        private void btnProfil_Click(object sender, EventArgs e)
        {
            frmProfil frm = new frmProfil(KorisnikId);
            frm.Height = pnlMjesto.Height;
            frm.Width = pnlMjesto.Width;
            frm.TopLevel = false;
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            pnlMjesto.Controls.Clear();
            pnlMjesto.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

   
        //Odjava sa aplikacije
        private void btnOdjaviSe_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            this.Visible = false;
            frm.Show();
        }

     
    }
}
