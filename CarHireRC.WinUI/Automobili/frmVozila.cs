using CarHireRC.Model.Models;
using CarHireRC.Model.Requests;
using CarHireRC.WinUI.Helper;
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

namespace CarHireRC.WinUI.Automobili
{
    public partial class frmVozila : Form
    {
        private readonly APIService _automobiliService = new APIService("Automobil");
        private readonly APIService _modeliService = new APIService("Model");
        private readonly APIService _proizvodjaciService = new APIService("Proizvodjac");
        private readonly APIService _kategorijaService = new APIService("KategorijaVozila");
        private readonly APIService _klijentService = new APIService("Klijent");
        private readonly APIService _porukaService = new APIService("Poruka");
        private readonly APIService _drzavaService = new APIService("Drzava");
        private readonly APIService _registracijaVozilaService = new APIService("RegistracijaVozila");
        private readonly APIService _RezervacijaVozilaService = new APIService("RezervacijaRentanja");
        private readonly APIService _korisniciUlogeService = new APIService("KorisniciUloga");

        RegistracijaVozilaUpsertRequest RegistracijaRequest = new RegistracijaVozilaUpsertRequest();
        RegistracijaVozila posljednjaRegistracija;
        AutomobiliUPSERTtRequest NovoVoziloRequest = new AutomobiliUPSERTtRequest();
        AutomobiliUPSERTtRequest IzmjenaVoziloRequest = new AutomobiliUPSERTtRequest();
        ProizvodjacUpsertRequest proizvodjacUpsert = new ProizvodjacUpsertRequest();
        ModelAutomobilaUpsertRequest modelUpsert = new ModelAutomobilaUpsertRequest();


        private int _VoziloId, _userId, pId,mId,kId;
        private bool ulogaAdmin = false, ulogaMenadzer = false, ulogaUposlenik = false;
        public frmVozila(int UserID, bool ulogaA, bool ulogaM, bool ulogaU)
        {
            _userId = UserID;
            ulogaAdmin = ulogaA;
            ulogaMenadzer = ulogaM;
            ulogaUposlenik = ulogaU;
            InitializeComponent();
        }

        private async void frmVozila_Load(object sender, EventArgs e)
        {
            
            //Uklanjanje tab page-ova koji se neće prikazivati po defaultu
            metroTabControl1.HideTab(metroTabPage3);
            metroTabControl1.HideTab(metroTabPage4);
            metroTabControl1.HideTab(metroTabPage5);
            metroTabControl1.HideTab(metroTabPage6);
            metroTabControl1.SelectedTab = metroTabPage1;

            //Ako je ima samo ulogu menadžera ne može dodavati nova vozila
            //niti evidentirati registraciju vozila
            if (ulogaMenadzer && !ulogaUposlenik && !ulogaAdmin)
            {
                metroTabControl1.HideTab(metroTabPage2);
                btnRegistrujVozilo.Enabled = false;
                btnRegistrujVozilo.Visible = false;
            }

            //Učitavanje vrijednosti u combobox-ove
            await LoadSearchModelVozila(null);
            await LoadSearchProizvodjacVozila();
            await LoadSearchKategorijaVozila();

            await LoadProizvodjacVozila();
            await LoadKategorijaVozila();
            await LoadModelVozila(null);
            await LoadDrzava();
            await LoadProizvodjacNoviModel();


        }

        //Pretraga vozila
        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            await PretragaVozila();
        }

        private async Task PretragaVozila()
        {
            var search = new AutomobilSearchRequest();
            var ModelidObj = cmbSearchModel.SelectedValue;
            var ProizvodjaciObj = cmbSearchProizvodjac.SelectedValue;
            var KategorijeObj = cmbSearchKategorija.SelectedValue;

            if (int.TryParse(ModelidObj.ToString(), out int ModelId))
            {
                search.ModelId = ModelId;
            }
            if (int.TryParse(ProizvodjaciObj.ToString(), out int ProizvodjacId))
            {
                search.ProizvodjacId = ProizvodjacId;
            }
            if (int.TryParse(KategorijeObj.ToString(), out int KategorijaId))
            {
                search.KategorijaId = KategorijaId;
            }
            if (int.TryParse(txtGodina.Text, out int GodinaProizvodnje))
            {
                search.GodinaProizvodnje = GodinaProizvodnje;
            }
            if (txtRegOznaka.Text != "")
            {
                search.RegistarskaOznaka = txtRegOznaka.Text.ToLower();
            }
            search.Dostupan = cbDostupnaVozila.Checked;

            var result = await _automobiliService.Get<List<Model.Models.Automobil>>(search);
            dgvAutomobili.AutoGenerateColumns = false;
            dgvAutomobili.DataSource = result;


        }

        //Registracija vozila 
        private async void btnRegistrujVozilo_Click(object sender, EventArgs e)
        {
            int Id = 0;
            if (dgvAutomobili.RowCount > 0)
            {
                var val = dgvAutomobili.SelectedRows[0].Cells[0].Value;
                Id = int.Parse(val.ToString());
            }
            if (_VoziloId <= 0 && Id > 0)
            {
                _VoziloId = Id;
                await UcitajRegistracijaTab();

                metroTabControl1.ShowTab(metroTabPage3);
                metroTabControl1.SelectedTab = metroTabPage3;
            }
        }

        //Ucitavanje tab page-a za dodavanje registracije vozila
        private async Task UcitajRegistracijaTab()
        {
            if (_VoziloId != 0)
            {
                var vozilo = await _automobiliService.GetById<Model.Models.Automobil>(_VoziloId);
                var modelVozila = await _modeliService.GetById<Model.Models.ModelAutomobila>(vozilo.ModelId);
                var kategorija = await _kategorijaService.GetById<Model.Models.KategorijaVozila>(vozilo.KategorijaId);
                var proizvodjac = await _proizvodjaciService.GetById<Model.Models.Proizvodjac>(modelVozila.ProizvodjacId);

                RegistracijaVozilaSearchRequest searchRequest = new RegistracijaVozilaSearchRequest();
                searchRequest.AutomobilId = _VoziloId;
                searchRequest.Status = true;

                var registracije = await _registracijaVozilaService.Get<List<Model.Models.RegistracijaVozila>>(searchRequest);

                if (registracije != null)
                    posljednjaRegistracija = registracije.FirstOrDefault();

                NovoVoziloRequest.AutomobilId = vozilo.AutomobilId;

                if (vozilo.Slika != null)
                {
                    byte[] slika = vozilo.Slika;
                    MemoryStream memoryStream = new MemoryStream(slika);
                    pictureBox2.Image = Image.FromStream(memoryStream);
                }

                txtKubikazaRegistracija.Text = vozilo.Kubikaza;
                txtGodinaPRegistracija.Text = vozilo.GodinaProizvodnje.ToString();
                if (posljednjaRegistracija != null)
                {
                    txtStareRegistarskeOznake.Text = posljednjaRegistracija.RegistarskeOznake;
                    dtpVaziDo.Value = posljednjaRegistracija.VaziDo;
                }
                else
                    txtStareRegistarskeOznake.Text = "Vozilo nije registrovano";

                txtModel.Text = modelVozila.Naziv;
                txtProizvodjac.Text = proizvodjac.Naziv;
                txtKategorijaVozila.Text = kategorija.Naziv;
                txtTransmisija.Text = vozilo.Transmisija;
                dtpDatumRegistracije.MaxDate = DateTime.Now.Date;
                dtpDatumRegistracije.Value = DateTime.Now.Date;

            }
        }

