using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace catalog_sutedntesc
{
    class CourseClass
    {
        DBconnect connect = new DBconnect();

        public bool insertCourse(string nume, int nr_de_credite, int cod_disciplina, int sters)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `materiee`(`nume`, `nr_de_credite`, `cod_disciplina`, `sters`) VALUES( @nume, @nr_de_credite, @cod_disciplina, @sters)",connect.GetConnection);
           
            command.Parameters.Add("@nume", MySqlDbType.VarChar).Value = nume;
            command.Parameters.Add("@nr_de_credite", MySqlDbType.Int32).Value = nr_de_credite;
            command.Parameters.Add("@cod_disciplina", MySqlDbType.Int32).Value = cod_disciplina;
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

        public DataTable getCourseList(MySqlCommand command)
        {
            command.Connection = connect.GetConnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;

        }
        public bool editareCurs(string nume, int nr_de_credite, int cod_disciplina, int sters)
        {
            MySqlCommand command = new MySqlCommand("UPDATE`materiee`SET `nume`=@nume, `nr_de_credite`=@nr_de_credite, `cod_disciplina`=@cod_disciplina, `sters`=@sters WHERE `cod_disciplina`=@cod_disciplina ", connect.GetConnection);

            command.Parameters.Add("@nume", MySqlDbType.VarChar).Value = nume;
            command.Parameters.Add("@nr_de_credite", MySqlDbType.Int32).Value = nr_de_credite;
            command.Parameters.Add("@cod_disciplina", MySqlDbType.Int32).Value = cod_disciplina;
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
    }
}
