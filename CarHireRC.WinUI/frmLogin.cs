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
    public partial class frmLogin : Form
    {
        APIService _service = new APIService("Korisnik");
        public frmLogin()
        {
            InitializeComponent();
        }

     

     

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                APIService.Username = txtUsername.Text;
                APIService.Password = txtPassword.Text;
                await _service.Get<dynamic>(null);
                string username = txtUsername.Text;

                this.Visible = false;

                DashboardForm frm = new DashboardForm(username);
                frm.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Authentifikacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
