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

namespace CarHireRC.WinUI.Poruka
{
    public partial class frmPoruke : Form
    {
        private readonly APIService _PorukaService = new APIService("Poruka");
        private int _UserID = 0,_PorukaID=0;
        public frmPoruke(int UID)
        {
            _UserID = UID;
            InitializeComponent();
        }

        private async Task PrimljeneTab()
        {
            PorukaSearchRequest porukaSearchRequest = new PorukaSearchRequest
            {
                UposlenikId=_UserID,
                Posiljaoc="Klijent"
            };
            var result = await _PorukaService.Get<List<Model.Models.Poruka>>(porukaSearchRequest);

            dgvPrimljenePoruke.AutoGenerateColumns = false;
            dgvPrimljenePoruke.DataSource = result;

        }

        private async Task PoslaneTab()
        {
            PorukaSearchRequest porukaSearchRequest = new PorukaSearchRequest
            {
                UposlenikId = _UserID,
                Posiljaoc = "Uposlenik"

            };
            var result = await _PorukaService.Get<List<Model.Models.Poruka>>(porukaSearchRequest);

            dgvPoslanePoruke.AutoGenerateColumns = false;
            dgvPoslanePoruke.DataSource = result;
        }

        private async void dgvPrimljenePoruke_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            
            if (dgvPrimljenePoruke.RowCount > 0)
            {
                var val = dgvPrimljenePoruke.SelectedRows[0].Cells[0].Value;
                _PorukaID = int.Parse(val.ToString());
            }
            if (_PorukaID > 0)
            {
                btnPoruka.Visible = true;
                await UcitajPrimljenuPoruku(_PorukaID);
            }
        }

        private async Task UcitajPrimljenuPoruku(int pid)
        {
            var poruka = await _PorukaService.GetById<Model.Models.Poruka>(pid);

           await PrikaziLabele("primljene");

            lblDatumVrijemePrimljene.Text =poruka.DatumVrijeme.ToString();
            lblNaslovPrimljene.Text =poruka.Naslov;
            lblPosiljaoc.Text =poruka.PosiljaocInfo;
            rtxtSadrzajPrimljene.Text =poruka.Sadrzaj;
        }

