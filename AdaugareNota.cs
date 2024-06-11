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
    public partial class AdaugareNota : Form
    {
        CourseClass course = new CourseClass();
        DBconnect connect = new DBconnect();
        NotaClass scores = new NotaClass();
        public AdaugareNota()
        {
            InitializeComponent();
        }

        private void AdaugareNota_Load(object sender, EventArgs e)
        {
            comboBox1_IDcurs.DataSource = course.getCourseList(new MySqlCommand("SELECT `cod_disciplina`  FROM `materiee`", connect.GetConnection));
            comboBox1_IDcurs.DisplayMember = "cod_disciplina";
            comboBox1_IDcurs.ValueMember = "cod_disciplina";
            showData();

        }

        private void button1_adaugareNOTA_Click(object sender, EventArgs e)
        {
            if ((textBox_nota_AdaugareNota.Text == "") || (textbox_studentIDD.Text == ""))
            {
                MessageBox.Show("eroare", "Nu se poate actiona", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int cod_disciplina = int.Parse(comboBox1_IDcurs.Text);
                int nr_de_inregistrare = int.Parse(textbox_studentIDD.Text);
                int nota = int.Parse(textBox_nota_AdaugareNota.Text);
                int deleted = 1;
                if (scores.insertScore(  cod_disciplina, nr_de_inregistrare, nota, deleted))
                {


                    MessageBox.Show("Nota a fost adaugata", "Nota", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showData();
                }


                else
                {
                    MessageBox.Show("Spatiu gol", "Nota", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void showData()
        {
            gunaDataGridView3_AdaugareNota.DataSource = course.getCourseList(new MySqlCommand("SELECT `nume`,`cod_disciplina` FROM `materiee`",connect.GetConnection));

        }

        private void comboBox1_IDcurs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
