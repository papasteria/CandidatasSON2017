using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Escritorio.Controllers;
using Escritorio.Controllers.Helpers;

namespace Escritorio.Views
{
    public partial class FrmIngreso : Form
    {
        UsuarioHelper uHelper;
        public FrmIngreso()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            uHelper = ManejoUsuario.Autentificar(Convert.ToInt32(txtNoEmpleado.Text),
              txtContraseña.Text);
            if (uHelper.esValido)
            {
                FrmMenu.uHelper = uHelper;
                this.Close();
            }
            else
            {
                MessageBox.Show(uHelper.sMensaje, "Autentificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNoEmpleado.Text = "";
                txtContraseña.Text = "";
                txtNoEmpleado.Focus();
            }
        }

        private void txtNoEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