        //Dodavanje registracije vozila
        private async void btnSacuvajRegistraciju_Click(object sender, EventArgs e)
        {
            bool provjera = this.ValidateChildren();
            string error1 = errorProvider.GetError(txtIznos);
            string error2 = errorProvider.GetError(cmbTrajanjeRegistracije);
            string error3 = errorProvider.GetError(txtRegistarskeOznake);

            if (string.IsNullOrEmpty(error1) && string.IsNullOrEmpty(error2) && string.IsNullOrEmpty(error3))
                provjera = true;

            if (provjera)
            {
                RegistracijaRequest.DatumRegistracije = dtpDatumRegistracije.Value;
                RegistracijaRequest.AutomobilId = _VoziloId;
                RegistracijaRequest.UposlenikId = _userId;
                RegistracijaRequest.Status = true;
                RegistracijaRequest.RegistarskeOznake = txtRegistarskeOznake.Text;

                if (decimal.TryParse(txtIznos.Text, out decimal iznos))
                {
                    RegistracijaRequest.UkupanIznos = iznos;
                }

                var t = cmbTrajanjeRegistracije.SelectedItem.ToString();

                string trajanjeRegistracije = t.ToString();

                RegistracijaRequest.Trajanje = trajanjeRegistracije;

                if (RegistracijaRequest.Trajanje == "mjesec dana")
                {
                    var vazi = RegistracijaRequest.DatumRegistracije;
                    RegistracijaRequest.VaziDo = vazi.AddMonths(1);
                }
                if (RegistracijaRequest.Trajanje == "šest mjeseci")
                {
                    var vazi = RegistracijaRequest.DatumRegistracije;
                    RegistracijaRequest.VaziDo = vazi.AddMonths(6);
                }
                if (RegistracijaRequest.Trajanje == "godina dana")
                {
                    var vazi = RegistracijaRequest.DatumRegistracije;
                    RegistracijaRequest.VaziDo = vazi.AddYears(1);
                }
                if (RegistracijaRequest.Trajanje == "dvije godine")
                {
                    var vazi = RegistracijaRequest.DatumRegistracije;
                    RegistracijaRequest.VaziDo = vazi.AddYears(2);
                }

                //Ako vozilo ima prethodnu registraciju potrebno je deaktivirati
                if (posljednjaRegistracija != null)
                {
                    RegistracijaVozilaUpsertRequest prethodnaRegistracijaRequest = new RegistracijaVozilaUpsertRequest();
                    prethodnaRegistracijaRequest.RegistracijaVozilaId = posljednjaRegistracija.RegistracijaVozilaId;
                    prethodnaRegistracijaRequest.Status = false;
                    prethodnaRegistracijaRequest.DatumRegistracije = posljednjaRegistracija.DatumRegistracije;
                    prethodnaRegistracijaRequest.VaziDo = posljednjaRegistracija.VaziDo;
                    prethodnaRegistracijaRequest.UposlenikId = posljednjaRegistracija.UposlenikId;
                    prethodnaRegistracijaRequest.AutomobilId = posljednjaRegistracija.AutomobilId;
                    prethodnaRegistracijaRequest.UkupanIznos = posljednjaRegistracija.UkupanIznos;
                    prethodnaRegistracijaRequest.RegistarskeOznake = posljednjaRegistracija.RegistarskeOznake;
                    prethodnaRegistracijaRequest.Trajanje = posljednjaRegistracija.Trajanje;
                    var entity = await _registracijaVozilaService.Update<Model.Models.RegistracijaVozila>(posljednjaRegistracija.RegistracijaVozilaId, prethodnaRegistracijaRequest);
                    if (entity != null)
                    {
                        MessageBox.Show("Registracija vozila evidentirana");
                        await UpdateStatusVozila(_VoziloId);
                        _VoziloId = 0;
                        metroTabControl1.SelectedTab = metroTabPage1;

                        metroTabControl1.HideTab(metroTabPage3);
                        cmbTrajanjeRegistracije.SelectedIndex = -1;
                        txtIznos.Text = "";
                        txtRegistarskeOznake.Text = "";
                        await PretragaVozila();
                    }
                }

                //Ako nema prethodne registracije
                else
                {
                    var entity = await _registracijaVozilaService.Insert<Model.Models.RegistracijaVozila>(RegistracijaRequest);
                    if (entity != null)
                    {
                        MessageBox.Show("Registracija vozila evidentirana");
                        await UpdateStatusVozila(_VoziloId);
                        _VoziloId = 0;
                        metroTabControl1.SelectedTab = metroTabPage1;

                        metroTabControl1.HideTab(metroTabPage3);
                        cmbTrajanjeRegistracije.SelectedIndex = -1;
                        txtIznos.Text = "";
                        txtRegistarskeOznake.Text = "";
                        await PretragaVozila();
                    }
                }


            }
        }


