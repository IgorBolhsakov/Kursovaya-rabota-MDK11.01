using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Сотрудник : Form
    {
        public Сотрудник()
        {
            InitializeComponent();
        }

        public void updDB()
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zooDataSet.Корм". При необходимости она может быть перемещена или удалена.
            this.кормTableAdapter.Fill(this.zooDataSet.Корм);
            Авторизация.sqlcon.Open();

            DataSet ds = new DataSet();
            new SqlDataAdapter($"SELECT Наименование, Цена, Количество FROM Корм", Авторизация.sqlcon).Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            Авторизация.sqlcon.Close();
        }
        private void Сотрудник_Load(object sender, EventArgs e)
        {
            updDB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value < 1)
            {
                MessageBox.Show("Введите количество корма");
                return;
            }
            DataSet ds = new DataSet();
            Авторизация.sqlcon.Open();
            SqlDataReader r = new SqlCommand($"SELECT Количество, Цена FROM Корм where id = {comboBox1.SelectedValue}", Авторизация.sqlcon).ExecuteReader();
            r.Read();
            int count = (int)r.GetValue(0);
            double cost = Convert.ToDouble(r.GetValue(1));
            r.Close();
            Авторизация.sqlcon.Close();
            if(count < (int)numericUpDown1.Value)
            {
                MessageBox.Show("На складе не хватает корма!");
                return;
            }

            Авторизация.sqlcon.Open();
            new SqlDataAdapter(
                $@"update Корм set Количество = Количество - {numericUpDown1.Value} 
                   where id = {comboBox1.SelectedValue}",
                Авторизация.sqlcon).
                Fill(ds);

            string sum = (Convert.ToDouble(numericUpDown1.Value) * cost).ToString().Replace(",",".");
            ds = new DataSet();
            new SqlDataAdapter(
                $@"insert into История_расхода_корма(Логин_пользователя, Дата_и_время, id_корма, Количество, Сумма)
                   VALUES('{Авторизация.la}', '{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}', {comboBox1.SelectedValue},
                           {numericUpDown1.Value.ToString().Replace(",",".")},{sum})",
                Авторизация.sqlcon).
                Fill(ds);
            Авторизация.sqlcon.Close();
            MessageBox.Show($"Было успешно взято {numericUpDown1.Value} кг корма \nНа сумму в {sum} руб.");
            updDB();
        }

    }
}
