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
    public partial class FrmMenu : Form
    {

        public static UsuarioHelper uHelper;
        public FrmMenu()
        {
            InitializeComponent();
        }

        public void ProcesarPermisos()
        {
            int permisos = 0;

            foreach (var obj in this.groupBox1.Controls)
            {
                if (obj is Button)
                {
                    Button btn = (Button)obj;
                    permisos = Convert.ToInt32(btn.Tag);
                    btn.Enabled = uHelper.TienePermiso(permisos);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Views.FrmMenuReportes r = new FrmMenuReportes();
            r.ShowDialog();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            if (uHelper == null)
            {
                FrmIngreso vLogin = new FrmIngreso();
                vLogin.ShowDialog();
            }
            if (uHelper.esValido && uHelper != null)
            {
                //TODO: ACTIVAR TODOS LOS CONTROLES SEGUN EL PERMISO
            }
            else
            {
                MessageBox.Show("Se require se autentifique", "Eror..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCandidatas_Click(object sender, EventArgs e)
        {
            FrmCandidatas v = new FrmCandidatas();
            v.ShowDialog();
        }

        private void btnMunicipio_Click(object sender, EventArgs e)
        {
            FrmMunicipios v = new FrmMunicipios();
            v.ShowDialog();
        }
    }
}
