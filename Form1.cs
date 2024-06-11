using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catalog_sutedntesc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void customizeDesign()
        {
            panel_student.Visible = false;
            panel_curs.Visible = false;
            panel_nota.Visible = false;

        }
        private void hidesubmenu()
        {
            if (panel_student.Visible == true)
                panel_student.Visible = false;
            if (panel_curs.Visible == true)
                panel_curs.Visible = false;
            if (panel_nota.Visible == true)
                panel_nota.Visible = false;
        }

        private void showSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hidesubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }
        

        

        private void buton_student_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_student);
        }
        #region Studentmenu
        private void student_adauga_Click(object sender, EventArgs e)
        {
            openChildForm(new InregistrareStudenti());
            hidesubmenu();

        }

        

        private void student_modificare_Click(object sender, EventArgs e)
        {
            openChildForm(new ModificareStudent());
            hidesubmenu();


        }

        private void student_excel_Click(object sender, EventArgs e)
        {
            hidesubmenu();

        }
        #endregion Studentmenu
        private void curs_buton_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_curs);
        }
        #region Cursmenu
        private void curs_adauga_Click(object sender, EventArgs e)
        {
            openChildForm(new AdaugareCursuri());
            hidesubmenu();

        }

        

        private void curs_modificare_Click(object sender, EventArgs e)
        {
            openChildForm(new ModificareCurs());
            hidesubmenu();

        }

        private void curs_excel_Click(object sender, EventArgs e)
        {
            hidesubmenu();

        }
        #endregion Cursmenu
        private void buton_nota_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_nota);
        }
        #region Notamenu
        private void nota_adauga_Click(object sender, EventArgs e)
        {
            openChildForm(new AdaugareNota());
            hidesubmenu();

        }

        private void nota_modificare_Click(object sender, EventArgs e)
        {
            hidesubmenu();
        }

        private void nota_excel_Click(object sender, EventArgs e)
        {
            hidesubmenu();
        }

        
        #endregion Notamenu

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private Form activateForm = null;
        private void openChildForm(Form childForm)
        {
            if (activateForm != null)
                activateForm.Close();
            activateForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_main.Controls.Add(childForm);
            panel_main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
