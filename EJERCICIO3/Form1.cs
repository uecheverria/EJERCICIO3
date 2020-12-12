using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EJERCICIO3
{
    public partial class Form1 : Form
    {
        /*
            Autor: Unai Echeverria
            Pasos realizados:
                1. He modificado el dataGridView añadiendole el origen de datos desde la pestaña de diseño
                2. He eliminado las 4 columnas que habíamos añadido nosotros manualmente del dataGridView
                3. He modificado las columnas añadidas por el origen de datos para hacerlas coincidir con las que teniamos
                    En el dataGridView: Editar columnas > Diseño > Name. Cambiar el que venía por los nuestros (Nombre, Apellido, etc.)
                4. En el tableAdapter (Datos.xsd), he modificado el delete y el update
        */

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_aniadir_Click(object sender, EventArgs e)
        {
            try
            {
                this.contactosTableAdapter.Insert(txt_nombre.Text, txt_apellido.Text, txt_direccion.Text, txt_telefono.Text);
                cargarForm();

                //dgv_contactos.Rows.Add(txt_nombre.Text, txt_apellido.Text, txt_direccion.Text, txt_telefono.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (dgv_contactos.Rows.Count>0)
                {
                    int idSeleccionado = Convert.ToInt32(dgv_contactos.Rows[dgv_contactos.CurrentRow.Index].Cells[0].Value);
                    this.contactosTableAdapter.Delete(idSeleccionado);
                    cargarForm();

                    //dgv_contactos.Rows.RemoveAt(dgv_contactos.CurrentRow.Index);
                }
                else
                {
                    MessageBox.Show("No hay ningún elemento para eliminar", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            try
            {
                int filaSeleccionada = dgv_contactos.CurrentRow.Index;
                int idSeleccionado = Convert.ToInt32(dgv_contactos.Rows[dgv_contactos.CurrentRow.Index].Cells[0].Value);
                this.contactosTableAdapter.Update(txt_nombre.Text, txt_apellido.Text, txt_direccion.Text, txt_telefono.Text, idSeleccionado);
                cargarForm();

                //Para mantener la seleccion que teniamos tras recargar la tabla
                dgv_contactos.Rows[filaSeleccionada].Selected = true;
                dgv_contactos.CurrentCell = dgv_contactos.Rows[filaSeleccionada].Cells[0];

                /* DataGridViewRow fila = dgv_contactos.CurrentRow;
                if (fila == null)
                {
                    return;
                }

                fila.Cells["Nombre"].Value = txt_nombre.Text;
                fila.Cells["Apellidos"].Value = txt_apellido.Text;
                fila.Cells["Direccion"].Value = txt_direccion.Text;
                fila.Cells["Telefono"].Value = txt_telefono.Text;*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            txt_nombre.Clear();
            txt_apellido.Clear();
            txt_direccion.Clear();
            txt_telefono.Clear();
        }

        private void dgv_contactos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow fila = dgv_contactos.CurrentRow;
                if (fila == null)
                {
                    return;
                }

                //El nombre por defecto era este: nombreDataGridViewTextBoxColumn, lo he cambiado por los que usabamos
                txt_nombre.Text = fila.Cells["Nombre"].Value.ToString();        
                txt_apellido.Text = fila.Cells["Apellidos"].Value.ToString();
                txt_direccion.Text = fila.Cells["Direccion"].Value.ToString();
                txt_telefono.Text = fila.Cells["Telefono"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarForm();
        }

        private void cargarForm() {
            this.contactosTableAdapter.Fill(this.datos.Contactos);
        }
    }
}
