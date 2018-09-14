using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InVenta.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistroProductos form = new RegistroProductos(this);
            form.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarInfo();

        }

        public void CargarInfo()
        {
            List<Producto> lista = CargarDatosProductos();

            this.dataGridView1.DataSource = lista;
        }

        public List<Producto> CargarDatosProductos()
        {
            List<Producto> losProductos = new List<Producto>();
            //1. Creamos el objeto que permite la conexion
            string cadena = @"Server=DESKTOP-NGFBVFA\SQLEXPRESS2017;Database=InVenta;Trusted_Connection=True;";
            SqlConnection conexion = new SqlConnection(cadena);
            try
            {
                //2. Abrimos la conexión
                conexion.Open();

                //3. Construimos la sentencia DML (SELECT, INSERT, DELETE, UPDATE)
                string sql = @"SELECT ProductoId,NombreProducto,Precio FROM  Producto";

                //4. Crear un Comando para enviar sentencias a la BD
                SqlCommand comando = new SqlCommand(sql, conexion);
                //5. Definir los parámetros de la consulta


                //6. Ejecución del comando
                //INSERT, DELETE, UPDATE -> ExecuteNonQuery
                //SELECT -> DataReader 
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    int productoId = reader.GetInt32(0);
                    string nombreProducto = reader.GetString(1);
                    double valor = reader.GetDouble(2);

                    Producto producto = new Producto
                    {
                        Codigo = productoId,
                        Nombre = nombreProducto,
                        Valor = valor
                    };
                    losProductos.Add(producto);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hemos encontrado un error ({ex.Message})");
            }
            finally
            {
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
            return losProductos;
        }
    }
}
