using CarHireRC.Model.Requests;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarHireRC.WinUI.Korisnici
{
    public partial class frmProfil : Form
    {
        private readonly APIService _KorisniciService = new APIService("Korisnik");
        private readonly APIService _gradService = new APIService("Grad");

        public int KorisnikId;
        KorisniciUpsertRequest request = new KorisniciUpsertRequest();
        KorisniciSearchRequest requestSearch = new KorisniciSearchRequest();

        public frmProfil(int Id)
        {
            KorisnikId = Id;
            InitializeComponent();
        }
               

        private void btnIzmjenaSlike_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                var filename = openFileDialog1.FileName;

                var file = File.ReadAllBytes(filename);

                request.Slika = file;
                Image image = Image.FromFile(filename);
                Image thumb = image.GetThumbnailImage(75, 75, () => false, IntPtr.Zero);

                ImageConverter _imageConverter = new ImageConverter();
                byte[] imagethumbbyte = (byte[])_imageConverter.ConvertTo(thumb, typeof(byte[]));
                request.SlikaThumb = imagethumbbyte;
                pictureBox1.Image = image;
            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if(this.ValidateChildren())
                {
                var ModelidObj = cmbGrad.SelectedValue;
                if (int.TryParse(ModelidObj.ToString(), out int GradId))
                {
                    request.GradId = GradId;
                }

                request.Ime = txtIme.Text;
                request.Prezime = txtPrezime.Text;
                request.Adresa = txtAdresa.Text;
                request.UserName = txtUsername.Text;
                request.Email = txtEmail.Text;
                request.Telefon = txtTelefon.Text;
                if (txtPassword.Text != "")
                {
                    request.Password = txtPassword.Text;
                    request.PasswordPotvrda = txtPasswordPotvrda.Text;
                }
                var entity=await _KorisniciService.Update<Model.Models.Korisnici>(KorisnikId, request);
                if (entity != null)
                {
                    MessageBox.Show("Podaci uspješno izmjenjeni");
                }
            }
        }
        private async void frmProfil_Load(object sender, EventArgs e)
        {
            var user = await _KorisniciService.GetById<Model.Models.Korisnici>(KorisnikId);
            var grad = await _gradService.GetById<Model.Models.Grad>(user.GradId);

            await LoadGradovi();

            request.Ime = user.Ime;
            request.Prezime = user.Prezime;
            request.Adresa = user.Adresa;
            request.UserName = user.UserName;
            request.Email = user.Email;
            request.Telefon = user.Telefon;
            request.GradId = user.GradId;
             if (user.Slika != null)
             {
                 request.Slika = user.Slika;
                 byte[] slika = user.Slika;
                 MemoryStream memoryStream = new MemoryStream(slika);
                 pictureBox1.Image = Image.FromStream(memoryStream);
             }
              txtIme.Text=request.Ime;
              txtPrezime.Text=request.Prezime;
              txtAdresa.Text=request.Adresa;
              txtUsername.Text=request.UserName;
              txtEmail.Text=request.Email;
             txtTelefon.Text= request.Telefon;
            cmbGrad.SelectedIndex = cmbGrad.FindString(grad.Naziv);

           
        }

        private async Task LoadGradovi()
        {
            var result = await _gradService.Get<List<Model.Models.Grad>>(null);
            result.Insert(0, new Model.Models.Grad());
            cmbGrad.DisplayMember = "Naziv";
            cmbGrad.ValueMember = "GradId";
            cmbGrad.DataSource = result;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmbGrad_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var GradObj = cmbGrad.SelectedValue;

            if (GradObj.ToString() == "0")
            {
                errorProvider.SetError(cmbGrad, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbGrad, null);
            }
        }

        private void txtIme_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void txtPrezime_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtEmail, null);
            }
        }

        private void txtUsername_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider.SetError(txtUsername, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtUsername, null);
            }
        }

        private void txtIme_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je uneseno slovo ili prazno mjesto
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
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

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je uneseno slovo ili prazno mjesto
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != '.')  && (e.KeyChar != '-'))
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

        private void txtTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Provjera da li je unesenbroj
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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
    }
}
