using CrudWindowsFormAnalisisDeSistemas.Dato;
using CrudWindowsFormAnalisisDeSistemas.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudWindowsFormAnalisisDeSistemas
{
    public partial class Form1 : Form
    {
        private DataTable tabla;
        VehiculoAdmin admin = new VehiculoAdmin();  
        private void Inicializar()
        {
            tabla = new DataTable();
            tabla.Columns.Add("Id");
            tabla.Columns.Add("Marca");
            tabla.Columns.Add("Precio");
            tabla.Columns.Add("Color");
            dgvehiculo.DataSource = tabla;
        }
        public Form1()
        {
            InitializeComponent();
            Consultar();
        }
        private void Consultar()
        {
            Inicializar();
            List <vehiculo> lista = admin.Consultar();
            foreach (var item in lista)
            {
                DataRow row = tabla.NewRow();
                row["Id"] = item.Id;
                row["Marca"] = item.marca;
                row["Precio"] = item.precio;
                row["Color"] = item.color;
                tabla.Rows.Add(row);

            }
       } 
        private void Guardar()
        {
            vehiculo modelo = new vehiculo()
            {
                marca = txtmarca.Text,
                precio = int.Parse(txtprecio.Text),
                color = txtcolor.Text
            };
            admin.Guardar(modelo);
        }
        private void Actualizar()
        {
            vehiculo modelo = new vehiculo()
            {
                Id = int.Parse(txtid.Text),
                marca = txtmarca.Text,
                precio = int.Parse(txtprecio.Text),
                color = txtcolor.Text
            };
            admin.Actualizar(modelo);
        }
        private void Eliminar()
        {
            vehiculo modelo = new vehiculo()
            {
                Id = int.Parse(txtid.Text)
            };
            admin.Eliminar(modelo);
        }
        private void Limpiar()
        {
            txtid.Text     = "";
            txtmarca.Text  = "";
            txtprecio.Text = "";
            txtcolor.Text  = "";                            
        }
        private void btnguardar_Click(object sender, EventArgs e)
        {
            Guardar();
            Consultar();
            Limpiar();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            Consultar();
            Limpiar();
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            Actualizar();
            Consultar();
            Limpiar();
        }
    }
}
