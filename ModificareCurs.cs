using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace catalog_sutedntesc
{
    public partial class ModificareCurs : Form
    {
        CourseClass course = new CourseClass();
        DBconnect connect = new DBconnect();

        public ModificareCurs()
        {
            InitializeComponent();
        }

        private void ModificareCurs_Load(object sender, EventArgs e)
        {
            showData();
        }

        private void button1_editarematerie_modificareCurs_Click(object sender, EventArgs e)
        {
            if((textBox_coddisciplina_modificareCurs.Text=="")||(textBox_nrdecredite_modificareCurs.Text=="")||(textbox_numeMaterie_modificareCurs.Text==""))
            {
                MessageBox.Show("eroare", "Nu se poate actiona", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string nume = textbox_numeMaterie_modificareCurs.Text;
                int nr_de_credite = int.Parse(textBox_nrdecredite_modificareCurs.Text);
                int cod_disciplina = int.Parse(textBox_coddisciplina_modificareCurs.Text);
                int deleted = 1;
                if (course.editareCurs(nume, nr_de_credite, cod_disciplina, deleted))
                    {
                
                     
                    MessageBox.Show("Cursul a fost editat cu succes", "Editare curs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showData();
                }


                else
                {
                    MessageBox.Show("Spatiu gol", "Editare curs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
          private void showData()
        {
            gunaDataGridView3_Modificarecurs.DataSource = course.getCourseList(new MySqlCommand("SELECT * FROM `materiee`", connect.GetConnection));
        }

        private void gunaDataGridView3_Modificarecurs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gunaDataGridView3_Modificarecurs_Click(object sender, EventArgs e)
        {
            textBox_coddisciplina_modificareCurs.Text = gunaDataGridView3_Modificarecurs.CurrentRow.Cells[2].Value.ToString();
            textBox_nrdecredite_modificareCurs.Text = gunaDataGridView3_Modificarecurs.CurrentRow.Cells[1].Value.ToString();
            textbox_numeMaterie_modificareCurs.Text = gunaDataGridView3_Modificarecurs.CurrentRow.Cells[0].Value.ToString();
        }
    }


}
