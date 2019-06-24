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

namespace CarHireRC.WinUI.Home
{
    public partial class frmHome : Form
    {
        private readonly APIService _rezervacijeService = new APIService("RezervacijaRentanja");
        private readonly APIService _vozilaService = new APIService("Automobil");
        private readonly APIService _klijentService = new APIService("Klijent");
        private readonly APIService _korisniciUlogeService = new APIService("KorisniciUloga");

        private bool Admin = false, Menadzer = false, Uposlenik = false;
        private int _userId;
        public frmHome(int UserID,bool ulogaA,bool ulogaM,bool ulogaU)
        {
            _userId = UserID;
            Admin = ulogaA;
            Menadzer = ulogaM;
            Uposlenik = ulogaU;
            InitializeComponent();
        }

        private async void frmHome_Load(object sender, EventArgs e)
        {
            await Inicijaliziraj();
        }

        private async Task Inicijaliziraj()
        {
            string brojVozila, slobodnihVozila, zauzetihVozila;
            string brojRezervacija,  ovogMjesecaR, oveGodineR;
            string ukupnaZarada, ovogMjesecaZ, oveGodineZ;
            string brojKlijenata;

            AutomobilSearchRequest vozilaSearch = new AutomobilSearchRequest()
            {
                Dostupan = true
            };
            var vozilaSlobodna = await _vozilaService.Get<List<Model.Models.Automobil>>(vozilaSearch);
            vozilaSearch.Dostupan = false;
            var vozilaZauzeta = await _vozilaService.Get<List<Model.Models.Automobil>>(vozilaSearch);


            RezervacijaRentanjaSearchRequest rezervacijeSearch = new RezervacijaRentanjaSearchRequest()
            {
                Otkazana = false,
                RezervacijaOd = DateTime.Now
            };
            var rezervacijeUToku = await _rezervacijeService.Get<List<Model.Models.RezervacijaRentanja>>(rezervacijeSearch);
            rezervacijeSearch.RezervacijaDo = DateTime.Now.AddDays(-1);
            rezervacijeSearch.RezervacijaOd = null;
            var rezervacijeZavrsene = await _rezervacijeService.Get<List<Model.Models.RezervacijaRentanja>>(rezervacijeSearch);

            decimal zaradaOvajMjesec = 0, zaradaOveGodine = 0,zarada=0;
            int rezervacijaOvajMjesec = 0, rezervacijaOveGodine = 0;

            foreach (var r in rezervacijeZavrsene)
            {
                //Mjesecna zarada i broj rezervacija
                if (r.RezervacijaOd.Month == DateTime.Now.Month)
                {
                    zaradaOvajMjesec += r.IznosSaPopustom;
                    rezervacijaOvajMjesec += 1;
                }

                //Godisnja zarada i broj rezervacija
                if (r.RezervacijaOd.Year == DateTime.Now.Year)
                {
                    zaradaOveGodine += r.IznosSaPopustom;
                    rezervacijaOveGodine += 1;
                }
                zarada += r.IznosSaPopustom;
            }

            KlijentSearchRequest klijentSearch = new KlijentSearchRequest()
            {
                Status = true
            };
            var klijentiAktivni = await _klijentService.Get<List<Model.Models.Klijent>>(klijentSearch);
            klijentSearch.Status = false;
            var klijentiNeaktivni = await _klijentService.Get<List<Model.Models.Klijent>>(klijentSearch);

            int brKlijenataM = 0, brKlijenataG = 0;

            //Broj klijenata aktivnih mjesečno/godišnje
            foreach (var k in klijentiAktivni)
            {
                //Mjesecna zarada i broj rezervacija
                if (k.DatumRegistracije.Month == DateTime.Now.Month)
                {
                    brKlijenataM ++;
                }
                //Mjesecna zarada i broj rezervacija
                if (k.DatumRegistracije.Year == DateTime.Now.Year)
                {
                    brKlijenataG++;
                }
              
            }

            //Broj klijenata nekativnih mjesečno/godišnje
            foreach (var k in klijentiNeaktivni)
            {
                
                if (k.DatumRegistracije.Month == DateTime.Now.Month)
                {
                    brKlijenataM++;
                }
                if (k.DatumRegistracije.Year == DateTime.Now.Year)
                {
                    brKlijenataG++;
                }

            }


            brojVozila = (vozilaSlobodna.Count + vozilaZauzeta.Count).ToString();
            zauzetihVozila = vozilaZauzeta.Count.ToString();
            slobodnihVozila = vozilaSlobodna.Count.ToString();

            brojKlijenata = (klijentiAktivni.Count + klijentiNeaktivni.Count).ToString();

            ukupnaZarada = (zaradaOvajMjesec + zaradaOveGodine).ToString();
            ovogMjesecaZ = zaradaOvajMjesec.ToString();
            oveGodineZ = zaradaOveGodine.ToString();

            brojRezervacija = (rezervacijeUToku.Count + rezervacijeZavrsene.Count).ToString();
            ovogMjesecaR = rezervacijaOvajMjesec.ToString();
            oveGodineR = rezervacijaOveGodine.ToString();


            #region label initialization

            lblBrojKlijenata.Text = brojKlijenata;
            lblBrKlijenataGodina.Text = brKlijenataG.ToString();
            lblBrKlijenataMjesec.Text = brKlijenataM.ToString();

            lblBrojRezervacija.Text = brojRezervacija;
            lblBrojRezervacijaGodina.Text = oveGodineR;
            lblBrojRezervacijaMjesec.Text = ovogMjesecaR;


            lblUkupnaZarada.Text = ukupnaZarada + " KM";
            lblZaradaGodisnja.Text = oveGodineZ + " KM";
            if (zarada > 0 && rezervacijeZavrsene.Count > 0)
            {
                string p = (zarada / rezervacijeZavrsene.Count).ToString();
                int zarez = p.IndexOf(",");
                string subp = p.Remove(zarez + 3, p.Length - zarez - 3);
                lblProsjekRezervacija.Text = subp + " KM";
            }
            else
                lblProsjekRezervacija.Text = "0 KM";
            lblBrojVozila.Text = brojVozila;
            lblZauzetihVozila.Text = zauzetihVozila;
            lblSlobodnihVozila.Text = slobodnihVozila;
            #endregion


            if (!Admin && !Menadzer && Uposlenik)
            {
                lblUkupnaZarada.Text = "";
                lblZaradaGodisnja.Text = "";
                lblProsjekRezervacija.Text = "";
                lblUkupnaZarada.Visible = false;
                lblZaradaGodisnja.Visible = false;
                lblProsjekRezervacija.Visible = false;
            }

            if(Admin || Menadzer)
            {
                pnlzaradaGodisnja.Visible = true;
                pnlzaradaProsjecna.Visible = true;
                pnlzaradaUkupna.Visible = true;
            }
        }

        
    }
}
