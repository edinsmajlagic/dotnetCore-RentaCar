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

namespace CarHireRC.WinUI.Korisnici
{
    public partial class frmKorisnici : Form
    {
        private readonly APIService _gradoviService = new APIService("Grad");
        private readonly APIService _korisniciService = new APIService("Korisnik");
        private readonly APIService _ulogeService = new APIService("Uloga");
        private readonly APIService _korisniciUlogeService = new APIService("KorisniciUloga");

        KorisniciUpsertRequest DodajRequest = new KorisniciUpsertRequest();
        KorisniciUpsertRequest UrediRequest = new KorisniciUpsertRequest();
        int _KorisnikID=0;
        private bool ulogaAdmin = false, ulogaMenadzer = false, ulogaUposlenik = false;

        public frmKorisnici(bool ulogaA, bool ulogaM, bool ulogaU)
        {
            ulogaAdmin = ulogaA;
            ulogaMenadzer = ulogaM;
            ulogaUposlenik = ulogaU;
            InitializeComponent();
        }

        private async void frmKorisnici_Load(object sender, EventArgs e)
        {
            metroTabControl1.HideTab(metroTabPage3);
            metroTabControl1.SelectedTab = metroTabPage1;

            if (!ulogaAdmin)
            {
                metroTabControl1.HideTab(metroTabPage2);
            }


            await LoadGradovi();
            await LoadSearchGradovi();
            await LoadUloge();

            dtpDo.MaxDate = DateTime.Now.Date;
            dtpOd.MaxDate = DateTime.Now.Date;
            dtpOd.Value = DateTime.Now.Date;
            dtpDo.Value = DateTime.Now.Date;
            dtpDatumRodjenja.MaxDate = DateTime.Now.Date;
            dtpDatumRodjenja.Value = DateTime.Now.Date;
            chbAktivan.Checked = true;
        }

        //Dodavanje novog korisnika
        private async void btnSacuvajNovi_Click(object sender, EventArgs e)
        {
            bool provjera = this.ValidateChildren();
            string error1 = errorProvider.GetError(txtEmail);
            string error2 = errorProvider.GetError(txtUsername);
            if (!string.IsNullOrEmpty(error1) || !string.IsNullOrEmpty(error2))
                provjera = false;


            if (provjera)
            {
                var uloge = cLBUloge.CheckedItems.Cast<Model.Models.Uloge>().Select(x => x.UlogaId).ToList();

                var gradIdObj = cmbGrad.SelectedValue;

                if (int.TryParse(gradIdObj.ToString(), out int gId))
                {
                    DodajRequest.GradId = gId;
                }

                if (DodajRequest.Slika == null)
                {
                    var filename = Properties.Resources.noImage;

                    MemoryStream ms = new MemoryStream();
                    filename.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                    DodajRequest.Slika = ms.ToArray();

                    Image image = Image.FromStream(new MemoryStream(DodajRequest.Slika));
                    Image thumb = image.GetThumbnailImage(75, 75, () => false, IntPtr.Zero);

                    ImageConverter _imageConverter = new ImageConverter();
                    byte[] imagethumbbyte = (byte[])_imageConverter.ConvertTo(thumb, typeof(byte[]));
                    DodajRequest.SlikaThumb = imagethumbbyte;
                }

                DodajRequest.Ime = txtIme.Text;
                DodajRequest.Prezime = txtPrezime.Text;
                DodajRequest.Email = txtEmail.Text;
                DodajRequest.UserName = txtUsername.Text;
                DodajRequest.Telefon = txtTelefon.Text;
                DodajRequest.Adresa = txtAdresa.Text;
                DodajRequest.Password = txtPassword.Text;
                DodajRequest.PasswordPotvrda = txtPasswordPotvrda.Text;
                DodajRequest.Status = chBoxAktivan.Checked;
                DodajRequest.DatumRegistracije = DateTime.Now;
                DodajRequest.DatumRodjenja = dtpDatumRodjenja.Value;
                DodajRequest.Uloge = uloge;

                var entity = await _korisniciService.Insert<Model.Models.Korisnici>(DodajRequest);

                if (entity != null)
                {
                    MessageBox.Show("Korisnik uspješno dodan");

                    cmbGrad.SelectedIndex = -1;
                    txtIme.Clear();
                    txtPrezime.Clear();
                    txtEmail.Clear();
                    txtUsername.Clear();
                    txtTelefon.Clear();
                    txtAdresa.Clear();
                    txtPassword.Clear();
                    txtPasswordPotvrda.Clear();
                    chBoxAktivan.Checked = true;
                    dtpDatumRodjenja.Value = DateTime.Now.Date;

                    //Postavljanje defaultne slike u picturebox
                    var filename = Properties.Resources.noImage;
                    MemoryStream ms = new MemoryStream();
                    filename.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    Image image = Image.FromStream(ms);
                    pictureBox1.Image = image;

                    metroTabControl1.SelectedTab = metroTabPage1;
                }
            }
        }


