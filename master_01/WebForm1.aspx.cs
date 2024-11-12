using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace master_01
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string connectionString = "Data Source=DESKTOP-5SVBA77;Initial Catalog=tarea;Integrated Security=True;Encrypt=False";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        // Cargar los datos de la base de datos en el GridView
        private void LoadData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM mantenimiento", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO mantenimiento (Nombre, Descripcion) VALUES (@Nombre, @Descripcion)", con);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            // Limpiar los campos después de agregar el registro
            txtNombre.Text = "";
            txtDescripcion.Text = "";

            LoadData();
        }

        // Editar un registro
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            LoadData();
        }

        // Cancelar la edición de un registro
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            LoadData();
        }

        // Actualizar un registro
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Obtener el ID del registro que se está editando
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            // Obtener los valores de los controles TextBox en la fila de edición
            TextBox txtNombreEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtNombreEdit");
            TextBox txtDescripcionEdit = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtDescripcionEdit");

            string nombre = txtNombreEdit.Text;
            string descripcion = txtDescripcionEdit.Text;

            // Actualizar los datos en la base de datos
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE mantenimiento SET Nombre = @Nombre, Descripcion = @Descripcion WHERE ID = @ID", con);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            // Establecer el modo de edición en -1 para salir del modo de edición
            GridView1.EditIndex = -1;

            // Recargar los datos en el GridView
            LoadData();
        }

        // Eliminar un registro
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value); // Obtener el ID

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM mantenimiento WHERE ID = @ID", con);
                cmd.Parameters.AddWithValue("@ID", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            LoadData();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Aquí puedes manejar lo que sucede cuando se selecciona un registro en el GridView
            int selectedIndex = GridView1.SelectedIndex;
            string selectedID = GridView1.SelectedRow.Cells[0].Text;  // Asumiendo que el ID está en la primera columna

            // Aquí puedes agregar lógica, como redirigir a otra página o mostrar detalles.
            // Ejemplo de redirigir a una página de edición:
            Response.Redirect("Editar.aspx?id=" + selectedID);
        }
    }
}
