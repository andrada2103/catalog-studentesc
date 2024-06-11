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
    public partial class InregistrareStudenti : Form
    {
        StudentClass Student = new StudentClass();
        public InregistrareStudenti()
        {
            InitializeComponent();
        }




        private void label2_Click(object sender, EventArgs e)
        {

        }

        bool verify()
        {
            if((textBox_nume.Text=="")||(textBox_prenume.Text=="")||(textBox_nrmatricol.Text==""))
                    return false;
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int nr_matricol = int.Parse(textBox_nrmatricol.Text);
            string Nume=textBox_nume.Text;
            string Prenume = textBox_prenume.Text;
            int sters = 1;
            if (verify())
            {
                try
                {
                    if (Student.insertStudent(nr_matricol, Nume, Prenume, sters))
                    {
                        MessageBox.Show("Student nou adaugat!", "Adaugare Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
       
        private void InregistrareStudenti_Load(object sender, EventArgs e)
        {
            showTable();
        }
        public void showTable()
        {
            gunaDataGridView1.DataSource = Student.getStudentlist();
            gunaDataGridView1.RowTemplate.Height = 50;
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