        //Dodavanje novog vozila
        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            bool provjera = this.ValidateChildren();
            if (provjera)
            {
                NovoVoziloRequest.Boja = txtBoja.Text;
                NovoVoziloRequest.Novo = chBoxNovo.Checked;

                //Po defaultu nije dostupan jer je potrebno evidentirati registraciju vozila
                NovoVoziloRequest.Dostupan = false;

                NovoVoziloRequest.SnagaMotora = txtSnagaMotora.Text;
                NovoVoziloRequest.GodinaProizvodnje = int.Parse(txtGodinaProizvodnje.Text.ToString());
                NovoVoziloRequest.BrojSjedista = txtBrojSjedista.Text;
                NovoVoziloRequest.Potrosnja = txtProsjecnaPotrosnja.Text;
                NovoVoziloRequest.Kubikaza = txtKubikaza.Text;
                NovoVoziloRequest.CijenaIznajmljivanja = decimal.Parse(txtCijenaIznajmljivanja.Text);
                NovoVoziloRequest.CijenaKaskoOsiguranja = decimal.Parse(txtCijenaOsiguranja.Text);

                //Ako nije odabrao sliku vozila
                if (NovoVoziloRequest.Slika == null)
                {
                    var filename = Properties.Resources.noImage;

                    MemoryStream ms = new MemoryStream();
                    filename.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                    Image x = (Bitmap)((new ImageConverter()).ConvertFrom(ms.ToArray()));
                    Image thumb = x.GetThumbnailImage(75, 75, () => false, IntPtr.Zero);

                    ImageConverter _imageConverter = new ImageConverter();
                    byte[] imagethumbbyte = (byte[])_imageConverter.ConvertTo(thumb, typeof(byte[]));

                    NovoVoziloRequest.Slika = ms.ToArray();
                    NovoVoziloRequest.SlikaThumb = imagethumbbyte;
                }


                if (cmbBrojVrata.SelectedItem != null)
                    NovoVoziloRequest.BrojVrata = cmbBrojVrata.SelectedItem.ToString();
                if (cmbGorivo.SelectedItem != null)
                    NovoVoziloRequest.Gorivo = cmbGorivo.SelectedItem.ToString();
                if (cmbEmisioniStandard.SelectedItem != null)
                    NovoVoziloRequest.EmisioniStandard = cmbEmisioniStandard.SelectedItem.ToString();
                if (cmbTransmisija.SelectedItem != null)
                    NovoVoziloRequest.Transmisija = cmbTransmisija.SelectedItem.ToString();

                var ModelidObj = cmbModel.SelectedValue;
                if (int.TryParse(ModelidObj.ToString(), out int ModelId))
                {
                    NovoVoziloRequest.ModelId = ModelId;
                }

                var KategorijaObj = cmbKategorija.SelectedValue;
                if (int.TryParse(KategorijaObj.ToString(), out int KategorijaID))
                {
                    NovoVoziloRequest.KategorijaId = KategorijaID;
                }

                var entity = await _automobiliService.Insert<Model.Models.Automobil>(NovoVoziloRequest);
                if (entity != null)
                {
                    MessageBox.Show("Uspješno dodano novo vozilo");
                    //Čišćenje forme
                    txtBoja.Clear();
                    txtSnagaMotora.Clear();
                    txtBrojSjedista.Clear();
                    txtKubikaza.Clear();
                    txtProsjecnaPotrosnja.Clear();
                    txtGodinaProizvodnje.Clear();
                    cmbEmisioniStandard.SelectedIndex = -1;
                    cmbProizvodjac.SelectedIndex = -1;
                    cmbKategorija.SelectedIndex = -1;
                    cmbModel.SelectedIndex = -1;
                    cmbGorivo.SelectedIndex = -1;
                    cmbTransmisija.SelectedIndex = -1;
                    cmbBrojVrata.SelectedIndex = -1;
                    chBoxNovo.Checked = false;
                    metroTabControl1.SelectedTab = metroTabPage1;

                    //Postavljanje defaultne slike u picturebox
                    var filename = Properties.Resources.noImage;
                    MemoryStream ms = new MemoryStream();
                    filename.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    Image image = Image.FromStream(ms);
                    pictureBox1.Image = image;
                }

            }
        }

      

        //Izmjena dostupnosti vozila
        private async Task UpdateStatusVozila(int voziloId)
        {
            var vozilo = await _automobiliService.GetById<Model.Models.Automobil>(voziloId);

            AutomobiliUPSERTtRequest automobilirequest = new AutomobiliUPSERTtRequest
            {
                AutomobilId = voziloId,
                Boja = vozilo.Boja,
                BrojSjedista = vozilo.BrojSjedista,
                BrojVrata = vozilo.BrojVrata,
                Dostupan = true,

                EmisioniStandard = vozilo.EmisioniStandard,
                GodinaProizvodnje = vozilo.GodinaProizvodnje,
                Gorivo = vozilo.Gorivo,
                KategorijaId = vozilo.KategorijaId,
                Kubikaza = vozilo.Kubikaza,
                ModelId = vozilo.ModelId,
                Novo = vozilo.Novo,
                Potrosnja = vozilo.Potrosnja,
                SnagaMotora = vozilo.SnagaMotora,
                Transmisija = vozilo.Transmisija,
                Slika = vozilo.Slika,
                SlikaThumb = vozilo.SlikaThumb,
            };

            await _automobiliService.Update<Model.Models.Automobil>(voziloId, automobilirequest);

        }

      

        //Dvoklik na vozilo sa liste
        private async void dgvAutomobili_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ulogaAdmin || ulogaUposlenik)
            {

                int Id = 0;
                if (dgvAutomobili.RowCount > 0)
                {
                    var val = dgvAutomobili.SelectedRows[0].Cells[0].Value;
                    Id = int.Parse(val.ToString());
                }
                if (_VoziloId <= 0 && Id > 0)
                {
                    _VoziloId = Id;

                    //Učitavanje Edit Tab Page-a
                    //promjena trenutnog Tab-a
                    metroTabControl1.ShowTab(metroTabPage4);
                    await UcitajEditTab();
                    metroTabControl1.SelectedTab = metroTabPage4;
                }
            }
        }

        //Učitavanje Edit Tab Page-a
        private async Task UcitajEditTab()
        {
            var vozilo = await _automobiliService.GetById<Model.Models.Automobil>(_VoziloId);
            var modelVozila = await _modeliService.GetById<Model.Models.ModelAutomobila>(vozilo.ModelId);
            var kategorija = await _kategorijaService.GetById<Model.Models.KategorijaVozila>(vozilo.KategorijaId);
            var proizvodjac = await _proizvodjaciService.GetById<Model.Models.Proizvodjac>(modelVozila.ProizvodjacId);

            await LoadProizvodjacEditVozila();
            await LoadKategorijaEditVozila();
            await LoadModelEditVozila(modelVozila.ProizvodjacId);


            IzmjenaVoziloRequest.Boja = vozilo.Boja;
            IzmjenaVoziloRequest.BrojSjedista = vozilo.BrojSjedista;
            IzmjenaVoziloRequest.GodinaProizvodnje = vozilo.GodinaProizvodnje;
            IzmjenaVoziloRequest.Kubikaza = vozilo.Kubikaza;
            IzmjenaVoziloRequest.Potrosnja = vozilo.Potrosnja;
            IzmjenaVoziloRequest.SnagaMotora = vozilo.SnagaMotora;
            IzmjenaVoziloRequest.EmisioniStandard = vozilo.EmisioniStandard;
            IzmjenaVoziloRequest.ModelId = vozilo.ModelId;
            IzmjenaVoziloRequest.KategorijaId = vozilo.KategorijaId;
            IzmjenaVoziloRequest.Gorivo = vozilo.Gorivo;
            IzmjenaVoziloRequest.BrojVrata = vozilo.BrojVrata;
            IzmjenaVoziloRequest.Dostupan = vozilo.Dostupan;
            IzmjenaVoziloRequest.Novo = vozilo.Novo;
            IzmjenaVoziloRequest.Transmisija = vozilo.Transmisija;
            IzmjenaVoziloRequest.CijenaIznajmljivanja = vozilo.CijenaIznajmljivanja;
            IzmjenaVoziloRequest.CijenaKaskoOsiguranja = vozilo.CijenaKaskoOsiguranja;

            if (vozilo.Slika != null)
            {
                IzmjenaVoziloRequest.Slika = vozilo.Slika;
                IzmjenaVoziloRequest.SlikaThumb = vozilo.SlikaThumb;
                byte[] slika = vozilo.Slika;

                MemoryStream memoryStream = new MemoryStream(slika);
                pictureBox3.Image = Image.FromStream(memoryStream);
            }


            txtBojaEdit.Text = vozilo.Boja;
            txtBrojSjedistaEdit.Text = vozilo.BrojSjedista;
            txtGPEdit.Text = vozilo.GodinaProizvodnje.ToString();
            txtKubikazaEdit.Text = vozilo.Kubikaza;
            txtCijenaIznajmljivanjaEdit.Text = vozilo.CijenaIznajmljivanja.ToString();
            txtCijenaOsiguranjaEdit.Text = vozilo.CijenaKaskoOsiguranja.ToString();
            txtPotrosnjaEdit.Text = vozilo.Potrosnja;
            txtSnagaEdit.Text = vozilo.SnagaMotora;
            cmbBrojVrataEdit.SelectedItem = vozilo.BrojVrata;


            cmbProizvodjacEdit.SelectedIndex = cmbProizvodjacEdit.FindString(proizvodjac.Naziv);

            cmbModelEdit.SelectedIndex = cmbModelEdit.FindString(modelVozila.Naziv);
            cmbKategorijaEdit.SelectedIndex = cmbKategorijaEdit.FindString(kategorija.Naziv);

            pId = cmbProizvodjacEdit.FindString(proizvodjac.Naziv);
            mId = cmbModelEdit.FindString(modelVozila.Naziv);
            kId = cmbKategorijaEdit.FindString(kategorija.Naziv);

            cmbTransmisijaEdit.SelectedIndex = cmbTransmisijaEdit.FindString(vozilo.Transmisija);
            cmbGorivoEdit.SelectedIndex = cmbGorivoEdit.FindString(vozilo.Gorivo);
            cmbESEdit.SelectedIndex = cmbESEdit.FindString(vozilo.EmisioniStandard);
            cbNovoEdit.Checked = vozilo.Novo;
            cbDostupanEdit.Checked = vozilo.Dostupan;
        }


        //Spremanje izmjena podataka o vozilu
        private async void btnSacuvajEdit_Click(object sender, EventArgs e)
        {
            bool provjera = this.ValidateChildren();

            //provjera unosa
            provjera = ProvjeraUnosa();
            if (provjera)
            {

                IzmjenaVoziloRequest.AutomobilId = _VoziloId;
                IzmjenaVoziloRequest.Boja = txtBojaEdit.Text;
                IzmjenaVoziloRequest.Novo = cbNovoEdit.Checked;

                //Pretraga posljednje registracije vozila
                RegistracijaVozilaSearchRequest r = new RegistracijaVozilaSearchRequest
                {
                    AutomobilId = _VoziloId,
                    Status = true
                };
                var registrovan = await _registracijaVozilaService.Get<List<RegistracijaVozila>>(r);

                //Ako je vozilo registrovano promjena statusa na odabrani 
                //slanje obavijesti klijentu ako je nedostupno vozilo
                if (registrovan.Count > 0)
                {
                    IzmjenaVoziloRequest.Dostupan = cbDostupanEdit.Checked;
                    if (!cbDostupanEdit.Checked)
                    {
                        //broj dana za koje ce vozilo biti nedostupno
                        int brojDana = 0;
                        if (!cbNedostupanDoDaljnjeg.Checked)
                        {
                            brojDana = int.Parse(txtNedostupanBrDana.Text.ToString());
                        }

                        //slanje obavijesti klijentu 
                        //otkazivanje ako ima rezervacija koje počinju u vremenu nedostupnosti vozila
                        await PosaljiObavijestKlijentu(_VoziloId, brojDana);
                    }
                }
                //ako vozilo nema registraciju da ne učitava uopšte vrijednost sa checkbox-a za dostupnost vozila
                else
                {
                    IzmjenaVoziloRequest.Dostupan = false;
                }

                IzmjenaVoziloRequest.SnagaMotora = txtSnagaEdit.Text;
                IzmjenaVoziloRequest.GodinaProizvodnje = int.Parse(txtGPEdit.Text.ToString());
                IzmjenaVoziloRequest.BrojSjedista = txtBrojSjedistaEdit.Text;
                IzmjenaVoziloRequest.Potrosnja = txtPotrosnjaEdit.Text;
                IzmjenaVoziloRequest.Kubikaza = txtKubikazaEdit.Text;
                IzmjenaVoziloRequest.CijenaIznajmljivanja = decimal.Parse(txtCijenaIznajmljivanjaEdit.Text);
                IzmjenaVoziloRequest.CijenaKaskoOsiguranja = decimal.Parse(txtCijenaOsiguranjaEdit.Text);

                if (cmbBrojVrataEdit.SelectedItem != null)
                    IzmjenaVoziloRequest.BrojVrata = cmbBrojVrataEdit.SelectedItem.ToString();
                if (cmbGorivoEdit.SelectedItem != null)
                    IzmjenaVoziloRequest.Gorivo = cmbGorivoEdit.SelectedItem.ToString();
                if (cmbESEdit.SelectedItem != null)
                    IzmjenaVoziloRequest.EmisioniStandard = cmbESEdit.SelectedItem.ToString();
                if (cmbTransmisijaEdit.SelectedItem != null)
                    IzmjenaVoziloRequest.Transmisija = cmbTransmisijaEdit.SelectedItem.ToString();

                var ModelidObj = cmbModelEdit.SelectedValue;
                if (int.TryParse(ModelidObj.ToString(), out int ModelId))
                {
                    IzmjenaVoziloRequest.ModelId = ModelId;
                }

                var KategorijaObj = cmbKategorijaEdit.SelectedValue;
                if (int.TryParse(KategorijaObj.ToString(), out int KategorijaID))
                {
                    IzmjenaVoziloRequest.KategorijaId = KategorijaID;
                }

                var entity = await _automobiliService.Update<Model.Models.Automobil>(_VoziloId, IzmjenaVoziloRequest);

                //ako je izmjena uspješno izvršena
                if (entity != null)
                {
                    MessageBox.Show("Uspješno izmjenjeni podaci o vozilu");

                    _VoziloId = 0;

                    //promjena Tab page-async forme 
                    //skrivanje Tab-async za uređivanje
                    metroTabControl1.SelectedTab = metroTabPage1;
                    metroTabControl1.HideTab(metroTabPage4);

                    await PretragaVozila();

                    //čišćenje forme za uređivanje
                    txtBojaEdit.Clear();
                    txtSnagaEdit.Clear();
                    txtBrojSjedistaEdit.Clear();
                    txtKubikazaEdit.Clear();
                    txtPotrosnjaEdit.Clear();
                    txtGPEdit.Clear();
                    cmbESEdit.SelectedIndex = -1;
                    cmbProizvodjacEdit.SelectedIndex = -1;
                    cmbKategorijaEdit.SelectedIndex = -1;
                    cmbModelEdit.SelectedIndex = -1;
                    cmbGorivoEdit.SelectedIndex = -1;
                    cmbTransmisijaEdit.SelectedIndex = -1;
                    cmbBrojVrataEdit.SelectedIndex = -1;
                    cbDostupanEdit.Checked = false;
                    cbNovoEdit.Checked = false;

                    //Postavljanje defaultne slike u picturebox
                    var filename = Properties.Resources.noImage;
                    MemoryStream ms = new MemoryStream();
                    filename.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    Image image = Image.FromStream(ms);
                    pictureBox3.Image = image;
                }
            }
        }



        //Dodavanje novog modela automobila
        private async void btnSacuvajNoviModel_Click(object sender, EventArgs e)
        {
            bool provjera = this.ValidateChildren();

            string error1 = errorProvider1.GetError(txtNazivModelaNovi);
            string error2 = errorProvider1.GetError(cmbProizvodjacModelNovi);
            if (string.IsNullOrEmpty(error1) && string.IsNullOrEmpty(error2))
                provjera = true;

            if (provjera)
            {
                modelUpsert.Naziv = txtNazivModelaNovi.Text;

                var proizvodjacObj = cmbProizvodjacModelNovi.SelectedValue;
                if (int.TryParse(proizvodjacObj.ToString(), out int ProizvodjacId))
                {
                    modelUpsert.ProizvodjacId = ProizvodjacId;
                }


                var entity = await _modeliService.Insert<Model.Models.ModelAutomobila>(modelUpsert);
                if (entity != null)
                {
                    MessageBox.Show("Uspješno dodan model");

                    //Select-ovanje trenutnog tab page-a i uklanjanje

                    metroTabControl1.SelectedTab = metroTabPage2;
                    metroTabControl1.HideTab(metroTabPage6);
                    var p = await _proizvodjaciService.GetById<Model.Models.Proizvodjac>(entity.ProizvodjacId);
                    var pObj = cmbProizvodjac.SelectedValue;
                    if (int.TryParse(pObj.ToString(), out int PId))
                    {
                        await LoadModelVozila(PId);

                    }
                    cmbProizvodjac.SelectedIndex = cmbProizvodjac.FindString(p.Naziv);
                    cmbModel.SelectedIndex = cmbModel.FindString(entity.Naziv);

                    cmbDrzavaProizvodjaca.SelectedIndex = -1;
                    txtNazivModelaNovi.Clear();

                }
            }
        }

        //Dodavanje novog proizvođača
        private async void btnNoviProizvodjac_Click(object sender, EventArgs e)
        {
            bool provjera = this.ValidateChildren();

            string error1 = errorProvider1.GetError(txtNazivProizvodjaca);
            string error2 = errorProvider1.GetError(cmbDrzavaProizvodjaca);
            if (string.IsNullOrEmpty(error1) && string.IsNullOrEmpty(error2))
                provjera = true;

            if (provjera)
            {
                proizvodjacUpsert.Naziv = txtNazivProizvodjaca.Text;

                var drzavaObj = cmbDrzavaProizvodjaca.SelectedValue;
                if (int.TryParse(drzavaObj.ToString(), out int DrzavaId))
                {
                    proizvodjacUpsert.DrzavaId = DrzavaId;
                }

                //Ako nije odabrao sliku vozila
                if (proizvodjacUpsert.Slika == null)
                {
                    var filename = Properties.Resources.noImage;

                    MemoryStream ms = new MemoryStream();
                    filename.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                    proizvodjacUpsert.Slika = ms.ToArray();
                }

                var entity = await _proizvodjaciService.Insert<Model.Models.Proizvodjac>(proizvodjacUpsert);
                if (entity != null)
                {
                    MessageBox.Show("Uspješno dodan proizvođač");

                    metroTabControl1.SelectedTab = metroTabPage2;
                    metroTabControl1.HideTab(metroTabPage5);

                    await LoadProizvodjacVozila();
                    cmbProizvodjac.SelectedIndex = cmbProizvodjac.FindString(entity.Naziv);

                    cmbDrzavaProizvodjaca.SelectedIndex = -1;
                    txtNazivProizvodjaca.Clear();
                    //Postavljanje defaultne slike u picturebox
                    var filename = Properties.Resources.noImage;
                    MemoryStream ms = new MemoryStream();
                    filename.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    Image image = Image.FromStream(ms);
                    pictureBox4.Image = image;
                }


            }


        }


        #region Managing reservations
        private async Task PosaljiObavijestKlijentu(int VID, int brDanaNedostupnosti)
        {
            //Samo rezervacije koje nisu otkazane
            RezervacijaRentanjaSearchRequest rezervacijaRentanjaSearch = new RezervacijaRentanjaSearchRequest
            {
                AutomobilId = VID,
                RezervacijaOd = DateTime.Now,
                Otkazana = false
            };

            if (brDanaNedostupnosti > 0)
                rezervacijaRentanjaSearch.RezervacijaDo = DateTime.Now.AddDays(brDanaNedostupnosti);

            List<Model.Models.RezervacijaRentanja> rezervacije = await _RezervacijaVozilaService.Get<List<Model.Models.RezervacijaRentanja>>(rezervacijaRentanjaSearch);

            foreach (var item in rezervacije)
            {
                //Otkazivanje rezervacije koja je aktivna
                await OtkaziRezervaciju(item);

                //Slanje obavijesti klijentu za rezervaciju koja ce se otkazati
                await ObavijestiKlijenta(item.RezervacijaRentanjaId, item.KlijentId, _userId);
            }


        }

        //Otkazivanje proslijeđene rezervacije
        private async Task OtkaziRezervaciju(RezervacijaRentanja item)
        {

            RezervacijaRentanjaUpsertRequest rezervacijaRentanja = new RezervacijaRentanjaUpsertRequest()
            {
                RezervacijaRentanjaId = item.RezervacijaRentanjaId,
                AutomobilId = item.AutomobilId,
                DatumKreiranja = item.DatumKreiranja,
                Iznos = item.Iznos,
                IznosSaPopustom = item.IznosSaPopustom,
                KaskoOsiguranje = item.KaskoOsiguranje,
                KlijentId = item.KlijentId,
                LokacijaPreuzimanja = item.LokacijaPreuzimanja,
                Opis = item.Opis,
                Otkazana = true,
                Popust = item.Popust,
                RacunId = item.RacunId,
                RezervacijaDo = item.RezervacijaDo,
                RezervacijaOd = item.RezervacijaOd,
                VracanjeUposlovnicu = item.VracanjeUposlovnicu
                
            };
             await _RezervacijaVozilaService.Update<Model.Models.RezervacijaRentanja>(item.RezervacijaRentanjaId, rezervacijaRentanja);
         
        }

        //Slanje poruke klijentu sa otkazane rezervacije
        private async Task ObavijestiKlijenta(int rezervacijaRentanjaId, int klijentId, int userId)
        {
            KlijentSearchRequest klijentSearch = new KlijentSearchRequest()
            {
                KlijentId=klijentId
            };
            var klijenti = await _klijentService.Get<List<Model.Models.Klijent>>(klijentSearch);
            
            var klijent = klijenti.First();

            PorukaUpsertRequest porukaUpsert = new PorukaUpsertRequest
            {
                RezervacijaRentanjaId = rezervacijaRentanjaId,
                KlijentId = klijentId,
                UposlenikId = userId,
                DatumVrijeme = DateTime.Now,
                Naslov = Properties.Resources.NaslovPorukeNedostupnoVozilo,
                Procitano = false,
                Posiljaoc = "Uposlenik",
                Sadrzaj = Properties.Resources.SadrzajPorukeNedostupnoVoziloPozdrav
                        + " " + klijent.Ime + " " + klijent.Prezime + " ! \n"
                        + Properties.Resources.SadrzajPorukeNedostupnoVozilo

            };
            await _porukaService.Insert<Model.Models.Poruka>(porukaUpsert);
        }

        #endregion


        #region Picture loading
        //Dodavanje slike za novog proizvodjača
        private void metroButton3_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                var filename = openFileDialog1.FileName;
                var file = File.ReadAllBytes(filename);
                Image image = Image.FromFile(filename);

                proizvodjacUpsert.Slika = file;
                pictureBox1.Image = image;
            }
        }

        //Dodavanje slike na uređivanju podataka o vozilu
        private void metroButton2_Click(object sender, EventArgs e)
        {
            var result = openFileDialog2.ShowDialog();

            if (result == DialogResult.OK)
            {
                var filename = openFileDialog2.FileName;

                var file = File.ReadAllBytes(filename);

                Image image = Image.FromFile(filename);
                Image thumb = image.GetThumbnailImage(75, 75, () => false, IntPtr.Zero);

                ImageConverter _imageConverter = new ImageConverter();
                byte[] imagethumbbyte = (byte[])_imageConverter.ConvertTo(thumb, typeof(byte[]));

                IzmjenaVoziloRequest.Slika = file;
                IzmjenaVoziloRequest.SlikaThumb = imagethumbbyte;
                pictureBox3.Image = image;
            }
        }

        //Dodavanje slike za novo vozilo
        private void metroButton1_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                var filename = openFileDialog1.FileName;

                var file = File.ReadAllBytes(filename);

                Image image = Image.FromFile(filename);
                Image thumb = image.GetThumbnailImage(75, 75, () => false, IntPtr.Zero);

                ImageConverter _imageConverter = new ImageConverter();
                byte[] imagethumbbyte = (byte[])_imageConverter.ConvertTo(thumb, typeof(byte[]));

                NovoVoziloRequest.Slika = file;
                NovoVoziloRequest.SlikaThumb = imagethumbbyte;
                pictureBox1.Image = image;
            }
        }
        #endregion


        #region Combobox Load

        private async Task LoadProizvodjacNoviModel()
        {
            var result = await _proizvodjaciService.Get<List<Model.Models.Proizvodjac>>(null);
            result.Insert(0, new Model.Models.Proizvodjac());

            ComboBoxLoad<Model.Models.Proizvodjac> cmbLoad = new ComboBoxLoad<Model.Models.Proizvodjac>();
            cmbLoad.Load(cmbProizvodjacModelNovi, result, "Naziv", "ProizvodjacId");
        }

        private async Task LoadDrzava()
        {
            var result = await _drzavaService.Get<List<Model.Models.Drzava>>(null);
            result.Insert(0, new Model.Models.Drzava());
            ComboBoxLoad<Model.Models.Drzava> cmbLoad = new ComboBoxLoad<Model.Models.Drzava>();
            cmbLoad.Load(cmbDrzavaProizvodjaca, result, "Naziv", "DrzavaId");
        }

        private async Task LoadProizvodjacVozila()
        {
            var result = await _proizvodjaciService.Get<List<Model.Models.Proizvodjac>>(null);
            result.Insert(0, new Model.Models.Proizvodjac());
            result.Insert(result.Count, new Proizvodjac()
            {
                Naziv = "Dodaj novog proizvodjača...",
                ProizvodjacId = result.Count

            });

            ComboBoxLoad<Model.Models.Proizvodjac> cmbLoad = new ComboBoxLoad<Model.Models.Proizvodjac>();
            cmbLoad.Load(cmbProizvodjac, result, "Naziv", "ProizvodjacId");

        }

        private async Task LoadKategorijaVozila()
        {
            var result = await _kategorijaService.Get<List<Model.Models.KategorijaVozila>>(null);
            result.Insert(0, new Model.Models.KategorijaVozila());

            ComboBoxLoad<Model.Models.KategorijaVozila> cmbLoad = new ComboBoxLoad<Model.Models.KategorijaVozila>();
            cmbLoad.Load(cmbKategorija, result, "Naziv", "KategorijaId");
           
        }

        private async Task LoadModelVozila(int ? Pid)
        {
            ModelAutomobilaSearch requestModel = new ModelAutomobilaSearch();
            if (Pid != null)
                requestModel.ProizvodjacId = Pid;

            var result = await _modeliService.Get<List<Model.Models.ModelAutomobila>>(requestModel);
            result.Insert(0, new Model.Models.ModelAutomobila());
            result.Insert(result.Count, new ModelAutomobila()
            {
                Naziv = "Dodaj novi model...",
                ModelId = result.Count

            });

            ComboBoxLoad<Model.Models.ModelAutomobila> cmbLoad = new ComboBoxLoad<Model.Models.ModelAutomobila>();
            cmbLoad.Load(cmbModel, result, "Naziv", "ModelId");
        }

        private async Task LoadProizvodjacEditVozila()
        {
            var result = await _proizvodjaciService.Get<List<Model.Models.Proizvodjac>>(null);
            result.Insert(0, new Model.Models.Proizvodjac());

            ComboBoxLoad<Model.Models.Proizvodjac> cmbLoad = new ComboBoxLoad<Model.Models.Proizvodjac>();
            cmbLoad.Load(cmbProizvodjacEdit, result, "Naziv", "ProizvodjacId");
        }

        private async Task LoadKategorijaEditVozila()
        {
            var result = await _kategorijaService.Get<List<Model.Models.KategorijaVozila>>(null);
            result.Insert(0, new Model.Models.KategorijaVozila());

            ComboBoxLoad<Model.Models.KategorijaVozila> cmbLoad = new ComboBoxLoad<Model.Models.KategorijaVozila>();
            cmbLoad.Load(cmbKategorijaEdit, result, "Naziv", "KategorijaId");
        }

        private async Task LoadModelEditVozila(int? Pid)
        {
            ModelAutomobilaSearch requestModel = new ModelAutomobilaSearch();
            if(Pid != null)
            requestModel.ProizvodjacId = Pid;

            var result = await _modeliService.Get<List<Model.Models.ModelAutomobila>>(requestModel);
            result.Insert(0, new Model.Models.ModelAutomobila());

            ComboBoxLoad<Model.Models.ModelAutomobila> cmbLoad = new ComboBoxLoad<Model.Models.ModelAutomobila>();
            cmbLoad.Load(cmbModelEdit, result, "Naziv", "ModelId");

        }
        private async Task LoadSearchProizvodjacVozila()
        {
            var result = await _proizvodjaciService.Get<List<Model.Models.Proizvodjac>>(null);
            result.Insert(0, new Model.Models.Proizvodjac());

            ComboBoxLoad<Model.Models.Proizvodjac> cmbLoad = new ComboBoxLoad<Model.Models.Proizvodjac>();
            cmbLoad.Load(cmbSearchProizvodjac, result, "Naziv", "ProizvodjacId");
        }

        private async Task LoadSearchModelVozila(int? proizvodjacId)
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

        private async Task LoadSearchKategorijaVozila()
        {
            var result = await _kategorijaService.Get<List<Model.Models.KategorijaVozila>>(null);
            result.Insert(0, new Model.Models.KategorijaVozila());
            ComboBoxLoad<Model.Models.KategorijaVozila> cmbLoad = new ComboBoxLoad<Model.Models.KategorijaVozila>();
            cmbLoad.Load(cmbSearchKategorija, result, "Naziv", "KategorijaId");
        }

        #endregion


        #region Validation   

        private void cmbProizvodjac_Validating(object sender, CancelEventArgs e)
        {
            var ProizvodjaciObj = cmbProizvodjac.SelectedValue;

            if (ProizvodjaciObj == null || ProizvodjaciObj.ToString() == "0")
            {
                errorProvider.SetError(cmbProizvodjac, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbProizvodjac, null);
            }
        }

        private void txtBoja_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoja.Text))
            {
                errorProvider.SetError(txtBoja, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtBoja, null);
            }
        }

        private void cmbModel_Validating(object sender, CancelEventArgs e)
        {
            var ModeliObj = cmbModel.SelectedValue;

            if (ModeliObj == null ||  ModeliObj.ToString() == "0")
            {
                errorProvider.SetError(cmbModel, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbModel, null);
            }


        }

        private void cmbKategorija_Validating(object sender, CancelEventArgs e)
        {
            var KategorijaObj = cmbKategorija.SelectedValue;

            if (KategorijaObj == null || KategorijaObj.ToString() == "0")
            {
                errorProvider.SetError(cmbKategorija, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbKategorija, null);
            }
        }

        private void txtKubikaza_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKubikaza.Text))
            {
                errorProvider.SetError(txtKubikaza, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtKubikaza, null);
            }
        }

        private void cmbTransmisija_Validating(object sender, CancelEventArgs e)
        {
            var TransmisijaObj = cmbTransmisija.SelectedIndex;

            if (TransmisijaObj <= 0 || TransmisijaObj.ToString() == " ")
            {
                errorProvider.SetError(cmbTransmisija, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbTransmisija, null);
            }
        }
        private void txtGodinaProizvodnje_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGodinaProizvodnje.Text))
            {
                errorProvider.SetError(txtGodinaProizvodnje, Properties.Resources.Validation_Required);

                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtGodinaProizvodnje, null);
            }
        }

        private void txtSnagaMotora_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSnagaMotora.Text))
            {
                errorProvider.SetError(txtSnagaMotora, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtSnagaMotora, null);
            }
        }

        private void cmbEmisioniStandard_Validating(object sender, CancelEventArgs e)
        {
            var EmisioniStandardObj = cmbEmisioniStandard.SelectedIndex;

            if (EmisioniStandardObj <= 0 || EmisioniStandardObj.ToString() == " ")
            {
                errorProvider.SetError(cmbEmisioniStandard, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbEmisioniStandard, null);
            }
        }

        private void cmbGorivo_Validating(object sender, CancelEventArgs e)
        {
            var GorivoObj = cmbGorivo.SelectedIndex;

            if (GorivoObj <= 0 || GorivoObj.ToString() == " ")
            {
                errorProvider.SetError(cmbGorivo, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbGorivo, null);
            }
        }

        private void cmbBrojVrata_Validating(object sender, CancelEventArgs e)
        {
            var BrojVrataObj = cmbBrojVrata.SelectedIndex;

            if (BrojVrataObj <= 0 || BrojVrataObj.ToString() == " ")
            {
                errorProvider.SetError(cmbBrojVrata, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbBrojVrata, null);
            }
        }

        private void txtBrojSjedista_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBrojSjedista.Text))
            {
                errorProvider.SetError(txtBrojSjedista, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtBrojSjedista, null);
            }

        }

        private void txtNazivProizvodjaca_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNazivProizvodjaca.Text))
            {
                errorProvider1.SetError(txtNazivProizvodjaca, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNazivProizvodjaca, null);
            }
        }

        private void cmbDrzavaProizvodjaca_Validating(object sender, CancelEventArgs e)
        {
            var DrzavaObj = cmbDrzavaProizvodjaca.SelectedValue;

            if (DrzavaObj == null || DrzavaObj.ToString() == "0")
            {
                errorProvider1.SetError(cmbDrzavaProizvodjaca, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cmbDrzavaProizvodjaca, null);
            }
        }

        private void cmbTrajanjeRegistracije_Validating(object sender, CancelEventArgs e)
        {
            var TrajanjeObj = cmbTrajanjeRegistracije.SelectedIndex;

            if (TrajanjeObj <= 0 || TrajanjeObj.ToString() == " ")
            {
                errorProvider.SetError(cmbTrajanjeRegistracije, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbTrajanjeRegistracije, null);
            }
        }

        private void txtIznos_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIznos.Text))
            {
                errorProvider.SetError(txtIznos, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtIznos, null);
            }
        }

        private void txtRegistarskeOznake_Validating(object sender, CancelEventArgs e)
        {
            if (!txtRegistarskeOznake.MaskCompleted)
            {
                errorProvider.SetError(txtRegistarskeOznake, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtRegistarskeOznake, null);

            }
        }

        private void cmbProizvodjacEdit_Validating(object sender, CancelEventArgs e)
        {
            var ProizvodjaciObj = cmbProizvodjacEdit.SelectedValue;

            if (ProizvodjaciObj == null || ProizvodjaciObj.ToString() == "0")
            {
                errorProvider.SetError(cmbProizvodjacEdit, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbProizvodjacEdit, null);
            }
        }

        private void cmbModelEdit_Validating(object sender, CancelEventArgs e)
        {
            var ModeliObj = cmbModelEdit.SelectedValue;

            if (ModeliObj == null || ModeliObj.ToString() == "0")
            {
                errorProvider.SetError(cmbModelEdit, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbModelEdit, null);
            }
        }

        private void cmbKategorijaEdit_Validating(object sender, CancelEventArgs e)
        {
            var Obj = cmbKategorijaEdit.SelectedValue;

            if (Obj == null || Obj.ToString() == "0")
            {
                errorProvider.SetError(cmbKategorijaEdit, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbKategorijaEdit, null);
            }
        }

        private void cmbTransmisijaEdit_Validating(object sender, CancelEventArgs e)
        {
            var TransmisijaObj = cmbTransmisijaEdit.SelectedIndex;

            if (TransmisijaObj <= 0 || TransmisijaObj.ToString() == " ")
            {
                errorProvider.SetError(cmbTransmisijaEdit, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbTransmisijaEdit, null);
            }
        }

        private void cmbESEdit_Validating(object sender, CancelEventArgs e)
        {
            var ESObj = cmbESEdit.SelectedIndex;

            if (ESObj <= 0 || ESObj.ToString() == " ")
            {
                errorProvider.SetError(cmbESEdit, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbESEdit, null);
            }
        }

        private void cmbGorivoEdit_Validating(object sender, CancelEventArgs e)
        {
            var GorivoObj = cmbGorivoEdit.SelectedIndex;

            if (GorivoObj <= 0 || GorivoObj.ToString() == " ")
            {
                errorProvider.SetError(cmbGorivoEdit, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbGorivoEdit, null);
            }

        }

        private void cmbBrojVrataEdit_Validating(object sender, CancelEventArgs e)
        {
            var BrojVrataObj = cmbBrojVrataEdit.SelectedIndex;

            if (BrojVrataObj <= 0 || BrojVrataObj.ToString() == " ")
            {
                errorProvider.SetError(cmbBrojVrataEdit, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbBrojVrataEdit, null);
            }
        }

        private void txtKubikazaEdit_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKubikazaEdit.Text))
            {
                errorProvider.SetError(txtKubikazaEdit, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtKubikazaEdit, null);
            }
        }

        private void txtGPEdit_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGPEdit.Text))
            {
                errorProvider.SetError(txtGPEdit, Properties.Resources.Validation_Required);

                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtGPEdit, null);
            }
        }

        private void txtBojaEdit_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBojaEdit.Text))
            {
                errorProvider.SetError(txtBojaEdit, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtBojaEdit, null);
            }
        }

        private void txtSnagaEdit_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSnagaEdit.Text))
            {
                errorProvider.SetError(txtSnagaEdit, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtSnagaEdit, null);
            }
        }

        private void txtBrojSjedistaEdit_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBrojSjedistaEdit.Text))
            {
                errorProvider.SetError(txtBrojSjedistaEdit, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtBrojSjedistaEdit, null);
            }
        }


        private void cmbProizvodjacModelNovi_Validating(object sender, CancelEventArgs e)
        {
            var ProizvodjaciObj = cmbProizvodjacModelNovi.SelectedValue;

            if (ProizvodjaciObj == null || ProizvodjaciObj.ToString() == "0")
            {
                errorProvider2.SetError(cmbProizvodjacModelNovi, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider2.SetError(cmbProizvodjacModelNovi, null);
            }
        }

        private void txtNazivModelaNovi_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNazivModelaNovi.Text))
            {
                errorProvider2.SetError(txtNazivModelaNovi, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider2.SetError(txtNazivModelaNovi, null);
            }
        }


        private async void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Obj = cmbModel.SelectedValue;
            var ObjP = cmbProizvodjac.SelectedValue;
            if (Obj != null)
            {
                ModelAutomobilaSearch automobilaSearch = new ModelAutomobilaSearch();

                if (int.TryParse(ObjP.ToString(), out int ProizvodjacId))
                {
                    automobilaSearch.ProizvodjacId = ProizvodjacId;
                }
                var p = await _modeliService.Get<List<Model.Models.ModelAutomobila>>(automobilaSearch);
                if (int.TryParse(Obj.ToString(), out int ModelId))
                {
                    if (ModelId == (p.Count + 1))
                    {
                        metroTabControl1.ShowTab(metroTabPage6);
                        metroTabControl1.SelectedTab = metroTabPage6;
                    }
                }

            }

        }

        private void txtCijenaIznajmljivanja_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCijenaIznajmljivanja.Text))
            {
                errorProvider.SetError(txtCijenaIznajmljivanja, Properties.Resources.Validation_Required);

                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtCijenaIznajmljivanja, null);
            }
        }

        private void txtCijenaOsiguranja_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCijenaOsiguranja.Text))
            {
                errorProvider.SetError(txtCijenaOsiguranja, Properties.Resources.Validation_Required);

                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtCijenaOsiguranja, null);
            }
        }

        private void txtCijenaOsiguranjaEdit_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCijenaOsiguranjaEdit.Text))
            {
                errorProvider.SetError(txtCijenaOsiguranjaEdit, Properties.Resources.Validation_Required);

                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtCijenaOsiguranjaEdit, null);
            }
        }

        private void txtCijenaIznajmljivanjaEdit_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCijenaIznajmljivanjaEdit.Text))
            {
                errorProvider.SetError(txtCijenaIznajmljivanjaEdit, Properties.Resources.Validation_Required);

                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtCijenaIznajmljivanjaEdit, null);
            }
        }



        private async void cmbProizvodjacEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Obj = cmbProizvodjacEdit.SelectedValue;
            if (Obj != null)
            {
                if (int.TryParse(Obj.ToString(), out int ProizvodjacId))
                {
                    await LoadModelEditVozila(ProizvodjacId);
                }

            }
        }



        private async void cmbSearchProizvodjac_SelectedIndexChanged(object sender, EventArgs e)
        {

            var Obj = cmbSearchProizvodjac.SelectedValue;
            if (int.TryParse(Obj.ToString(), out int ProizvodjacId))
            {
                await LoadSearchModelVozila(ProizvodjacId);
            }
        }

        private async void cmbProizvodjac_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Obj = cmbProizvodjac.SelectedValue;
            if (Obj != null)
            {
                var p = await _proizvodjaciService.Get<List<Model.Models.Proizvodjac>>(new ProizvodjacSearchRequest());
                if (int.TryParse(Obj.ToString(), out int ProizvodjacId))
                {
                    if (ProizvodjacId != (p.Count + 1))
                        await LoadModelVozila(ProizvodjacId);
                    else if (ProizvodjacId == (p.Count + 1))
                    {
                        metroTabControl1.ShowTab(metroTabPage5);
                        metroTabControl1.SelectedTab = metroTabPage5;
                    }
                }

            }
        }




        private void cbDostupanEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDostupanEdit.Checked)
            {
                lblNedostupanBrDana.Visible = false;
                txtNedostupanBrDana.Visible = false;
                cbNedostupanDoDaljnjeg.Visible = false;
                txtNedostupanBrDana.Text = "";
            }
            else
            {
                lblNedostupanBrDana.Visible = true;
                txtNedostupanBrDana.Visible = true;
                cbNedostupanDoDaljnjeg.Visible = true;

            }
        }

        private void cbNedostupanDoDaljnjeg_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNedostupanDoDaljnjeg.Checked)
                txtNedostupanBrDana.Enabled = false;
            else
                txtNedostupanBrDana.Enabled = true;
        }

        #endregion 


        #region KeyPress validation
        private void txtKubikaza_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je unesen broj ili tačka
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Provjera da li ima tačku 
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtBoja_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Provjera da li je uneseno slovo
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }


        }

        private void txtBrojSjedista_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je unesen broj
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSnagaMotora_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je unesen broj
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGodinaProizvodnje_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je unesen broj
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtProsjecnaPotrosnja_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je unesen broj ili tačka
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Provjera da li ima tačku 
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtGodina_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je unesen broj ili tačka
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtKubikazaEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je unesen broj ili tačka
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Provjera da li ima tačku 
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtGPEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je unesen broj ili tačka
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBojaEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je uneseno slovo
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }
        }

        private void txtSnagaEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je unesen broj
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPotrosnjaEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je unesen broj ili tačka
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Provjera da li ima tačku 
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtBrojSjedistaEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je unesen broj
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        //provjera unosa na uređivanju vozila
        private bool ProvjeraUnosa()
        {
            bool provjera = false;
            string error1 = errorProvider.GetError(cmbBrojVrataEdit);
            string error2 = errorProvider.GetError(cmbProizvodjacEdit);
            string error3 = errorProvider.GetError(cmbKategorijaEdit);
            string error4 = errorProvider.GetError(cmbModelEdit);
            string error5 = errorProvider.GetError(cmbTransmisijaEdit);
            string error6 = errorProvider.GetError(cmbESEdit);
            string error7 = errorProvider.GetError(cmbGorivoEdit);
            string error8 = errorProvider.GetError(txtBojaEdit);
            string error9 = errorProvider.GetError(txtKubikazaEdit);
            string error10 = errorProvider.GetError(txtGPEdit);
            string error11= errorProvider.GetError(txtSnagaEdit);
            string error12= errorProvider.GetError(txtBrojSjedistaEdit);


            if (string.IsNullOrEmpty(error1) && string.IsNullOrEmpty(error12)
                && string.IsNullOrEmpty(error2) && string.IsNullOrEmpty(error3)
                && string.IsNullOrEmpty(error4) && string.IsNullOrEmpty(error5)
                && string.IsNullOrEmpty(error6) && string.IsNullOrEmpty(error7)
                && string.IsNullOrEmpty(error8) && string.IsNullOrEmpty(error9)
                && string.IsNullOrEmpty(error10) && string.IsNullOrEmpty(error11))
            {
                provjera = true;
            }

            return provjera;
        }

        private void txtIznos_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je unesen broj ili tačka
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Provjera da li ima tačku 
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtRegistarskeOznake_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je unesen broj ili tačka
            if (!char.IsControl(e.KeyChar) && !char.IsUpper(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }


        private void txtNazivProizvodjaca_KeyPress(object sender, KeyPressEventArgs e)
        {
                // Provjera da li je uneseno slovo
                if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ' '))
                {
                    e.Handled = true;
                }
        }

        private void txtNazivModelaNovi_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je uneseno slovo
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }
        }

        private void txtCijenaIznajmljivanja_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je unesen broj ili zarez
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            // Provjera da li ima zarez 
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1) )
            {
                e.Handled = true;
            }
        }

        private void txtCijenaOsiguranja_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je unesen broj ili zarez
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // Provjera da li ima zarez 
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtCijenaOsiguranjaEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je unesen broj ili tačka
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // Provjera da li ima zarez 
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtCijenaIznajmljivanjaEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je unesen broj ili tačka
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            // Provjera da li ima zarez 
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        #endregion



    }
}
