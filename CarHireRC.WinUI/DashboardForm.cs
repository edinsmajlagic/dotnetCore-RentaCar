﻿using CarHireRC.Model.Requests;
using CarHireRC.WinUI.Automobili;
using CarHireRC.WinUI.Klijenti;
using CarHireRC.WinUI.Korisnici;
using CarHireRC.WinUI.Poruka;
using CarHireRC.WinUI.RezervacijeVozila;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CarHireRC.WinUI
{
    public partial class DashboardForm : Form
    {
        private readonly APIService _KorisnikService = new APIService("Korisnik");

        public string _username=null;
        public int KorisnikId;
        
        public KorisniciSearchRequest _searchRequest = new KorisniciSearchRequest();

        public DashboardForm(string username)
        {
            _username = username;
            _searchRequest.UserName = username;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlStats.Top = btnHome.Top;
            pnlStats.Height = btnHome.Height;
            pnlMjesto.Controls.Clear();

        }

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

        private void btnKorisnici_Click(object sender, EventArgs e)
        {
            pnlStats.Top = btnKorisnici.Top;
            pnlStats.Height = btnKorisnici.Height;
            frmKorisnici frm = new frmKorisnici();
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.TopLevel = false;
            pnlMjesto.Controls.Clear();

            pnlMjesto.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnKlijenti_Click(object sender, EventArgs e)
        {
            pnlStats.Top = btnKlijenti.Top;
            pnlStats.Height = btnKlijenti.Height;
            frmKlijenti frm = new frmKlijenti();
            frm.TopLevel = false;
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            pnlMjesto.Controls.Clear();
            pnlMjesto.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();

        }

        private void btnVozila_Click(object sender, EventArgs e)
        {
            pnlStats.Top = btnVozila.Top;
            pnlStats.Height = btnVozila.Height;
            frmVozila frm = new frmVozila(KorisnikId);
            frm.TopLevel = false;
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            pnlMjesto.Controls.Clear();
            pnlMjesto.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            
            frm.Show();
        }

        private void btnRezervacije_Click(object sender, EventArgs e)
        {
            pnlStats.Top = btnRezervacije.Top;
            pnlStats.Height = btnRezervacije.Height;
            frmRezervacije frm = new frmRezervacije(KorisnikId);
            frm.TopLevel = false;
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            pnlMjesto.Controls.Clear();
            pnlMjesto.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();


        }

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

   

        private void btnOdjaviSe_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            this.Visible = false;
            frm.Show();
        }

        private async void DashboardForm_Load(object sender, EventArgs e)
        {
            var users = await _KorisnikService.Get<List<Model.Models.Korisnici>>(_searchRequest);
            var user = users.FirstOrDefault();
           

            if(user != null)
            {
                lblKorisnik.Text = user.Ime + ' ' + user.Prezime;
                KorisnikId = user.KorisnikId;
                lblKorisnikId.Text = KorisnikId.ToString();
            }
        }
    }
}
