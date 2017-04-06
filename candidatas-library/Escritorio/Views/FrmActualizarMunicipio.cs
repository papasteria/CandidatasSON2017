using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Imaging;
using Escritorio.Controllers;
using Escritorio.Comun;
using candidatas_library.Model;

namespace Escritorio.Views
{
    public partial class FrmActualizarMunicipio : Form
    {
        
        public String ImagenString { get; set; }
        public Bitmap ImagenBitmap { get; set; }

        FrmMunicipios vMain;
        public FrmActualizarMunicipio(FrmMunicipios vmain)
        {
            InitializeComponent();
            vMain = vmain;
            vMain.cargarMunicipios();
        }

        private void FrmActualizarMunicipio_Load(object sender, EventArgs e)
        {
            Municipio nMunicipio = ManejoMunicipio.getById(FrmMunicipios.PKMUNICIPIO);
            txtName.Text = nMunicipio.sNombre;
            txtDescripcion.Text = nMunicipio.sDescripcion;
            pcbLogo.Image = ToolImagen.Base64StringToBitmap(nMunicipio.sLogotipo);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtName, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtName, "Campo necesario");
                this.txtName.Focus();
            }
            else if (this.txtDescripcion.Text == "")
            {
                this.ErrorProvider.SetIconAlignment(this.txtDescripcion, ErrorIconAlignment.MiddleRight);
                this.ErrorProvider.SetError(this.txtDescripcion, "Campo necesario");
                this.txtDescripcion.Focus();
            }
            else
            {
                Municipio nMunicipio = new Municipio();
                nMunicipio.pkMunicipio = FrmMunicipios.PKMUNICIPIO;
                nMunicipio.sNombre = txtName.Text;
                nMunicipio.sDescripcion = txtDescripcion.Text;
                nMunicipio.sLogotipo = ImagenString;
                ManejoMunicipio.Modificar(nMunicipio);

                vMain.cargarMunicipios();

                this.Close();
            }
        }

        private void btnExaminar_Click(object sender, EventArgs e)
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
                    this.pcbLogo.ImageLocation = logo;
                    ImagenBitmap = new System.Drawing.Bitmap(logo);
                    ImagenString = ToolImagen.ToBase64String(ImagenBitmap, ImageFormat.Jpeg);
                    pcbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido" + ex.Message);
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
