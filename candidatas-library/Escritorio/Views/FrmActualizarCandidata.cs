using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;
using Escritorio.Controllers;
using Escritorio.Comun;
using candidatas_library.Model;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;

namespace Escritorio.Views
{
    public partial class FrmActualizarCandidata : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        public String ImagenString { get; set; }
        public Bitmap ImagenBitmap { get; set; }

        FrmCandidatas vMain;
        private FrmCandidatas FrmCandidatas;
        public FrmActualizarCandidata(FrmCandidatas vmain)
        {
            InitializeComponent();
            vMain = vmain;
            vMain.cargarCandidatas();
        }

        public void cargarMunicipios()
        {
            int indexrol = 0;
            //llenar combo
            cmbMunicipio.DataSource = ManejoMunicipio.getAll(true);
            cmbMunicipio.DisplayMember = "sNombre";
            cmbMunicipio.ValueMember = "pkMunicipio";

            cmbMunicipio.SelectedIndex = indexrol;
        }

        private void FrmActualizarCandidata_Load(object sender, EventArgs e)
        {
            this.cargarMunicipios();

            Candidata nCandidata = ManejoCandidata.getById(FrmCandidatas.PKCANDIDATA);
            txtNombre.Text = nCandidata.sNombreCompleto;
            txtDescripcion.Text = nCandidata.sDescripcion;
            txtCorreo.Text = nCandidata.sCorreoElectronico;
            txtCurp.Text = nCandidata.sCurp;
            txtEstudios.Text = nCandidata.sNivelEstudios;

            pbxFoto.Image = ToolImagen.Base64StringToBitmap(nCandidata.sFotografiaRostro);

            dtpAño.Value = nCandidata.dtAnioConvocatoria;
            dtpFechaNac.Value = nCandidata.dtFechaNacimiento;

            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo device in videoDevices)
            {
                cmbCamara.Items.Add(device.Name);
            }
            if (cmbCamara.Items.Count > 0)
            {
                cmbCamara.SelectedIndex = 0;
                videoSource = new VideoCaptureDevice();
            }
            else
            {
                //lblError.Visible = true;
                btnCapturar.Enabled = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.txtNombre.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtNombre, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtNombre, "Campo necesario");
                this.txtNombre.Focus();
            }
            else if (this.txtCurp.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCurp, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCurp, "Campo necesario");
                this.txtCurp.Focus();
            }
            else if (this.txtDescripcion.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtDescripcion, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtDescripcion, "Campo necesario");
                this.txtDescripcion.Focus();
            }
            else if (this.txtCorreo.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtCorreo, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtCorreo, "Campo necesario");
                this.txtCorreo.Focus();
            }
            else if (this.txtEstudios.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtEstudios, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtEstudios, "Campo necesario");
                this.txtEstudios.Focus();
            }
            else
            {
                Candidata nCandidata = new Candidata();
                nCandidata.pkCandidata = FrmCandidatas.PKCANDIDATA;
                nCandidata.dtAnioConvocatoria = dtpAño.Value;
                nCandidata.sNombreCompleto = txtNombre.Text;
                nCandidata.dtFechaNacimiento = dtpFechaNac.Value;
                nCandidata.sDescripcion = txtDescripcion.Text;
                nCandidata.sCorreoElectronico = txtCorreo.Text;
                nCandidata.sCurp = txtCurp.Text;
                nCandidata.sNivelEstudios = txtEstudios.Text;
                nCandidata.sFotografiaRostro = ImagenString;
                int fkMunicipio = Convert.ToInt32(cmbMunicipio.SelectedValue.ToString());
                int fkUsuario = 1;

                ManejoCandidata.Modificar(nCandidata);

                vMain.cargarCandidatas();

                this.Close();
            }
        }

        private void btnCapturar_Click(object sender, EventArgs e)
        {
            if (videoSource.IsRunning)
            {
                videoSource.Stop();
                //this.picImagen.Image = null;
                this.pbxFoto.Image = ImagenBitmap;
                pbxFoto.Invalidate();
            }
            else
            {
                videoSource = new VideoCaptureDevice(videoDevices[cmbCamara.SelectedIndex].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(videoSource_newFrame);
                videoSource.Start();
            }
        }

        private void videoSource_newFrame(object sender, NewFrameEventArgs eventArgs)
        {
            ImagenBitmap = (Bitmap)eventArgs.Frame.Clone();
            ImagenString = ToolImagen.ToBase64String(ImagenBitmap, ImageFormat.Jpeg);
            pbxFoto.Image = ImagenBitmap;
        }

        public void FinalizarControles()
        {
            if (videoSource.IsRunning)
            {
                videoSource.Stop();
            }
        }

        public void PonerFotografia(String pathImagen)
        {
            ImagenBitmap = new System.Drawing.Bitmap(pathImagen);
            ImagenString = ToolImagen.ToBase64String(ImagenBitmap, ImageFormat.Jpeg);
            pbxFoto.Image = ImagenBitmap;
        }

        public static bool ValidarEmail(string email)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// evento que llama mandar el metodo de validar correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        /// <summary>
        /// metodo que valida el curp
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>

        public static bool ValidarCurp(string curp)
        {
            string expresion = "^.*(?=.{18})(?=.*[0-9])(?=.*[A-ZÑ]).*$";
            if (Regex.IsMatch(curp, expresion))
            {
                if (Regex.Replace(curp, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void txtCurp_Leave(object sender, EventArgs e)
        {
            if (ValidarCurp(txtCurp.Text))
            {

            }
            else
            {
                MessageBox.Show("Curp No Valida Debe de tener el formato : BOMC870421HDGRLS05, " +
                    "Favor Sellecione Un Curp Valido", "Validacion De Curp", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCorreo.SelectAll();
                txtCorreo.Focus();
            }
        }

        private void txtCorreoElectronico_Leave(object sender, EventArgs e)
        {
            if (ValidarEmail(txtCorreo.Text))
            {

            }
            else
            {
                MessageBox.Show("Direccion De Correo Electronico No Valido Debe de tener el formato : correo@gmail.com, " +
                    "Favor Sellecione Un Correo Valido", "Validacion De Correo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCorreo.SelectAll();
                txtCorreo.Focus();
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCurp_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtEstudios_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }
    }
}
