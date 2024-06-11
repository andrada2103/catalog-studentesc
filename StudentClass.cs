using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace catalog_sutedntesc
{
    class StudentClass
    {
        DBconnect connect = new DBconnect();
        public bool insertStudent(int nr_matricol,string Nume,string Prenume,int sters)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `student`(`nr_matricol`, `Nume`, `Prenume`, `sters`) VALUES (@nr_matricol,@Nume,@Prenume,@sters)",connect.GetConnection);
          command.Parameters.Add("@nr_matricol",MySqlDbType.Int32).Value=nr_matricol;
            command.Parameters.Add("@Nume", MySqlDbType.VarChar).Value = Nume;
            command.Parameters.Add("@Prenume", MySqlDbType.VarChar).Value = Prenume;
            command.Parameters.Add("@sters", MySqlDbType.Int32).Value = sters;

            connect.openConnect();
            if(command.ExecuteNonQuery()==1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }
        }
        public bool Modificare(int nr_matricol, string Nume, string Prenume, int sters)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `student` SET `nr_matricol`=@nr_matricol,`Nume`=@Nume,`Prenume`=@Prenume,`sters`=@sters WHERE  `nr_matricol`=@nr_matricol", connect.GetConnection);
            command.Parameters.Add("@nr_matricol", MySqlDbType.Int32).Value = nr_matricol;
            command.Parameters.Add("@Nume", MySqlDbType.VarChar).Value = Nume;
            command.Parameters.Add("@Prenume", MySqlDbType.VarChar).Value = Prenume;
            command.Parameters.Add("@sters", MySqlDbType.Int32).Value = sters;

            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }
        }

        public DataTable getStudentlist()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `student`", connect.GetConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;


        }
    }
}
