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

namespace CarHireRC.WinUI.Klijenti
{
    public partial class frmKlijenti : Form
    {
        private readonly APIService _KlijentiService = new APIService("Klijent");
        private readonly APIService _GradService = new APIService("Grad");
        KlijentUpsertRequest UrediKlijentRequest = new KlijentUpsertRequest();

        private int _KlijentId;

        public frmKlijenti()
        {
            InitializeComponent();
        }

        private void chBOd_CheckedChanged(object sender, EventArgs e)
        {
            if (chBOd.Checked)
                dtpOd.Enabled = true;
            else
                dtpOd.Enabled = false;
        }

        private void chbDo_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDo.Checked)
                dtpDo.Enabled = true;
            else
                dtpDo.Enabled = false;
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            await PretragaKlijenata();
        }

        private async Task PretragaKlijenata()
        {
            var search = new KlijentSearchRequest();
            var GraddObj = cmbSearchGrad.SelectedValue;

            if (int.TryParse(GraddObj.ToString(), out int GradId))
            {
                search.GradId = GradId;
            }
            if (txtSearchIme.Text != "")
            {
                search.Ime = txtSearchIme.Text.ToLower();
            }
            if (txtSearchPrezime.Text != "")
            {
                search.Prezime = txtSearchPrezime.Text.ToLower();
            }
            if (txtSearchUsername.Text != "")
            {
                search.UserName = txtSearchUsername.Text.ToLower();
            }
            if (chbDo.Checked)
            {
                search.DatumRegistracijeDo = dtpDo.Value;
            }
            if (chBOd.Checked)
            {
                search.DatumRegistracijeOd = dtpOd.Value;
            }
            search.Status = chbAktivan.Checked;

            var result = await _KlijentiService.Get<List<Model.Models.Klijent>>(search);
            dgvKlijenti.AutoGenerateColumns = false;
            dgvKlijenti.DataSource = result;
        }

        private async void dgvKlijenti_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int Id = 0;
            if (dgvKlijenti.RowCount > 0)
            {
                var val = dgvKlijenti.SelectedRows[0].Cells[0].Value;
                Id = int.Parse(val.ToString());
            }
            if (_KlijentId <= 0 && Id > 0)
            {
                _KlijentId = Id;
                metroTabControl1.ShowTab(metroTabPage2);
                await UcitajEditTab();
                metroTabControl1.SelectedTab = metroTabPage2;
            }
        }

        private async Task UcitajEditTab()
        {
            var user = await _KlijentiService.GetById<Model.Models.Klijent>(_KlijentId);
            var grad = await _GradService.GetById<Model.Models.Grad>(user.GradId);

            await LoadGradovi();

            UrediKlijentRequest.Ime = user.Ime;
            UrediKlijentRequest.Prezime = user.Prezime;
            UrediKlijentRequest.Adresa = user.Adresa;
            UrediKlijentRequest.UserName = user.UserName;
            UrediKlijentRequest.Email = user.Email;
            UrediKlijentRequest.Telefon = user.Telefon;
            UrediKlijentRequest.GradId = user.GradId;
            UrediKlijentRequest.Status = user.Status;
            UrediKlijentRequest.DatumRegistracije = user.DatumRegistracije;
            UrediKlijentRequest.DatumRodjenja = user.DatumRodjenja;
            if (user.Slika.Length > 0)
            {
                UrediKlijentRequest.Slika = user.Slika;
                byte[] slika = user.Slika;
                MemoryStream memoryStream = new MemoryStream(slika);
                pictureBox1.Image = Image.FromStream(memoryStream);
            }
            txtIme.Text = UrediKlijentRequest.Ime;
            txtPrezime.Text = UrediKlijentRequest.Prezime;
            txtAdresa.Text = UrediKlijentRequest.Adresa;
            txtUsername.Text = UrediKlijentRequest.UserName;
            txtEmail.Text = UrediKlijentRequest.Email;
            txtTelefon.Text = UrediKlijentRequest.Telefon;
            txtDatumRegistracije.Text = UrediKlijentRequest.DatumRegistracije.Date.ToShortDateString();
            txtDatumRodjenja.Text = UrediKlijentRequest.DatumRodjenja.Date.ToShortDateString();
            txtGrad.Text = grad.Naziv;
            chBoxAktivan.Checked = UrediKlijentRequest.Status;
        }

        private async Task LoadGradovi()
        {
            var result = await _GradService.Get<List<Model.Models.Grad>>(null);
            result.Insert(0, new Model.Models.Grad());
            cmbSearchGrad.DisplayMember = "Naziv";
            cmbSearchGrad.ValueMember = "GradId";
            cmbSearchGrad.DataSource = result;
        }

        private async void btnSacuvajUredi_Click(object sender, EventArgs e)
        {
            UrediKlijentRequest.Status = chBoxAktivan.Checked;
            UrediKlijentRequest.KlijentId = _KlijentId;

            //if (UrediKlijentRequest.Slika == null)
            //{
            //    var filename = Properties.Resources.no_image;

            //    MemoryStream ms = new MemoryStream();
            //    filename.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

            //    UrediKlijentRequest.Slika = ms.ToArray();
            //    Image x = (Bitmap)((new ImageConverter()).ConvertFrom(ms.ToArray()));

            //    Image thumb = x.GetThumbnailImage(75, 75, () => false, IntPtr.Zero);

            //    ImageConverter _imageConverter = new ImageConverter();
            //    byte[] imagethumbbyte = (byte[])_imageConverter.ConvertTo(thumb, typeof(byte[]));
            //    UrediKlijentRequest.SlikaThumb = imagethumbbyte;
            //}

            var entity=await _KlijentiService.Update<Model.Models.Klijent>(_KlijentId, UrediKlijentRequest);
            if(entity != null)
            {
                MessageBox.Show("Uspješno izmjenjeni podaci o klijentu");

                _KlijentId = 0;
                metroTabControl1.SelectedTab = metroTabPage1;
                metroTabControl1.HideTab(metroTabPage2);
                await PretragaKlijenata();
            }
        }

        private async void frmKlijenti_Load(object sender, EventArgs e)
        {
            metroTabControl1.HideTab(metroTabPage2);
            metroTabControl1.SelectedTab = metroTabPage1;
            await LoadGradovi();
            dtpDo.MaxDate = DateTime.Now.Date;
            dtpOd.MaxDate = DateTime.Now.Date;
            dtpOd.Value = DateTime.Now.Date;
            dtpDo.Value = DateTime.Now.Date;
        }

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

        private void txtSearchUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je unesen alfanumerički karakter ili tačka
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
