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

namespace Escritorio.Views
{
    public partial class FrmMunicipios : Form
    {
        public static int PKMUNICIPIO;
        public FrmMunicipios()
        {
            InitializeComponent();
            this.dgvMunicipios.AutoGenerateColumns = false;
        }

        public void cargarMunicipios()
        {
            this.dgvMunicipios.DataSource = ManejoMunicipio.Buscar(txtbuscar.Text, chbStatus.Checked);
        }

        private void dgvMunicipios_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvMunicipios.RowCount >= 1)
            {
                PKMUNICIPIO = Convert.ToInt32(this.dgvMunicipios.CurrentRow.Cells[0].Value);
                FrmActualizarMunicipio v = new FrmActualizarMunicipio(this);
                v.Show();
            }
        }

        private void FrmMunicipios_Load(object sender, EventArgs e)
        {
            cargarMunicipios();
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            cargarMunicipios();
        }

        private void chbStatus_CheckedChanged(object sender, EventArgs e)
        {
            cargarMunicipios();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvMunicipios.RowCount >= 1)
            {
                if (MessageBox.Show("Realmente quiere elimar este registro?", "Aviso...!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoMunicipio.Eliminar(Convert.ToInt32(this.dgvMunicipios.CurrentRow.Cells[0].Value));
                    this.cargarMunicipios();
                }
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            FrmRegistroMunicipio mun = new FrmRegistroMunicipio(this);
            mun.Show();
        }
    }
}
