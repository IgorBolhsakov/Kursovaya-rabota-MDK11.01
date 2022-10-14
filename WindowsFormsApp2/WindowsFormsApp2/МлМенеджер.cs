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
    public partial class МлМенеджер : Form
    {
        public МлМенеджер()
        {
            InitializeComponent();
        }

        private void МлМенеджер_Load(object sender, EventArgs e)
        {
            updDB();
        }
        public static DataSet ds = new DataSet();
        public void updDB()
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zooDataSet.Корм". При необходимости она может быть перемещена или удалена.
            this.кормTableAdapter.Fill(this.zooDataSet.Корм);

            Авторизация.sqlcon.Open();
            ds = new DataSet();

            // Склад
            new SqlDataAdapter("select Наименование, Цена, Количество from Корм", Авторизация.sqlcon).Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            
            ds = new DataSet();
            // История Расхода
            new SqlDataAdapter(
                @"SELECT Логин_пользователя, Дата_и_время, Корм.Наименование, История_расхода_корма.Количество, Сумма 
                  FROM История_расхода_корма
                  join Корм on Корм.id = id_корма",
                Авторизация.sqlcon).
                Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
            dataGridView3.Columns[2].HeaderText = "Корм";

            Авторизация.sqlcon.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var num = costInputForUpdateCost.Value.ToString().Replace(",",".");
            Авторизация.sqlcon.Open();
            ds = new DataSet();
            new SqlDataAdapter(
                $@"update Корм set Цена = {num} 
                   where Корм.id = {feedInput.SelectedValue}",
                Авторизация.sqlcon).
                Fill(ds);
            Авторизация.sqlcon.Close();
            MessageBox.Show("Цена Успешно изменена!");
            updDB();
        }
        public string sum = "0";
        private void button2_Click(object sender, EventArgs e)
        {
            Авторизация.sqlcon.Open();
            ds = new DataSet();
            new SqlDataAdapter(
                $@"update Корм set Количество = Количество + {feedCount.Value} 
                   where id = {feedInput.SelectedValue}",
                Авторизация.sqlcon).
                Fill(ds);
            ds = new DataSet();
            new SqlDataAdapter(
                $@"INSERT INTO Заказ_корма(Логин_пользователя, id_Корма, Дата, Сумма, Количество)
                   VALUES('{Авторизация.la}',{feedInput.SelectedValue}, '{DateTime.Today.ToString()}', {sum}, {feedCount.Value})",
                Авторизация.sqlcon).
                Fill(ds);
            Авторизация.sqlcon.Close();
            MessageBox.Show("Корм успешно заказан!");
            updDB();
        }
        public double cost = 0;
        private void feedCount_ValueChanged(object sender, EventArgs e)
        {
            sum = (Convert.ToDouble(feedCount.Value) * cost).ToString().Replace(",",".");
            label5.Text = $"Сумма: {sum} р.";
        }

        private void feedInput_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                Авторизация.sqlcon.Open();
                SqlDataReader r = new SqlCommand($"SELECT Корм.Цена FROM Корм WHERE Корм.id = {feedInput.SelectedValue}", Авторизация.sqlcon).ExecuteReader();
                r.Read();
                cost = Convert.ToDouble(r.GetValue(0));
                r.Close();

            }
            catch (Exception)
            {

            }
            finally
            {
                Авторизация.sqlcon.Close();
            }
        }

        private void costInputForUpdateCost_ValueChanged(object sender, EventArgs e)
        {
            costInputForUpdateCost.Value = Math.Round(costInputForUpdateCost.Value, 2);
        }
    }
}
