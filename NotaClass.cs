using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace catalog_sutedntesc
{
    class NotaClass
    {
        DBconnect connect = new DBconnect();

    public bool insertScore(int nr_de_inregistrare, int cod_disciplina,int nota,int deleted)

        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `register`(`cod_disciplina`, `nr_de_inregistrare`, `nota`, `sters`) VALUES(  @cod_disciplina,@nr_de_inregistrare,@nota, @sters)", connect.GetConnection);

            command.Parameters.Add("@nota", MySqlDbType.Int32).Value = nota;
            command.Parameters.Add("@nr_de_inregistrare", MySqlDbType.Int32).Value = nr_de_inregistrare;
            command.Parameters.Add("@cod_disciplina", MySqlDbType.Int32).Value = cod_disciplina;
            command.Parameters.Add("@sters", MySqlDbType.Int32).Value = deleted;
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
