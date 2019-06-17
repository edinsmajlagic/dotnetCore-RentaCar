using CarHireRC.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarHireRC.WinUI
{
    public partial class frmNovaPorukaDialog : Form
    {
        private readonly APIService _porukaService = new APIService("Poruka");
        private readonly APIService _rezervacijaService = new APIService("RezervacijaRentanja");
        private int _RezervacijaID = 0, _UposlenikID = 0;

        public frmNovaPorukaDialog(int RID,int UID)
        {
            _RezervacijaID = RID;
            _UposlenikID = UID;
            InitializeComponent();
        }

        private async void frmNovaPorukaDialog_Load(object sender, EventArgs e)
        {
            var rezervacija = await _rezervacijaService.GetById<Model.Models.RezervacijaRentanja>(_RezervacijaID);
            lblRezervacija.Text = rezervacija.RezervacijaInformacije;
            lblKlijent.Text = rezervacija.Klijent;

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var rezervacija = await _rezervacijaService.GetById<Model.Models.RezervacijaRentanja>(_RezervacijaID);

            PorukaUpsertRequest porukaUpsert = new PorukaUpsertRequest();
            porukaUpsert.RezervacijaRentanjaId = _RezervacijaID;
            porukaUpsert.DatumVrijeme = DateTime.Now;
            porukaUpsert.UposlenikId = _UposlenikID;
            porukaUpsert.KlijentId = rezervacija.KlijentId;
            porukaUpsert.Procitano = false;
            porukaUpsert.Sadrzaj = rtxtSadrzaj.Text;
            porukaUpsert.Naslov = txtNaslov.Text;
            porukaUpsert.Posiljaoc = "Uposlenik";
            var entity = await _porukaService.Insert<Model.Models.Poruka>(porukaUpsert);
            if(entity != null)
            {
                MessageBox.Show("Poruka je uspješno poslana");
                this.Close();
            }

        }
    }
}
