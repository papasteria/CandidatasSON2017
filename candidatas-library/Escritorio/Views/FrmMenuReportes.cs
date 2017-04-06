using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escritorio.Views
{
    public partial class FrmMenuReportes : Form
    {
        public FrmMenuReportes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reportes.frmRptConv candidatas = new Reportes.frmRptConv();
            candidatas.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reportes.frmRptMuni municipio = new Reportes.frmRptMuni();
            municipio.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reportes.frmRptLike likes = new Reportes.frmRptLike();
            likes.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reportes.frmGanadoraMuni gamn = new Reportes.frmGanadoraMuni();
            gamn.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reportes.frmRptCaptura cap = new Reportes.frmRptCaptura();
            cap.ShowDialog();
        }
    }
}
