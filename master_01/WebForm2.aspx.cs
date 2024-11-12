using System;
using System.Data;
using System.Data.SqlClient;

namespace master_01
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        // Cadena de conexión a la base de datos
        private string connectionString = "Data Source=DESKTOP-5SVBA77;Initial Catalog=tarea;Integrated Security=True;Encrypt=False";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar todos los usuarios al cargar la página por primera vez
                CargarUsuarios();
            }
        }

        // Método para cargar los usuarios en el GridView
        private void CargarUsuarios(string filtro = "", DateTime? fechaFiltro = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Consulta para obtener usuarios según el filtro
                string query = "SELECT * FROM Usuarios WHERE 1=1"; // "WHERE 1=1" es una condición siempre verdadera para facilitar el filtro dinámico

                // Si hay un filtro de búsqueda por nombre o apellido
                if (!string.IsNullOrEmpty(filtro))
                {
                    query += " AND (Nombre LIKE @Filtro OR Apellido LIKE @Filtro)";
                }

                // Si hay un filtro por fecha, lo añadimos
                if (fechaFiltro.HasValue)
                {
                    query += " AND FechaRegistro = @FechaRegistro";
                }

                SqlCommand cmd = new SqlCommand(query, conn);

                // Si hay un filtro de nombre o apellido, lo añadimos como parámetro
                if (!string.IsNullOrEmpty(filtro))
                {
                    cmd.Parameters.AddWithValue("@Filtro", "%" + filtro + "%");
                }

                // Si hay un filtro por fecha, lo añadimos como parámetro
                if (fechaFiltro.HasValue)
                {
                    cmd.Parameters.AddWithValue("@FechaRegistro", fechaFiltro.Value);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Verificamos si el DataTable tiene resultados
                if (dt.Rows.Count > 0)
                {
                    // Si se encontró un usuario, lo mostramos
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    lblMensaje.Visible = false; // Ocultamos el mensaje si encontramos resultados
                }
                else
                {
                    // Si no se encuentra un usuario, mostramos un mensaje
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "No se encontró ningún usuario con esos criterios.";
                }
            }
        }

        // Evento para realizar la búsqueda
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim(); // Obtener el texto del campo de búsqueda
            DateTime? fechaFiltro = null;

            // Si se ha seleccionado una fecha de búsqueda
            if (!string.IsNullOrEmpty(fechaBuscar.Value))
            {
                fechaFiltro = DateTime.Parse(fechaBuscar.Value);
            }

            // Llamar al método que carga los usuarios con el filtro correspondiente
            CargarUsuarios(filtro, fechaFiltro);
        }
    }
}
