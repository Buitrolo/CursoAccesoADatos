using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Estudiante estudiante = new Estudiante
            {
                Codigo = txtCodigo.Text,
                Nombres = txtNombres.Text,
                Apellidos = txtApellidos.Text
            };
            try
            {
                if (ControladorDeArchivo.Guardar(estudiante))
                {
                    MessageBox.Show("Se guardaron los datos", "Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtApellidos.Text = "";
                    txtNombres.Text = "";
                    txtCodigo.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Estudiante> lista = ControladorDeArchivo.Consultar();

            dataGridView1.DataSource = lista;

            this.Height = 400;
        }
    }
}
