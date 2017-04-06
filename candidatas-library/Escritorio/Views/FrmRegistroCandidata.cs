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
using System.Drawing.Imaging;
using Escritorio.Controllers;
using candidatas_library.Model;
using Escritorio.Comun;

namespace Escritorio.Views
{
    public partial class FrmRegistroCandidata : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;

        public String ImagenString { get; set; }
        public Bitmap ImagenBitmap { get; set; }
        int indexrol;

        FrmCandidatas vMain;
       
        public FrmRegistroCandidata(FrmCandidatas vmain)
        {
            InitializeComponent();
             vMain = vmain;
            vMain.cargarCandidatas();
        }

        private void FrmRegistroCandidata_Load(object sender, EventArgs e)
        {
            this.cargarMunicipios();

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

        public void cargarMunicipios()
        {
            //llenar combo
            cmbMunicipio.DataSource = ManejoMunicipio.getAll(true);
            cmbMunicipio.DisplayMember = "sNombre";
            cmbMunicipio.ValueMember = "pkMunicipio";
            try
            {
                cmbMunicipio.SelectedIndex = indexrol;
            }
            catch (Exception)
            {

                throw;
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
            else if (this.txtDescripcion.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtDescripcion, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtDescripcion, "Campo necesario");
                this.txtDescripcion.Focus();
            }
            else
            {
                Candidata nCandidata = new Candidata();

                nCandidata.dtAnioConvocatoria = dtpAño.Value.Date;
                nCandidata.sNombreCompleto = txtNombre.Text;
                nCandidata.dtFechaNacimiento = dtpFechaNac.Value.Date;
                nCandidata.sDescripcion = txtDescripcion.Text;
                nCandidata.sCorreoElectronico = txtCorreo.Text;
                nCandidata.sCurp = txtCurp.Text;
                nCandidata.sNivelEstudios = txtEstudios.Text;
                nCandidata.sFotografiaRostro = ImagenString;
                int fkMunicipio = Convert.ToInt32(cmbMunicipio.SelectedValue.ToString());
                int fkUsuario = 1;
                ManejoCandidata.Guardar(nCandidata, fkMunicipio, fkUsuario);

                MessageBox.Show("!Candidata Registrada¡");
                txtCorreo.Clear();
                txtCurp.Clear();
                txtDescripcion.Clear();
                txtEstudios.Clear();
                txtNombre.Clear();
                txtNombre.Focus();
                pbxFoto.Image = null;
            }
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

        private void videoSource_newFrame(object sender, NewFrameEventArgs eventArgs)
        {
            ImagenBitmap = (Bitmap)eventArgs.Frame.Clone();
            ImagenString = ToolImagen.ToBase64String(ImagenBitmap, ImageFormat.Jpeg);
            pbxFoto.Image = ImagenBitmap;
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

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog BuscarImagen = new OpenFileDialog();
                BuscarImagen.Filter = "Archivos de Imagen|*.jpg;*.png;*gif;*.bmp";
                //Aquí incluiremos los filtros que queramos.
                BuscarImagen.FileName = "";
                BuscarImagen.Title = "Seleccione una imagen";
                if (BuscarImagen.ShowDialog() == DialogResult.OK)
                {
                    string logo = BuscarImagen.FileName;
                    this.pbxFoto.ImageLocation = logo;
                    ImagenBitmap = new System.Drawing.Bitmap(logo);
                    ImagenString = ToolImagen.ToBase64String(ImagenBitmap, ImageFormat.Jpeg);
                    pbxFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido" + ex.Message);
            }
        }
    }
}
