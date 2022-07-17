using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EarthworksCalculation
{
    public partial class EWC : Form // ЭТО ОСНОВНАЯ ПРОГРАММА
    {
        public EWC()
        {
            InitializeComponent();
        }

        // Инициализация имени Сервера через переменную SERVER - ГОТОВО

        string Server = ("Integrated Security = SSPI;"
        + "Persist Security Info = False;"
        + "Initial Catalog = СableLines;"
        //+ "Data Source = UTOCHKA-150879\\SQLEXPRESS"); // рабочий сервер
        + "Data Source = DESKTOP-UD\\SQLEXPRESS"); // домашний сервер

        // АДМИНИСТРАТОР. Чтение ВСЕХ траншей из базы - ГОТОВО
        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Server)) // переменная имени сервера

            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Excavation", conn))
                {
                    using (SqlDataReader read = cmd.ExecuteReader()) // чтение из базы данных
                    {
                        while (read.Read())
                        {
                            TrencList.Items.Add("   "
                                + read["TrenchType"] + "           "
                                + read["TrenchDepth"] + "              "
                                + read["TrenchWidth"] + "                  "
                                + read["SandFilling"] + "                      "
                                + read["SandBackfilling"]);
                        }
                    }
                }
                conn.Close();
            }
        }

        // АДМИНИСТРАТОР. Сортировка траншей в списке на экране - ГОТОВО
        private void button3_Click_1(object sender, EventArgs e) 
        {
            TrencList.Sorted = true;
        }

        // АДМИНИСТРАТОР. Полная очистка базы данных - ГОТОВО
        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Server)) // переменная имени сервера
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Excavation", conn))
                {
                    using (SqlDataReader read = cmd.ExecuteReader())
                    {

                    }
                }
                conn.Close();
            }
        }
        // АДМИНИСТРАТОР. Удаление из списка на экране - ГОТОВО, НО В ПОСЛЕДСТВИИ РАСШИРИТЬ ФУНКЦИОНАЛ
        private void button5_Click(object sender, EventArgs e)
        {
            while (TrencList.CheckedIndices.Count > 0) TrencList.Items.RemoveAt(TrencList.CheckedIndices[0]);

        }

        // ПОЛЬЗОВАТЕЛЬ. Добавить новую пользовательскую траншею в базу данных - ГОТОВО
        private void button6_Click(object sender, EventArgs e)
        {
            TrencList_User.Items.Add("       "
                + textBox1.Text + "            "
                + textBox2.Text + "              "
                + textBox3.Text + "                    "
                + textBox4.Text + "                             "
                + textBox5.Text);

            using (SqlConnection conn = new SqlConnection(Server)) // переменная имени сервера
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Excavation"
                    +"(TrenchType, TrenchDepth, TrenchWidth, SandFilling, SandBackfilling)"
                    + "VALUES ('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"')", conn))

                {
                    using (SqlDataReader read = cmd.ExecuteReader())
                    {

                    }
                }
                conn.Close();
            }
        }

        // ПОЛЬЗОВАТЕЛЬ. Выбрать траншею из базы данных по типу и загрузить в таблицу - ГОТОВО
        private void button7_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Server)) // переменная имени сервера

            {
                string INS = textBox6.Text;

                string sql = "SELECT * FROM dbo.Excavation WHERE TrenchType = '" + textBox6.Text + "'";

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader read = cmd.ExecuteReader()) // чтение из базы данных
                    {
                        while (read.Read())
                        {
                            checkedListBox1.Items.Add("   "
                                + read["TrenchType"] + "           "
                                + read["TrenchDepth"] + "              "
                                + read["TrenchWidth"] + "                  "
                                + read["SandFilling"] + "                      "
                                + read["SandBackfilling"]);
                        }
                    }
                }
                conn.Close();
            }
        }
    }
}
