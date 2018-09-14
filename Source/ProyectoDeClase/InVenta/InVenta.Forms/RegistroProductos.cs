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
    public partial class RegistroProductos : Form
    {
        private Form1 Padre { get; set; }
        public RegistroProductos(Form1 formulario)
        {
            Padre = formulario;
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (ExisteRegistro(Convert.ToInt32(txtProductoId.Text)))
            {
                MessageBox.Show("Ya existe este Id registrado");
                return;
            }

            //1. Creamos el objeto que permite la conexion
            string cadena = @"Server=DESKTOP-NGFBVFA\SQLEXPRESS2017;Database=InVenta;Trusted_Connection=True;";
            SqlConnection conexion = new SqlConnection(cadena);
            try
            {
                //2. Abrimos la conexión
                conexion.Open();

                //3. Construimos la sentencia DML (SELECT, INSERT, DELETE, UPDATE)
                string sql = @"INSERT INTO Producto (ProductoId,NombreProducto,Precio)
                                VALUES(@ProductoId,@NombreProducto,@Precio)";

                //4. Crear un Comando para enviar sentencias a la BD
                SqlCommand comando = new SqlCommand(sql, conexion);
                //5. Definir los parámetros de la consulta
                comando.Parameters.AddWithValue("@ProductoId", Convert.ToInt32(txtProductoId.Text));
                comando.Parameters.AddWithValue("@NombreProducto", txtNombre.Text);
                comando.Parameters.AddWithValue("@Precio", Convert.ToDouble(txtValor.Text));

                //6. Ejecución del comando
                //INSERT, DELETE, UPDATE -> ExecuteNonQuery
                //SELECT -> DataReader
                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("El registro se insertó");
                    this.Padre.CargarInfo();
                    this.txtValor.Text = "";
                    this.txtNombre.Text = "";
                    this.txtProductoId.Text = "";
                }
                else
                {
                    MessageBox.Show("Encontramos un error :(");
                }
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
        }


        public bool ExisteRegistro(int productoId)
        {
            //1. Creamos el objeto que permite la conexion
            string cadena = @"Server=DESKTOP-NGFBVFA\SQLEXPRESS2017;Database=InVenta;Trusted_Connection=True;";
            SqlConnection conexion = new SqlConnection(cadena);
            try
            {
                //2. Abrimos la conexión
                conexion.Open();

                //3. Construimos la sentencia DML (SELECT, INSERT, DELETE, UPDATE)
                string sql = @"SELECT ProductoId FROM Producto WHERE ProductoId=@ProductoId";

                //4. Crear un Comando para enviar sentencias a la BD
                SqlCommand comando = new SqlCommand(sql, conexion);
                //5. Definir los parámetros de la consulta
                comando.Parameters.AddWithValue("@ProductoId", productoId);

                //6. Ejecución del comando
                //INSERT, DELETE, UPDATE -> ExecuteNonQuery
                //SELECT -> DataReader
                object data = comando.ExecuteScalar();

                return data != null;
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

            return false;
        }
    }
}