        private async void dgvKorisnici_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ulogaAdmin)
            {
                int Id = 0;
                if (dgvKorisnici.RowCount > 0)
                {
                    var val = dgvKorisnici.SelectedRows[0].Cells[0].Value;
                    Id = int.Parse(val.ToString());
                }
                if (_KorisnikID <= 0 && Id > 0)
                {
                    _KorisnikID = Id;
                    metroTabControl1.ShowTab(metroTabPage3);
                    await UcitajEditTab();
                    metroTabControl1.SelectedTab = metroTabPage3;
                }
            }
        }

        //Učitavanje tab page-a za uređivanje podataka o korisniku
        private async Task UcitajEditTab()
        {
            var user = await _korisniciService.GetById<Model.Models.Korisnici>(_KorisnikID);
            KorisniciUlogeSearchRequest searchRequest = new KorisniciUlogeSearchRequest
            {
                KorisnikId = user.KorisnikId
            };
            var userUloge = await _korisniciUlogeService.Get<List<Model.Models.KorisniciUloge>>(searchRequest);
            var grad = await _gradoviService.GetById<Model.Models.Grad>(user.GradId);

            await LoadUlogeEdit();



            UrediRequest.Ime = user.Ime;
            UrediRequest.Prezime = user.Prezime;
            UrediRequest.Adresa = user.Adresa;
            UrediRequest.UserName = user.UserName;
            UrediRequest.Email = user.Email;
            UrediRequest.Telefon = user.Telefon;
            UrediRequest.GradId = user.GradId;
            UrediRequest.Status = user.Status;
            UrediRequest.DatumRegistracije = user.DatumRegistracije;
            UrediRequest.DatumRodjenja = user.DatumRodjenja;

            if (user.Slika.Length > 0)
            {
                UrediRequest.Slika = user.Slika;
                UrediRequest.SlikaThumb = user.SlikaThumb;
                byte[] slika = user.Slika;
                MemoryStream memoryStream = new MemoryStream(slika);
                pictureBox2.Image = Image.FromStream(memoryStream);
            }
            txtImeEdit.Text = UrediRequest.Ime;
            txtPrezimeEdit.Text = UrediRequest.Prezime;
            txtAdresaEdit.Text = UrediRequest.Adresa;
            txtUsernameEdit.Text = UrediRequest.UserName;
            txtEmailEdit.Text = UrediRequest.Email;
            txtTelefonEdit.Text = UrediRequest.Telefon;
            txtDatumRegistracije.Text = UrediRequest.DatumRegistracije.Date.ToShortDateString();
            if (UrediRequest.DatumRodjenja != null)
                txtDatumRodjenja.Text = UrediRequest.DatumRodjenja.Value.ToShortDateString();
            txtGrad.Text = grad.Naziv;
            cbStatus.Checked = UrediRequest.Status;
            for (int i = 0; i < userUloge.Count; i++)
            {
                foreach (var item in clbUlogeEdit.Items.Cast<Model.Models.Uloge>().ToList())
                {
                    if (item.UlogaId == userUloge.ElementAt(i).UlogaId)
                        clbUlogeEdit.SetItemChecked(userUloge.ElementAt(i).UlogaId - 1, true);
                }
            }
        }


        //Spremanje izmjena podataka
        private async void btnSacuvajEdit_Click(object sender, EventArgs e)
        {
            UrediRequest.Status = cbStatus.Checked;
            UrediRequest.KorisnikId = _KorisnikID;
            var uloge = clbUlogeEdit.CheckedItems.Cast<Model.Models.Uloge>().Select(x => x.UlogaId).ToList();

            UrediRequest.Uloge = uloge;

            var entity = await _korisniciService.Update<Model.Models.Korisnici>(_KorisnikID, UrediRequest);
            if (entity != null)
            {
                MessageBox.Show("Uspješno izmjenjeni podaci o korisniku");
                _KorisnikID = 0;
                metroTabControl1.SelectedTab = metroTabPage1;
                metroTabControl1.HideTab(metroTabPage3);
                await PretragaKorisnika();
            }
        }


        //Pretraga korisnika
        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            await PretragaKorisnika();
        }

        private async Task PretragaKorisnika()
        {
            var search = new KorisniciSearchRequest();
            var GraddObj = cmbSearchGrad.SelectedValue;

            var uloge = clbUlogePretraga.CheckedItems.Cast<string>().ToList();

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
            search.uloge = uloge;

            var result = await _korisniciService.Get<List<Model.Models.Korisnici>>(search);
            dgvKorisnici.AutoGenerateColumns = false;
            dgvKorisnici.DataSource = result;
        }



        //Učitavanje slike
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

                DodajRequest.Slika = file;
                DodajRequest.SlikaThumb = imagethumbbyte;
                pictureBox1.Image = image;
            }
        }



        #region Cmb Load

        private async Task LoadGradovi()
        {
            var result = await _gradoviService.Get<List<Model.Models.Grad>>(null);
            result.Insert(0, new Model.Models.Grad());

            ComboBoxLoad<Model.Models.Grad> cmbLoad = new ComboBoxLoad<Model.Models.Grad>();
            cmbLoad.Load(cmbGrad, result, "Naziv", "GradId");
        }
        private async Task LoadSearchGradovi()
        {
            var result = await _gradoviService.Get<List<Model.Models.Grad>>(null);
            result.Insert(0, new Model.Models.Grad());

            ComboBoxLoad<Model.Models.Grad> cmbLoad = new ComboBoxLoad<Model.Models.Grad>();
            cmbLoad.Load(cmbSearchGrad, result, "Naziv", "GradId");
        }

        private async Task LoadUloge()
        {
            var result = await _ulogeService.Get<List<Model.Models.Uloge>>(null);
            cLBUloge.DataSource = result;
            cLBUloge.DisplayMember = "Naziv";
        }
        private async Task LoadUlogeEdit()
        {
            var result = await _ulogeService.Get<List<Model.Models.Uloge>>(null);
            clbUlogeEdit.DataSource = result;
            clbUlogeEdit.ValueMember = "UlogaId";
            clbUlogeEdit.DisplayMember = "Naziv";
        }

        #endregion  


        #region Validation

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                errorProvider.SetError(txtIme, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtIme, null);
            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                errorProvider.SetError(txtPrezime, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPrezime, null);
            }
        }

        private async void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            bool postoji = false;
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                KorisniciSearchRequest korisniciSearch = new KorisniciSearchRequest()
                {
                    Status = true,
                    Email = txtEmail.Text
                };

                var users = await _korisniciService.Get<List<Model.Models.Korisnici>>(korisniciSearch);

                if (users.Count > 0)
                {
                   postoji = true;
                }

                korisniciSearch.Status = false;

                users = await _korisniciService.Get<List<Model.Models.Korisnici>>(korisniciSearch);
                if (users.Count > 0)
                {
                  postoji = true;
                }



                if (postoji)
                {
                    errorProvider.SetError(txtEmail, Properties.Resources.Validation_EmailExists);
                    e.Cancel = true;
                }
                else
                    errorProvider.SetError(txtEmail, null);
            }
        }

        private async void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            bool postoji = false;

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider.SetError(txtUsername, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                KorisniciSearchRequest korisniciSearch = new KorisniciSearchRequest()
                {
                    Status = true,
                    UserName = txtUsername.Text
                };


                var user = await _korisniciService.Get<List<Model.Models.Korisnici>>(korisniciSearch);
                if (user.Count > 0)
                {
                   
                            postoji = true;
                }

                korisniciSearch.Status = false;
                user = await _korisniciService.Get<List<Model.Models.Korisnici>>(korisniciSearch);
                if (user.Count > 0)
                {
                  
                   postoji = true;
                }

                if (postoji)
                {
                    errorProvider.SetError(txtUsername, Properties.Resources.Validation_UsernameExists);
                    e.Cancel = true;
                }
                else
                    errorProvider.SetError(txtUsername, null);
            }
        }

        private void cmbGrad_Validating(object sender, CancelEventArgs e)
        {
            var GradObj = cmbGrad.SelectedValue;

            if (GradObj == null || GradObj.ToString() == "0")
            {
                errorProvider.SetError(cmbGrad, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbGrad, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider.SetError(txtPassword, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPassword, null);
            }
        }

        private void txtPasswordPotvrda_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPasswordPotvrda.Text))
            {
                errorProvider.SetError(txtPasswordPotvrda, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else if(!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                if(string.Compare(txtPassword.Text,txtPasswordPotvrda.Text) != 0)
                {
                    errorProvider.SetError(txtPasswordPotvrda, Properties.Resources.Validation_PasswordNotEqual);
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(txtPasswordPotvrda, null);
                }
            }
            else
            {
                errorProvider.SetError(txtPasswordPotvrda, null);
            }
        }

        #endregion


        #region Key press validation

        private void txtIme_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je uneseno slovo ili prazno mjesto
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }
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

        private void txtPrezime_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je uneseno slovo ili prazno mjesto
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }
        }

        private void txtTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je unesen broj
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je uneseno slovo ili prazno mjesto
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtAdresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je uneseno slovo ili prazno mjesto
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ' ') && (e.KeyChar != '-') && (e.KeyChar != '/'))
            {
                e.Handled = true;
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je uneseno slovo ili prazno mjesto
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-') && (e.KeyChar != '@'))
            {
                e.Handled = true;
            }
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


        #endregion


    }
}
