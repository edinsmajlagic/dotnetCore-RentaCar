using CarHireRC.Model.Models;
using CarHireRC.Model.Requests;
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
        private readonly APIService _registracijaVozilaService = new APIService("RegistracijaVozila");
        private readonly APIService _RezervacijaVozilaService = new APIService("RezervacijaRentanja");
        RegistracijaVozilaUpsertRequest RegistracijaRequest = new RegistracijaVozilaUpsertRequest();
        RegistracijaVozila posljednjaRegistracija;
        AutomobiliUPSERTtRequest NovoVoziloRequest = new AutomobiliUPSERTtRequest();
        AutomobiliUPSERTtRequest IzmjenaVoziloRequest = new AutomobiliUPSERTtRequest();

        private int _VoziloId, _userId, pId,mId,kId;

        public frmVozila(int UserID)
        {
            _userId = UserID;
            InitializeComponent();
        }

        private async void frmVozila_Load(object sender, EventArgs e)
        {
            metroTabControl1.HideTab(metroTabPage3);
            metroTabControl1.HideTab(metroTabPage4);
            metroTabControl1.SelectedTab = metroTabPage1;

            await LoadSearchModelVozila(null);
            await LoadSearchProizvodjacVozila();
            await LoadSearchKategorijaVozila();

            await LoadProizvodjacVozila();
            await LoadKategorijaVozila();
            await LoadModelVozila(null);


          
        }

        private async Task LoadProizvodjacVozila()
        {
            var result = await _proizvodjaciService.Get<List<Model.Models.Proizvodjac>>(null);
            result.Insert(0, new Model.Models.Proizvodjac());
            cmbProizvodjac.DisplayMember = "Naziv";
            cmbProizvodjac.ValueMember = "ProizvodjacId";
            cmbProizvodjac.DataSource = result;
        }

        private async Task LoadKategorijaVozila()
        {
            var result = await _kategorijaService.Get<List<Model.Models.KategorijaVozila>>(null);
            result.Insert(0, new Model.Models.KategorijaVozila());
            cmbKategorija.DisplayMember = "Naziv";
            cmbKategorija.ValueMember = "KategorijaId";
            cmbKategorija.DataSource = result;
        }


        private async Task LoadModelVozila(int ? Pid)
        {
            ModelAutomobilaSearch requestModel = new ModelAutomobilaSearch();

            if (Pid != null)
                requestModel.ProizvodjacId = Pid;

            var result = await _modeliService.Get<List<Model.Models.ModelAutomobila>>(requestModel);

            result.Insert(0, new Model.Models.ModelAutomobila());
            cmbModel.DisplayMember = "Naziv";
            cmbModel.ValueMember = "ModelId";
            cmbModel.DataSource = result;
         
        }

        private async Task LoadProizvodjacEditVozila()
        {
            var result = await _proizvodjaciService.Get<List<Model.Models.Proizvodjac>>(null);
            result.Insert(0, new Model.Models.Proizvodjac());
            cmbProizvodjacEdit.DisplayMember = "Naziv";
            cmbProizvodjacEdit.ValueMember = "ProizvodjacId";
            cmbProizvodjacEdit.DataSource = result;



        }

        private async Task LoadKategorijaEditVozila()
        {
            var result = await _kategorijaService.Get<List<Model.Models.KategorijaVozila>>(null);
            result.Insert(0, new Model.Models.KategorijaVozila());
            cmbKategorijaEdit.DisplayMember = "Naziv";
            cmbKategorijaEdit.ValueMember = "KategorijaId";
            cmbKategorijaEdit.DataSource = result;
        }


        private async Task LoadModelEditVozila(int? Pid)
        {
            ModelAutomobilaSearch requestModel = new ModelAutomobilaSearch();

            if(Pid != null)
            requestModel.ProizvodjacId = Pid;

            var result = await _modeliService.Get<List<Model.Models.ModelAutomobila>>(requestModel);

            result.Insert(0, new Model.Models.ModelAutomobila());
            cmbModelEdit.DisplayMember = "Naziv";
            cmbModelEdit.ValueMember = "ModelId";
            cmbModelEdit.DataSource = result;

        }
        private async Task LoadSearchProizvodjacVozila()
        {
            var result = await _proizvodjaciService.Get<List<Model.Models.Proizvodjac>>(null);
            result.Insert(0, new Model.Models.Proizvodjac());
            cmbSearchProizvodjac.DisplayMember = "Naziv";
            cmbSearchProizvodjac.ValueMember = "ProizvodjacId";
            cmbSearchProizvodjac.DataSource = result;
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

            cmbSearchModel.DisplayMember = "Naziv";
            cmbSearchModel.ValueMember = "ModelId";
            cmbSearchModel.DataSource = result;
        }

        private async Task LoadSearchKategorijaVozila()
        {
            var result = await _kategorijaService.Get<List<Model.Models.KategorijaVozila>>(null);
            result.Insert(0, new Model.Models.KategorijaVozila());
            cmbSearchKategorija.DisplayMember = "Naziv";
            cmbSearchKategorija.ValueMember = "KategorijaId";
            cmbSearchKategorija.DataSource = result;
        }

       


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

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            await PretragaVozila();
        }

        private async Task PretragaVozila()
        {
            var search = new RezervacijaSearchRequest();
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

        private async void btnRegistrujVozilo_Click(object sender, EventArgs e)
        {
            int Id=0;
            if (dgvAutomobili.RowCount >0)
            {
                var val = dgvAutomobili.SelectedRows[0].Cells[0].Value;
                Id = int.Parse(val.ToString());
            }
            if (_VoziloId <= 0 && Id>0)
            {
                _VoziloId = Id;
                await UcitajRegistracijaTab();

                metroTabControl1.ShowTab(metroTabPage3);
                metroTabControl1.SelectedTab=metroTabPage3;
            }
        }

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

        private async void btnSacuvajRegistraciju_Click(object sender, EventArgs e)
        {
            bool provjera = this.ValidateChildren();
            string error1 = errorProvider.GetError(txtIznos);
            string error2 = errorProvider.GetError(cmbTrajanjeRegistracije);
            string error3 = errorProvider.GetError(txtRegistarskeOznake);

            if (string.IsNullOrEmpty(error1) && string.IsNullOrEmpty(error2) && string.IsNullOrEmpty(error3))
            {
                provjera = true;
            }
            

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
                    if(entity != null)
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

        private async Task UpdateStatusVozila(int voziloId)
        {
            var vozilo = await _automobiliService.GetById<Model.Models.Automobil>(voziloId);

            AutomobiliUPSERTtRequest automobilirequest = new AutomobiliUPSERTtRequest
            {
                AutomobilId = voziloId,
                Boja=vozilo.Boja,
                BrojSjedista=vozilo.BrojSjedista,
                BrojVrata=vozilo.BrojVrata,
                Dostupan=true,
                
                EmisioniStandard =vozilo.EmisioniStandard,
                GodinaProizvodnje=vozilo.GodinaProizvodnje,
                Gorivo =vozilo.Gorivo,
                KategorijaId=vozilo.KategorijaId,
                Kubikaza =vozilo.Kubikaza,
                ModelId =vozilo.ModelId,
                Novo =vozilo.Novo,
                Potrosnja =vozilo.Potrosnja,
                SnagaMotora =vozilo.SnagaMotora,
                Transmisija =vozilo.Transmisija,
                Slika =vozilo.Slika,
            };
           await _automobiliService.Update<Model.Models.Automobil>(voziloId, automobilirequest);

        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            bool provjera = this.ValidateChildren();
            if (provjera)
            {
                NovoVoziloRequest.Boja = txtBoja.Text;
                NovoVoziloRequest.Novo = chBoxNovo.Checked;
                NovoVoziloRequest.Dostupan = false;
                NovoVoziloRequest.SnagaMotora = txtSnagaMotora.Text;
                NovoVoziloRequest.GodinaProizvodnje = int.Parse(txtGodinaProizvodnje.Text.ToString());
                NovoVoziloRequest.BrojSjedista = txtBrojSjedista.Text;
                NovoVoziloRequest.Potrosnja = txtProsjecnaPotrosnja.Text;
                NovoVoziloRequest.Kubikaza = txtKubikaza.Text;

                if (NovoVoziloRequest.Slika == null)
                {
                    var filename = Properties.Resources.no_image;

                    MemoryStream ms = new MemoryStream();
                    filename.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                    NovoVoziloRequest.Slika = ms.ToArray();
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
                    await PretragaVozila();
                }

            }
        }

        private void chBoxDostupan_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroTabPage2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                var filename = openFileDialog1.FileName;

                var file = File.ReadAllBytes(filename);

                NovoVoziloRequest.Slika = file;
                Image image = Image.FromFile(filename);
                Image thumb = image.GetThumbnailImage(75, 75, () => false, IntPtr.Zero);

                ImageConverter _imageConverter = new ImageConverter();
                byte[] imagethumbbyte = (byte[])_imageConverter.ConvertTo(thumb, typeof(byte[]));
                NovoVoziloRequest.SlikaThumb = imagethumbbyte;
                pictureBox1.Image = image;
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            var result = openFileDialog2.ShowDialog();

            if (result == DialogResult.OK)
            {
                var filename = openFileDialog2.FileName;

                var file = File.ReadAllBytes(filename);

                IzmjenaVoziloRequest.Slika = file;
                Image image = Image.FromFile(filename);
                Image thumb = image.GetThumbnailImage(75, 75, () => false, IntPtr.Zero);

                ImageConverter _imageConverter = new ImageConverter();
                byte[] imagethumbbyte = (byte[])_imageConverter.ConvertTo(thumb, typeof(byte[]));
                IzmjenaVoziloRequest.SlikaThumb = imagethumbbyte;
                pictureBox3.Image = image;
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

        private async void btnSacuvajEdit_Click(object sender, EventArgs e)
        {
            bool provjera = this.ValidateChildren();   

            provjera = ProvjeraUnosa();
            if (provjera)
            {

                IzmjenaVoziloRequest.AutomobilId = _VoziloId;
                IzmjenaVoziloRequest.Boja = txtBojaEdit.Text;
                IzmjenaVoziloRequest.Novo = cbNovoEdit.Checked;
                RegistracijaVozilaSearchRequest r = new RegistracijaVozilaSearchRequest
                {
                    AutomobilId = _VoziloId,
                    Status=true
                };
                var registrovan =await _registracijaVozilaService.Get<List<RegistracijaVozila>>(r);
                if (registrovan.Count > 0)
                {
                    IzmjenaVoziloRequest.Dostupan = cbDostupanEdit.Checked;
                    if(!cbDostupanEdit.Checked)
                         await PosaljiObavijestKlijentu(_VoziloId);

                }
                else
                {
                    IzmjenaVoziloRequest.Dostupan = false;
                }
                IzmjenaVoziloRequest.SnagaMotora = txtSnagaEdit.Text;
                IzmjenaVoziloRequest.GodinaProizvodnje = int.Parse(txtGPEdit.Text.ToString());
                IzmjenaVoziloRequest.BrojSjedista = txtBrojSjedistaEdit.Text;
                IzmjenaVoziloRequest.Potrosnja = txtPotrosnjaEdit.Text;
                IzmjenaVoziloRequest.Kubikaza = txtKubikazaEdit.Text;

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

                var entity=await _automobiliService.Update<Model.Models.Automobil>(_VoziloId, IzmjenaVoziloRequest);
                if(entity != null)
                {
                    MessageBox.Show("Uspješno izmjenjeni podaci o vozilu");

                    _VoziloId = 0;
                    metroTabControl1.SelectedTab = metroTabPage1;
                    metroTabControl1.HideTab(metroTabPage4);
                    await PretragaVozila();

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
                }
            }
        }

        private async Task PosaljiObavijestKlijentu(int VID)
        {
            RezervacijaRentanjaSearchRequest rezervacijaRentanjaSearch = new RezervacijaRentanjaSearchRequest
            {
                AutomobilId = VID,
                RezervacijaOd = DateTime.Now,
                VracanjeUposlovnicu = true,
                KaskoOsiguranje = true
            };
            List<Model.Models.RezervacijaRentanja> rezervacije = await _RezervacijaVozilaService.Get<List<Model.Models.RezervacijaRentanja>>(rezervacijaRentanjaSearch);
            rezervacijaRentanjaSearch.VracanjeUposlovnicu = false;
            List<Model.Models.RezervacijaRentanja> rezervacijeII = await _RezervacijaVozilaService.Get<List<Model.Models.RezervacijaRentanja>>(rezervacijaRentanjaSearch);
            rezervacijaRentanjaSearch.KaskoOsiguranje = false;
            rezervacijaRentanjaSearch.VracanjeUposlovnicu = true;
            List<Model.Models.RezervacijaRentanja> rezervacijeIII = await _RezervacijaVozilaService.Get<List<Model.Models.RezervacijaRentanja>>(rezervacijaRentanjaSearch);
            rezervacijaRentanjaSearch.VracanjeUposlovnicu = false;
            List<Model.Models.RezervacijaRentanja> rezervacijeIV = await _RezervacijaVozilaService.Get<List<Model.Models.RezervacijaRentanja>>(rezervacijaRentanjaSearch);


            foreach (var item in rezervacijeII)
            {
                rezervacije.Add(item);
            }
            foreach (var item in rezervacijeIII)
            {
                rezervacije.Add(item);
            }
            foreach (var item in rezervacijeIV)
            {
                rezervacije.Add(item);
            }
            foreach (var item in rezervacije)
            {
                await ObavijestiKlijenta(item.RezervacijaRentanjaId, item.KlijentId, _userId);
            }


        }

        private async Task ObavijestiKlijenta(int rezervacijaRentanjaId, int klijentId, int userId)
        {
            var klijent = await _klijentService.GetById<Model.Models.Klijent>(klijentId);

            PorukaUpsertRequest porukaUpsert = new PorukaUpsertRequest
            {
                RezervacijaRentanjaId=rezervacijaRentanjaId,
                KlijentId=klijentId,
                UposlenikId=userId,
                DatumVrijeme=DateTime.Now,
                Naslov=Properties.Resources.NaslovPorukeNedostupnoVozilo,
                Procitano=false,
                Posiljaoc="Uposlenik",
                Sadrzaj=Properties.Resources.SadrzajPorukeNedostupnoVoziloPozdrav
                        + " "+klijent.Ime+" "+klijent.Prezime+" ! \n"
                        +Properties.Resources.SadrzajPorukeNedostupnoVozilo

            };
            await _porukaService.Insert<Model.Models.Poruka>(porukaUpsert);
        }

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

        private async void dgvAutomobili_MouseDoubleClick(object sender, MouseEventArgs e)
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
                metroTabControl1.ShowTab(metroTabPage4);
                await UcitajEditTab();
                metroTabControl1.SelectedTab = metroTabPage4;



            }
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

            if (vozilo.Slika != null)
            {
                IzmjenaVoziloRequest.Slika = vozilo.Slika;
                byte[] slika = vozilo.Slika;
                MemoryStream memoryStream = new MemoryStream(slika);
                pictureBox3.Image = Image.FromStream(memoryStream);
            }


            txtBojaEdit.Text = vozilo.Boja;
            txtBrojSjedistaEdit.Text = vozilo.BrojSjedista;
            txtGPEdit.Text = vozilo.GodinaProizvodnje.ToString();
            txtKubikazaEdit.Text = vozilo.Kubikaza;
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
                if (int.TryParse(Obj.ToString(), out int ProizvodjacId))
                {
                    await LoadModelVozila(ProizvodjacId);
                }
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
    }
}