        private async void dgvPoslanePoruke_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int Id = 0;
            if (dgvPoslanePoruke.RowCount > 0)
            {
                var val = dgvPoslanePoruke.SelectedRows[0].Cells[0].Value;
                Id = int.Parse(val.ToString());
            }
            if (Id > 0)
            {
                await UcitajPoslanuPoruku(Id);
            }
        }


        private async Task UcitajPoslanuPoruku(int id)
        {
            var poruka = await _PorukaService.GetById<Model.Models.Poruka>(id);

           await PrikaziLabele("poslane");
            
            lblDatumVrijemePoslane.Text = poruka.DatumVrijeme.ToString();
            lblNaslovPoslane.Text = poruka.Naslov;
            lblPrimaoc.Text = poruka.PrimaocInfo;
            rtxtSadrzajPoslane.Text = poruka.Sadrzaj;
        }

        private async  Task PrikaziLabele(string s)
        {
           if(s=="poslane")
            {
                lbldvpo.Visible = true;
                lblppo.Visible = true;
                lblnpo.Visible = true;
                lblsppo.Visible = true;
                lblDatumVrijemePoslane.Visible = true;
                lblNaslovPoslane.Visible = true;
                lblPrimaoc.Visible = true;
                rtxtSadrzajPoslane.Visible = true;
            }
            else
            {
                lbldvp.Visible = true;
                lblpp.Visible = true;
                lblnp.Visible = true;
                lblspp.Visible = true;
                lblDatumVrijemePrimljene.Visible = true;
                lblNaslovPrimljene.Visible = true;
                lblPosiljaoc.Visible = true;
                rtxtSadrzajPrimljene.Visible = true;
            }
        }

        private async Task UkloniLabele(string s)
        {
            if (s == "poslane")
            {
                lbldvpo.Visible = false;
                lblppo.Visible = false;
                lblnpo.Visible = false;
                lblsppo.Visible = false;
                lblDatumVrijemePoslane.Visible = false;
                lblNaslovPoslane.Visible = false;
                lblPrimaoc.Visible = false;
                rtxtSadrzajPoslane.Visible = false;
            }
            else
            {
                lbldvp.Visible = false;
                lblpp.Visible = false;
                lblnp.Visible = false;
                lblspp.Visible = false;
                lblDatumVrijemePrimljene.Visible = false;
                lblNaslovPrimljene.Visible = false;
                lblPosiljaoc.Visible = false;
                rtxtSadrzajPrimljene.Visible = false
;
            }
        }

        private void lblDatumVrijemePoslane_Click(object sender, EventArgs e)
        {

        }

        private async void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (metroTabControl1.SelectedIndex)
            {
                case 0:
                    {
                        await UkloniLabele("primljene");
                        await PrimljeneTab();
                    }
                    break;
                case 1:
                    {
                        await UkloniLabele("poslane");
                        await PoslaneTab();
                    }
                    break;
            }
        }

        private async void btnPrikaziPoslane_Click(object sender, EventArgs e)
        {
            await PretragaPoslanihPoruka();

        }

        private async Task PretragaPoslanihPoruka()
        {
            var search = new PorukaSearchRequest();


            search.UposlenikId = _UserID;
            search.Posiljaoc = "Uposlenik";

            if (txtSearchImePrimaoc.Text != "")
            {
                search.PrimaocIme = txtSearchImePrimaoc.Text.ToLower();
            }
            if (txtSearchPrezimePrimaoc.Text != "")
            {
                search.PrimaocPrezime = txtSearchImePrimaoc.Text.ToLower();
            }
            if (txtSearchUsernamePrimaoc.Text != "")
            {
                search.PrimaocUsername = txtSearchUsernamePrimaoc.Text.ToLower();
            }
            if (cbOdPoslane.Checked)
            {
                search.DatumVrijemeOd = dtpOdPoslane.Value;
            }
            if (cbDoPoslane.Checked)
            {
                search.DatumVrijemeDo = dtpDoPoslane.Value;
            }


            var result = await _PorukaService.Get<List<Model.Models.Poruka>>(search);
            dgvPoslanePoruke.AutoGenerateColumns = false;
            dgvPoslanePoruke.DataSource = result;
        }

        private async void btnPrikaziPrimljene_Click(object sender, EventArgs e)
        {
            await PretragaPrimljenihPoruka();

        }

        private async Task PretragaPrimljenihPoruka()
        {
            var search = new PorukaSearchRequest();


            search.UposlenikId = _UserID;
            search.Posiljaoc = "Klijent";

            if (txtSearchImePosiljaoc.Text != "")
            {
                search.PosiljaocIme = txtSearchImePosiljaoc.Text.ToLower();
            }
            if (txtSearchPrezimePosiljaoc.Text != "")
            {
                search.PosiljaocPrezime = txtSearchPrezimePosiljaoc.Text.ToLower();
            }
            if (txtSearchUsernamePosiljaoc.Text != "")
            {
                search.PosiljaocUsername = txtSearchUsernamePosiljaoc.Text.ToLower();
            }
            if (chBOdPrimljene.Checked)
            {
                search.DatumVrijemeOd = dtpOdPrimljene.Value;
            }
            if (chbDoPrimljene.Checked)
            {
                search.DatumVrijemeDo = dtpDoPrimljene.Value;
            }


            var result = await _PorukaService.Get<List<Model.Models.Poruka>>(search);
            dgvPrimljenePoruke.AutoGenerateColumns = false;
            dgvPrimljenePoruke.DataSource = result;
        }

        private void txtSearchImePosiljaoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je uneseno slovo ili prazno mjesto
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }
        }

        private void txtSearchPrezimePosiljaoc_KeyPress(object sender, KeyPressEventArgs e)
        {
             // Provjera da li je uneseno slovo ili prazno mjesto
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }
        }

        private void txtSearchImePrimaoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je uneseno slovo ili prazno mjesto
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }
        }

        private void txtSearchPrezimePrimaoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je uneseno slovo ili prazno mjesto
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }
        }

        private void txtSearchUsernamePrimaoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je unesen alfanumerički karakter ili tačka
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtSearchUsernamePosiljaoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je unesen alfanumerički karakter ili tačka
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void chBOdPrimljene_CheckedChanged(object sender, EventArgs e)
        {
            if (chBOdPrimljene.Checked)
                dtpOdPrimljene.Enabled = true;
            else
                dtpOdPrimljene.Enabled = false;
        }

        private void chbDoPrimljene_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDoPrimljene.Checked)
                dtpDoPrimljene.Enabled = true;
            else
                dtpDoPrimljene.Enabled = false;
        }

        private void cbOdPoslane_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOdPoslane.Checked)
                dtpOdPoslane.Enabled = true;
            else
                dtpOdPoslane.Enabled = false;
        }

        private void cbDoPoslane_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDoPoslane.Checked)
                dtpDoPoslane.Enabled = true;
            else
                dtpDoPoslane.Enabled = false;
        }

        private async void frmPoruke_Load(object sender, EventArgs e)
        {
            await PretragaPrimljenihPoruka();
            metroTabControl1.SelectedTab = metroTabPage1;
            dtpOdPrimljene.MaxDate = DateTime.Now.Date;
            dtpOdPrimljene.Value = DateTime.Now.Date;
            dtpDoPrimljene.MaxDate = DateTime.Now.Date;
            dtpDoPrimljene.Value = DateTime.Now.Date;
            dtpOdPoslane.MaxDate = DateTime.Now.Date;
            dtpOdPoslane.Value = DateTime.Now.Date;
            dtpDoPoslane.MaxDate = DateTime.Now.Date;
            dtpDoPoslane.Value = DateTime.Now.Date;
        }

        private async void btnPoruka_Click(object sender, EventArgs e)
        {
            Model.Models.Poruka p =await _PorukaService.GetById<Model.Models.Poruka>(_PorukaID);
            frmNovaPorukaDialog frm = new frmNovaPorukaDialog(p.RezervacijaRentanjaId, _UserID);
            _PorukaID = 0;
            btnPoruka.Visible = false;
            frm.Show();
        }
    }
}
