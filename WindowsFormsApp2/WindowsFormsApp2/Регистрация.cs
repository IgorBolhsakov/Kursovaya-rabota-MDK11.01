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
    public partial class Регистрация : Form
    {
        public Регистрация()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (loginInput.Text == "" || passwordInput.Text == "" || passInput.Text == "" || nameInput.Text == "" || roleInput.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            Авторизация.sqlcon.Open();
            try
            {
                new SqlDataAdapter(
                    $@"INSERT INTO Пользователь(Логин, Пароль, id_Должности, id_Статуса, ФИО, Паспорт)
                       VALUES('{loginInput.Text}', '{passwordInput.Text}', {roleInput.SelectedValue}, 1, '{nameInput.Text}', '{passInput.Text}')", 
                    Авторизация.sqlcon).
                    Fill(new DataSet());
                Авторизация.sqlcon.Close();
                MessageBox.Show("Запись прошла успешно!");
                ActiveForm.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Такой Логин уже существует");
                Авторизация.sqlcon.Close();
            }
        }

        private void Регистрация_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zooDataSet.Должность". При необходимости она может быть перемещена или удалена.
            this.должностьTableAdapter.Fill(this.zooDataSet.Должность);
        }
    }
}
