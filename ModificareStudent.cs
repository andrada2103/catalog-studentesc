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
    public partial class ModificareStudent : Form
    {
        StudentClass student = new StudentClass();
        DBconnect connect = new DBconnect();

        public ModificareStudent()
        {
            InitializeComponent();
        }

        private void ModificareStudent_Load(object sender, EventArgs e)
        {
            showTable(); 
        }
        public void showTable()
        {
            gunaDataGridView2_modificarestudent.DataSource = student.getStudentlist();
            gunaDataGridView2_modificarestudent.RowTemplate.Height = 50;
        }

        private void gunaDataGridView2_modificarestudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_nrmatricol2.Text = gunaDataGridView2_modificarestudent.CurrentRow.Cells[0].Value.ToString();
            textBox_num2.Text = gunaDataGridView2_modificarestudent.CurrentRow.Cells[1].Value.ToString();
            textBox_prenume2.Text = gunaDataGridView2_modificarestudent.CurrentRow.Cells[2].Value.ToString();
        }
        bool verify()
        {
            if ((textBox_num2.Text == "") || (textBox_prenume2.Text == "") || (textBox_nrmatricol2.Text) == "")
                return false;
            return true;

        }
        
private void button1_editare_Click(object sender, EventArgs e)
        {
            int nr_matricol = int.Parse(textBox_nrmatricol2.Text);
            string Nume = textBox_num2.Text;
            string Prenume = textBox_prenume2.Text;
            int sters = 1;
            if (verify())
            {
                try
                {
                    if (student.Modificare(nr_matricol, Nume, Prenume, sters))
                    {
                        MessageBox.Show("S-a modificat numele studentului!", "Adaugare Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    showTable();
                }
                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Spatiu liber", "Adaugare student", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }


}
