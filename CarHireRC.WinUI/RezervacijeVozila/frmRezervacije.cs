﻿using CarHireRC.Model.Requests;
using CarHireRC.WinUI.Helper;
using CarHireRC.WinUI.Poruka;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarHireRC.WinUI.RezervacijeVozila
{
    public partial class frmRezervacije : Form
    {
        private readonly APIService _RezervacijeService = new APIService("RezervacijaRentanja");
        private readonly APIService _AutomobilService = new APIService("Automobil");
        private readonly APIService _KlijentService = new APIService("Klijent");
        private readonly APIService _modeliService = new APIService("Model");
        private readonly APIService _proizvodjaciService = new APIService("Proizvodjac");
        RezervacijaRentanjaUpsertRequest Uredirequest = new RezervacijaRentanjaUpsertRequest();
        public int _RezervacijaID = 0, _UserID = 0;
        private bool ulogaAdmin = false, ulogaMenadzer = false, ulogaUposlenik = false;

        public frmRezervacije(int UID, bool ulogaA, bool ulogaM, bool ulogaU)
        {
            _UserID = UID;
            ulogaAdmin = ulogaA;
            ulogaMenadzer = ulogaM;
            ulogaUposlenik = ulogaU;
            InitializeComponent();
        }

        private async void frmRezervacije_Load(object sender, EventArgs e)
        {
            metroTabControl1.HideTab(metroTabPage2);
            metroTabControl1.SelectedTab = metroTabPage1;
            await LoadProizvodjacVozila();
            await LoadModelVozila(null);
            dtpOd.Value = DateTime.Now.Date;
            dtpDo.Value = DateTime.Now.Date;
            dtpDatumKreiranja.MaxDate = DateTime.Now.Date;
            dtpDatumKreiranja.Value = DateTime.Now.Date;
        }

        private async void dgvRezervacije_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ulogaAdmin || ulogaUposlenik)
            {
                int Id = 0;
                if (dgvRezervacije.RowCount > 0)
                {
                    var val = dgvRezervacije.SelectedRows[0].Cells[0].Value;
                    Id = int.Parse(val.ToString());
                }
                if (_RezervacijaID <= 0 && Id > 0)
                {
                    _RezervacijaID = Id;
                    metroTabControl1.ShowTab(metroTabPage2);
                    await UcitajEditTab();
                    metroTabControl1.SelectedTab = metroTabPage2;
                }
            }
        }


        //Pretraga
        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            await PretragaRezervacija();
        }

        private async Task PretragaRezervacija()
        {
            var search = new RezervacijaRentanjaSearchRequest();

            var ModelidObj = cmbSearchModel.SelectedValue;
            var ProizvodjaciObj = cmbSearchProizvodjac.SelectedValue;

            if (int.TryParse(ModelidObj.ToString(), out int ModelId))
            {
                search.ModelId = ModelId;
            }
            if (int.TryParse(ProizvodjaciObj.ToString(), out int ProizvodjacId))
            {
                search.ProizvodjacId = ProizvodjacId;
            }

            if (txtSearchIme.Text != "")
            {
                search.Ime = txtSearchIme.Text;
            }
            if (txtSearchPrezime.Text != "")
            {
                search.Prezime = txtSearchPrezime.Text;
            }
            if (txtSearchUsername.Text != "")
            {
                search.Username = txtSearchUsername.Text;
            }
            if (txtRegOznaka.Text != "")
            {
                search.RegistarskaOznaka = txtRegOznaka.Text.ToLower();
            }
            if (chBDK.Checked)
            {
                search.DatumKreiranja = dtpDatumKreiranja.Value;
            }
            if (chbDo.Checked)
            {
                search.RezervacijaDo = dtpDo.Value;
            }
            if (chBOd.Checked)
            {
                search.RezervacijaOd = dtpOd.Value;
            }
            if (!cbSveRezervacije.Checked)
            {
                if (chBoxKasko.Checked)
                    search.KaskoOsiguranje = chBoxKasko.Checked;
                if (chBoxVracanjeUPoslovnicu.Checked)
                    search.VracanjeUposlovnicu = chBoxVracanjeUPoslovnicu.Checked;
                if (chbAktivan.Checked)
                    search.StatusAktivna = chbAktivan.Checked;
                if (cbOtkazane.Checked)
                    search.Otkazana = cbOtkazane.Checked;
            }


            var result = await _RezervacijeService.Get<List<Model.Models.RezervacijaRentanja>>(search);
            dgvRezervacije.AutoGenerateColumns = false;
            dgvRezervacije.DataSource = result;
        }


        //Inicijalizacija komponenti forme za uređivanje rezervacije
        private async Task UcitajEditTab()
        {
            var rezervacija = await _RezervacijeService.GetById<Model.Models.RezervacijaRentanja>(_RezervacijaID);
            var automobil = await _AutomobilService.GetById<Model.Models.Automobil>(rezervacija.AutomobilId);

            KlijentSearchRequest klijentSearch = new KlijentSearchRequest();
            klijentSearch.KlijentId = rezervacija.KlijentId;
            var klijenti = await _KlijentService.Get<List<Model.Models.Klijent>>(klijentSearch);

            var klijent = klijenti.First();

            Uredirequest.AutomobilId = rezervacija.AutomobilId;
            Uredirequest.KlijentId = rezervacija.KlijentId;
            Uredirequest.RacunId = rezervacija.RacunId;
            Uredirequest.DatumKreiranja = rezervacija.DatumKreiranja;
            Uredirequest.RezervacijaDo = rezervacija.RezervacijaDo;
            Uredirequest.RezervacijaOd = rezervacija.RezervacijaOd;
            Uredirequest.Iznos = rezervacija.Iznos;
            Uredirequest.IznosSaPopustom = rezervacija.IznosSaPopustom;
            Uredirequest.Popust = rezervacija.Popust;
            Uredirequest.KaskoOsiguranje = rezervacija.KaskoOsiguranje;
            Uredirequest.VracanjeUposlovnicu = rezervacija.VracanjeUposlovnicu;

            decimal popust = Convert.ToDecimal(rezervacija.Popust);

            if (automobil.Slika.Length > 0)
            {
                byte[] slika = automobil.Slika;
                MemoryStream memoryStream = new MemoryStream(slika);
                pictureBox1.Image = Image.FromStream(memoryStream);
            }


            txtKlijent.Text = klijent.Ime + " " + klijent.Prezime + "  (" + klijent.UserName + ")";
            txtDatumKreiranjaRezervacije.Text = Uredirequest.DatumKreiranja.Date.ToString();
            txtLokacijaPreuzimanja.Text = Uredirequest.LokacijaPreuzimanja;
            txtVozilo.Text = automobil.ProizvodjacModel;
            txtRegOznake.Text = automobil.RegistarskaOznaka;
            txtPopust.Text = Uredirequest.Popust.ToString();
            txtIznosSaPopustom.Text = Uredirequest.IznosSaPopustom.ToString();
            dtpDatumVazenjaDo.Value = Uredirequest.RezervacijaDo;
            dtpDatumVazenjaOd.Value = Uredirequest.RezervacijaOd;
            lblIznosBezPopusta.Text = Uredirequest.Iznos.ToString();
            chbKasko.Checked = Uredirequest.KaskoOsiguranje;
            chbVracanjaUPoslovnicu.Checked = Uredirequest.VracanjeUposlovnicu;

            //Ako je zavrsena ili otkazana
            if (rezervacija.RezervacijaDo < DateTime.Now || rezervacija.Otkazana)
                txtPopust.Enabled = false;

        }

        //Spremanje uređivanja podataka o rezervaciji
        private async void btnSacuvajUredi_Click(object sender, EventArgs e)
        {
            bool provjera = this.ValidateChildren();

            if (provjera)
            {
                Uredirequest.LokacijaPreuzimanja = txtLokacijaPreuzimanja.Text;
                Uredirequest.Popust = double.Parse(txtPopust.Text);
                decimal popust = Convert.ToDecimal(Uredirequest.Popust);
                Uredirequest.IznosSaPopustom = Uredirequest.Iznos - (Uredirequest.Iznos * popust);
                Uredirequest.RezervacijaDo = dtpDatumVazenjaDo.Value;
                Uredirequest.RezervacijaOd = dtpDatumVazenjaOd.Value;
                Uredirequest.KaskoOsiguranje = chbKasko.Checked;
                Uredirequest.VracanjeUposlovnicu = chBoxVracanjeUPoslovnicu.Checked;
                Uredirequest.RezervacijaRentanjaId = _RezervacijaID;

                var entity = await _RezervacijeService.Update<Model.Models.RezervacijaRentanja>(_RezervacijaID, Uredirequest);
                if (entity != null)
                {
                    MessageBox.Show("Uspješno izmjenjeni podaci o rezervaciji");
                    _RezervacijaID = 0;
                    metroTabControl1.SelectedTab = metroTabPage1;
                    metroTabControl1.HideTab(metroTabPage2);
                    await PretragaRezervacija();
                }
            }
        }


        //Klik na dugme za slanje poruke klijentu sa rezervacije
        private void btnPoruka_Click(object sender, EventArgs e)
        {
            frmNovaPorukaDialog frm = new frmNovaPorukaDialog(_RezervacijaID, _UserID);
            frm.Show();
        }


        //Učitavanje vrijednosti za checkbox proizvođača vozila
        private async Task LoadProizvodjacVozila()
        {
            var result = await _proizvodjaciService.Get<List<Model.Models.Proizvodjac>>(null);
            result.Insert(0, new Model.Models.Proizvodjac());

            ComboBoxLoad<Model.Models.Proizvodjac> cmbLoad = new ComboBoxLoad<Model.Models.Proizvodjac>();
            cmbLoad.Load(cmbSearchProizvodjac, result, "Naziv", "ProizvodjacId");
        }

        //Učitavanje vrijednosti za checkbox model vozila
        private async Task LoadModelVozila(int? proizvodjacId)
        {
            ModelAutomobilaSearch request = new ModelAutomobilaSearch();
            if (proizvodjacId != null)
            {
                request.ProizvodjacId = proizvodjacId;
            }

            var result = await _modeliService.Get<List<Model.Models.ModelAutomobila>>(request);
            result.Insert(0, new Model.Models.ModelAutomobila());

            ComboBoxLoad<Model.Models.ModelAutomobila> cmbLoad = new ComboBoxLoad<Model.Models.ModelAutomobila>();
            cmbLoad.Load(cmbSearchModel, result, "Naziv", "ModelId");

        }



        #region Combobox changed
        //Na izmjenu vrijednosti comboboxa proizvođača
        private async void cmbSearchProizvodjac_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ModelidObj = cmbSearchProizvodjac.SelectedValue;
            if (int.TryParse(ModelidObj.ToString(), out int ProizvodjacId))
            {
                await LoadModelVozila(ProizvodjacId);
            }
        }

        //Checkbox dozvoli/blokiraj unos datuma kreiranja rezervacije
        private void chBDK_CheckedChanged(object sender, EventArgs e)
        {
            if (chBDK.Checked)
                dtpDatumKreiranja.Enabled = true;
            else
                dtpDatumKreiranja.Enabled = false;

        }

        //Checkbox dozvoli/blokiraj unos datuma važenja rezervacije
        private void chBOd_CheckedChanged(object sender, EventArgs e)
        {
            if (chBOd.Checked)
                dtpOd.Enabled = true;
            else
                dtpOd.Enabled = false;
        }

        //Checkbox dozvoli/blokiraj unos datuma važenja rezervacije
        private void chbDo_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDo.Checked)
                dtpDo.Enabled = true;
            else
                dtpDo.Enabled = false;
        }
        //Ako je uposlenik izmjenio iznos popusta
        private void txtPopust_TextChanged(object sender, EventArgs e)
        {
            if (txtPopust.Text != "")
            {
                decimal popust = Convert.ToDecimal(txtPopust.Text);
                popust /= 100;
                decimal iznosSaPopustomNovi = Uredirequest.Iznos - (Uredirequest.Iznos * popust);

                txtIznosSaPopustom.Text = iznosSaPopustomNovi.ToString() + " KM";
            }
        }


        //Ako je izmjenjena vrijednost checkbox-a za prikaz svih rezervacija
        private void cbSveRezervacije_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSveRezervacije.Checked)
            {
                chBoxKasko.Enabled = false;
                chbAktivan.Enabled = false;
                chBoxVracanjeUPoslovnicu.Enabled = false;
                cbOtkazane.Enabled = false;
            }
            else
            {
                //ako je odznačeno dozvoli izmjenu checkbox-ova
                chBoxKasko.Enabled = true;
                chbAktivan.Enabled = true;
                chBoxVracanjeUPoslovnicu.Enabled = true;
                cbOtkazane.Enabled = true;

            }
        }
        #endregion 


        #region Keypress validation
        private void txtSearchIme_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je uneseno slovo ili prazno mjesto
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }
        }

        private void txtSearchPrezime_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je uneseno slovo ili prazno mjesto
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }
        }

        private void txtRegOznaka_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je uneseno slovo ili prazno mjesto
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void txtSearchUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je uneseno slovo ili prazno mjesto
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtPopust_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je unesen broj
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        #endregion 

        
    }
}
