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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class СтМенеджер : Form
    {
        public СтМенеджер()
        {
            InitializeComponent();
        }
        public static DataSet ds = new DataSet();
        public void updDB()
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zooDataSet.Животное". При необходимости она может быть перемещена или удалена.
            this.животноеTableAdapter.Fill(this.zooDataSet.Животное);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zooDataSet.Вид_животного". При необходимости она может быть перемещена или удалена.
            this.вид_животногоTableAdapter.Fill(this.zooDataSet.Вид_животного);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zooDataSet.Вальер". При необходимости она может быть перемещена или удалена.
            this.вальерTableAdapter.Fill(this.zooDataSet.Вальер);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zooDataSet.Корм". При необходимости она может быть перемещена или удалена.
            this.кормTableAdapter.Fill(this.zooDataSet.Корм);

            Авторизация.sqlcon.Open();

            ds = new DataSet();
            new SqlDataAdapter(
                $@"SELECT id, Размер, Описание, Количество_животных_внутри FROM Вальер",
                Авторизация.sqlcon).
                Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "Номер вольера";

            ds = new DataSet();
            new SqlDataAdapter("SELECT Наименование, Цена, Количество FROM Корм", Авторизация.sqlcon).Fill(ds);

            dataGridView2.DataSource = ds.Tables[0];

            ds = new DataSet();
            new SqlDataAdapter(
                $@"SELECT Вид_животного.Наименование, Корм.Наименование FROM Вид_животного 
                   JOIN Корм on Корм.id = Вид_животного.id_корма",
                Авторизация.sqlcon).
                Fill(ds);
            
            dataGridView3.DataSource = ds.Tables[0];
            dataGridView3.Columns[1].HeaderText = "Корм";

            ds = new DataSet();
            new SqlDataAdapter(
                @"SELECT Кличка, id_вольера, Вид_животного.Наименование FROM Животное
                  JOIN Вид_животного ON Вид_животного.id = id_вида_животного", 
                Авторизация.sqlcon).
                Fill(ds);
            
            dataGridView4.DataSource = ds.Tables[0];
            dataGridView4.Columns[1].HeaderText = "Номер вольера";
            dataGridView4.Columns[2].HeaderText = "Вид животного";
            Авторизация.sqlcon.Close();
        }

        private void СтМенеджер_Load(object sender, EventArgs e)
        {
            
            updDB();
            comboBox3.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (feedInputForCreateFeed.Text.Length < 1)
            {
                MessageBox.Show("Заполните название корма!");
                return;
            }
                
            Авторизация.sqlcon.Open();
            ds = new DataSet();
            try
            {
                new SqlDataAdapter(
                $@"INSERT INTO Корм(Наименование, Количество, Цена)
                   VALUES('{feedInputForCreateFeed.Text}', 0, 0)",
                Авторизация.sqlcon).
                Fill(ds);
                MessageBox.Show("Корм был успешно добавлен");
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка при добавлении");
            }
            
            Авторизация.sqlcon.Close();
            updDB();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!(sizeForCreateValier.Text.Length > 0))
            {
                MessageBox.Show("Заполните размер вольера!");
                return;
            }

            Авторизация.sqlcon.Open();
            ds = new DataSet();
            try
            {
                new SqlDataAdapter(
                $@"INSERT INTO Вальер(Размер, Описание, [Количество_животных_внутри]) 
                   VALUES ('{sizeForCreateValier.Text}','{DescriptionForCreateValier.Text}',0)",
                Авторизация.sqlcon).
                Fill(ds);
                MessageBox.Show("Новый Вольер был успешно добавлен");
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка при добавлении");
            }
            Авторизация.sqlcon.Close();
            updDB();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!(animalNameInputForCreate.Text.Length > 0) || !(feedInputForAnimalCreate.Text.Length > 0))
            {
                MessageBox.Show("Заполните все поля для добавления!");
                return;
            }

            Авторизация.sqlcon.Open();
            ds = new DataSet();
            try
            {
                new SqlDataAdapter(
                $@"INSERT INTO Вид_животного(Наименование, id_Корма)
                   VALUES('{animalNameInputForCreate.Text}', {feedInputForAnimalCreate.SelectedValue})",
                Авторизация.sqlcon).
                Fill(ds);
                MessageBox.Show("Новый вид животного был успешно добавлен");
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка при добавлении");
            }
            
            Авторизация.sqlcon.Close();
            updDB();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!(textBox4.Text.Length > 0) || !(comboBox3.Text.Length > 0) || !(comboBox4.Text.Length > 0))
            {
                MessageBox.Show("Заполните все поля для добавления!");
                return;
            }
            Авторизация.sqlcon.Open();
            ds = new DataSet();
            try
            {
                new SqlDataAdapter(
                    $@"INSERT INTO Животное(Кличка, id_вольера, [id_вида_животного])
                       VALUES('{textBox4.Text}', {comboBox3.SelectedValue}, {comboBox4.SelectedValue})",
                    Авторизация.sqlcon).
                    Fill(ds);
                MessageBox.Show("Новое животное было успешно добавлено в Базу Данных!");
            }
            catch (Exception)
            {
                MessageBox.Show("Данная Кличка уже занята!");
            }
            ds = new DataSet();
            new SqlDataAdapter(
                $@"UPDATE Вальер SET [Количество_животных_внутри] = [Количество_животных_внутри] + 1
                   WHERE id = {comboBox3.SelectedValue}",
                Авторизация.sqlcon).Fill(ds);

            Авторизация.sqlcon.Close();
            updDB();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!(comboBox5.Text.Length > 0))
            {
                MessageBox.Show("Выберите животное для удаления!");
                return;
            }
            Авторизация.sqlcon.Open();
            ds = new DataSet();
            new SqlDataAdapter(
                $@"UPDATE Вальер SET [Количество_животных_внутри] = [Количество_животных_внутри] - 1
                   WHERE id = {getValierNum()}",
                Авторизация.sqlcon).Fill(ds);

            ds = new DataSet();
            new SqlDataAdapter($"DELETE FROM Животное where id = {comboBox5.SelectedValue}", Авторизация.sqlcon).Fill(ds);
            
            Авторизация.sqlcon.Close();
            MessageBox.Show("Животное было успешно удалено из Базы Данных!");
            updDB();

        }
        private int getValierNum()
        {
            SqlDataReader r = new SqlCommand($"SELECT id_вольера FROM Животное where id = {comboBox5.SelectedValue}", Авторизация.sqlcon).ExecuteReader();
            r.Read();
            int id = (int)r.GetValue(0);
            r.Close();
            return id;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Авторизация.sqlcon.Open();
            SqlDataReader r = new SqlCommand(
                $"SELECT Описание FROM Вальер where id = {comboBox3.SelectedValue}", 
                Авторизация.sqlcon).
                ExecuteReader();
            r.Read();
            textBox1.Text = r.GetString(0);
            r.Close();
            Авторизация.sqlcon.Close();
        }
    }
}
