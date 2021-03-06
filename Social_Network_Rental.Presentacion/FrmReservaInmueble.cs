using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Social_Network_Rental.Negocio;

namespace Social_Network_Rental.Presentacion
{
    public partial class FrmReservaInmueble : Form
    {
        public int idusua;
        public FrmReservaInmueble()
        {
            InitializeComponent();
        }
        private void TitulosGrilla()
        {
            dgvlistar.Columns[0].Visible = false;//Columna seleccionar
            //dgvlistar.Columns[1].Width = 50;
            dgvlistar.Columns[2].Width = 50;
            dgvlistar.Columns[3].Width = 80;
            dgvlistar.Columns[4].Width = 80;
            dgvlistar.Columns[5].Width = 80;
            dgvlistar.Columns[6].Width = 250;
            dgvlistar.Columns[7].Width = 80;
            dgvlistar.Columns[8].Width = 80;
            //dgvlistar.Columns[1].HeaderText = "Codigo I";
            dgvlistar.Columns[2].HeaderText = "Codigo U";
            dgvlistar.Columns[3].HeaderText = "Direccion I";
            dgvlistar.Columns[4].HeaderText = "Habitaciones H";
            dgvlistar.Columns[5].HeaderText = "Ciudad";
            dgvlistar.Columns[6].HeaderText = "Descripcion";
            dgvlistar.Columns[7].HeaderText = "Estado";
            dgvlistar.Columns[8].HeaderText = "Precio";

        }
        //Metodo Listar
        private void ListarGrilla()
        {
            int Buscar = idusua;
            try
            {
                dgvlistar.DataSource = Publico_INegocios.listar_usuario(Buscar);
                this.TitulosGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void FrmReservaInmueble_Load(object sender, EventArgs e)
        {
            ListarGrilla();
        }

        private void pcbcerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pcbminimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
