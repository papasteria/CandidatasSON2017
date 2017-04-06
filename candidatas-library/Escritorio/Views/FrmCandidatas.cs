using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using candidatas_library.Model;
using Escritorio.Controllers;

namespace Escritorio.Views
{
    public partial class FrmCandidatas : Form
    {
        public static int PKCANDIDATA;
        public FrmCandidatas()
        {
            InitializeComponent();
            this.dgvDatos.AutoGenerateColumns = false;
        }

        public void cargarCandidatas()
        {
            this.dgvDatos.DataSource = ManejoCandidata.Buscar(txtBuscarCandidata.Text, chkStatus.Checked);
        }

        private void FrmCandidatas_Load(object sender, EventArgs e)
        {
            cargarCandidatas();
        }

        private void dgvDatos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvDatos.RowCount >= 1)
            {
                PKCANDIDATA = Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[0].Value);
                FrmActualizarCandidata v = new FrmActualizarCandidata(this);
                v.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvDatos.RowCount >= 1)
            {
                if (MessageBox.Show("Realmente quiere elimar este registro?", "Aviso...!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ManejoCandidata.Eliminar(Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[0].Value));
                    this.cargarCandidatas();
                }
            }
        }

        private void txtBuscarCandidata_TextChanged(object sender, EventArgs e)
        {
            cargarCandidatas();
        }

        private void chkStatus_CheckedChanged(object sender, EventArgs e)
        {
            cargarCandidatas();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmRegistroCandidata re = new FrmRegistroCandidata(this);
            re.Show();
        }
    }
}
