using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;

namespace master_01
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        // Cadena de conexión a la base de datos
        private string connectionString = "Data Source=DESKTOP-5SVBA77;Initial Catalog=tarea;Integrated Security=True;Encrypt=False";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar los datos cuando la página carga por primera vez
                CargarDatos("Usuarios");  // Mostrar los usuarios por defecto
            }
        }

        protected void ddlTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cargar los datos de la tabla seleccionada
            string tablaSeleccionada = ddlTablas.SelectedValue;
            CargarDatos(tablaSeleccionada);

            // Mostrar los botones de exportación correspondientes
            if (tablaSeleccionada == "Usuarios")
            {
                btnExportarUsuarios.Visible = true;
                btnExportarMantenimiento.Visible = false;
            }
            else
            {
                btnExportarMantenimiento.Visible = true;
                btnExportarUsuarios.Visible = false;
            }
        }

        private void CargarDatos(string tabla)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM {tabla}", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Asignar los datos al GridView
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarDatos("Usuarios");
        }

        protected void btnExportarMantenimiento_Click(object sender, EventArgs e)
        {
            ExportarDatos("Mantenimiento");
        }

        protected void ExportarDatos(string tabla)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM {tabla}", conn);
                da.Fill(dt);
            }

            // Crear documento PDF
            using (MemoryStream ms = new MemoryStream())
            {
                using (PdfWriter writer = new PdfWriter(ms))
                {
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        Document doc = new Document(pdf, iText.Kernel.Geom.PageSize.A4);

                        // Título del PDF
                        doc.Add(new Paragraph($"Datos de la tabla {tabla}"));
                        doc.Add(new Paragraph("\n"));

                        // Crear tabla para datos
                        Table table = new Table(dt.Columns.Count);

                        // Agregar los encabezados de las columnas
                        foreach (DataColumn column in dt.Columns)
                        {
                            table.AddHeaderCell(column.ColumnName); // Añadir las cabeceras
                        }

                        // Agregar las filas de los datos
                        foreach (DataRow row in dt.Rows)
                        {
                            foreach (var item in row.ItemArray)
                            {
                                table.AddCell(item.ToString()); // Añadir las celdas de los datos
                            }
                        }

                        doc.Add(table);
                    }
                }

                // Descargar el PDF
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + tabla + ".pdf");
                Response.BinaryWrite(ms.ToArray());
                Response.End();
            }
        }
    }
}