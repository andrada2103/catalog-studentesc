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
    public partial class AdaugareCursuri : Form
    {
        CourseClass course = new CourseClass();
        DBconnect connect = new DBconnect();

        public AdaugareCursuri()
        {
            InitializeComponent();
        }

        private void AdaugareCursuri_Load(object sender, EventArgs e)
      
        {
            showData();

        }

        private void button1_adaugarematerie_Click(object sender, EventArgs e)
        {
            if ((textBox_coddisciplina.Text == "") || (textbox_numeMaterie.Text == "") || (textBox_nrdecredite.Text == ""))
            {
                MessageBox.Show("Campuri goale", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string nume = textbox_numeMaterie.Text;
                int numar_de_credite = int.Parse(textBox_nrdecredite.Text);
                int cod_disciplina = int.Parse(textBox_coddisciplina.Text);
                int sters = 1;
                if (course.insertCourse(nume, numar_de_credite, cod_disciplina, sters))
                {
                    MessageBox.Show("Un nou curs a fost adaugat", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showData();
                }
                else
                {
                    MessageBox.Show("Un nou curs a fost adaugat", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void showData()
        {
            gunaDataGridView2_adaugarecurs.DataSource = course.getCourseList(new MySqlCommand("SELECT * FROM `materiee`", connect.GetConnection));
        }

        private void button1_adaugarematerie_Click_1(object sender, EventArgs e)
        {
            if ((textBox_coddisciplina.Text == "") || (textbox_numeMaterie.Text == "") || (textBox_nrdecredite.Text == ""))
            {
                MessageBox.Show("Campuri goale", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string nume = textbox_numeMaterie.Text;
                int numar_de_credite = int.Parse(textBox_nrdecredite.Text);
                int cod_disciplina = int.Parse(textBox_coddisciplina.Text);
                int sters = 1;
                if (course.insertCourse(nume, numar_de_credite, cod_disciplina, sters))
                {
                    MessageBox.Show("Un nou curs a fost adaugat", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showData();
                }
                else
                {
                    MessageBox.Show("Un nou curs a fost adaugat", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gunaDataGridView2_adaugarecurs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    } 
}
