using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Директор : Form
    {
        public Директор()
        {
            InitializeComponent();
        }

        private void Директор_Load(object sender, EventArgs e)
        {
           
            updDB();
        }
        public void updDB()
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zooDataSet.Статус". При необходимости она может быть перемещена или удалена.
            this.статусTableAdapter.Fill(this.zooDataSet.Статус);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zooDataSet.Пользователь". При необходимости она может быть перемещена или удалена.
            this.пользовательTableAdapter.Fill(this.zooDataSet.Пользователь);

            DataSet ds = new DataSet();
            Авторизация.sqlcon.Open();

            new SqlDataAdapter(
                $@"SELECT Логин, Паспорт, ФИО, Должность.Наименование, Статус.Наименование FROM Пользователь
                   join Должность on id_должности = Должность.id
                   join Статус on id_Статуса = Статус.id",
                Авторизация.sqlcon).
                Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[3].HeaderText = "Должность";
            dataGridView1.Columns[4].HeaderText = "Статус";

            ds = new DataSet();

            new SqlDataAdapter(
                $@"SELECT Заказ_корма.Логин_пользователя, Корм.Наименование, Дата, Сумма, Заказ_корма.Количество 
                   from Заказ_корма
                   join Корм on Корм.id = id_корма",
                Авторизация.sqlcon).
                Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            dataGridView2.Columns[1].HeaderText = "Корм";


            ds = new DataSet();
            new SqlDataAdapter(
                $@"SELECT Наименование, Цена, Количество FROM Корм",
                Авторизация.sqlcon).
                Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];

            Авторизация.sqlcon.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Регистрация f = new Регистрация();
            f.ShowDialog();
            updDB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Авторизация.sqlcon.Open();
            try
            {
                new SqlDataAdapter(
                $@"UPDATE Пользователь SET
                    id_Статуса = {statusInput.SelectedValue}
                    WHERE Логин = '{loginIput.SelectedValue}'",
                Авторизация.sqlcon).
                Fill(new DataSet());
                MessageBox.Show("Статус работника успешно изменен!");
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите сотрудника и статус");
                return;
            }
            finally
            {
                Авторизация.sqlcon.Close();
                updDB();
            }
        }
    }
}
