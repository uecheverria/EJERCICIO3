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
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_aniadir_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_contactos.Rows.Add(txt_nombre.Text, txt_apellido.Text, txt_direccion.Text, txt_telefono.Text);
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
                    dgv_contactos.Rows.RemoveAt(dgv_contactos.CurrentRow.Index);
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
                DataGridViewRow fila = dgv_contactos.CurrentRow;
                if (fila == null)
                {
                    return;
                }

                fila.Cells["Nombre"].Value = txt_nombre.Text;
                fila.Cells["Apellidos"].Value = txt_apellido.Text;
                fila.Cells["Direccion"].Value = txt_direccion.Text;
                fila.Cells["Telefono"].Value = txt_telefono.Text;
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
    }
}
