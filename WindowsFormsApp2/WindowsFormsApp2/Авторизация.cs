    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Авторизация : Form
    {
        static string dbname = @"KOMPUTER\SQLEXPRESS";
        public static SqlConnection sqlcon = new SqlConnection(@"Data Source=" + dbname + ";Initial Catalog=Zoo1;Integrated Security=True");
        public static string la ="";

        public Авторизация()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Авторизация.la = getLogin();
            var password = getPassowrd();
            var userData = new User { };
            try
            {
                userData = getUserData(Авторизация.la);
            }
            catch (Exception)
            {
                MessageBox.Show("Данные введенны неверно!");
                return;
            }
            

            if (userData.password != password)
            {
                MessageBox.Show("Данные введенны неверно!");
                return;
            }
            Авторизация.sqlcon.Close();
            MessageBox.Show($"Добро Пожаловать {userData.name}!");
            ActiveForm.Hide();
            switch (userData.role)
            {
                case 1:
                    new Сотрудник().ShowDialog();
                    break;
                case 2:
                    new МлМенеджер().ShowDialog();
                    break;
                case 3:
                    new СтМенеджер().ShowDialog();
                    break;
                case 4:
                    new Директор().ShowDialog();
                    break;
            }
            Close();
        }

        private string getLogin()
        {
            return textBox1.Text;
        }

        private string getPassowrd()
        {
            // TODO: err if pass is nil
            return maskedTextBox1.Text;
        }

        private User getUserData(string login)
        {
            Авторизация.sqlcon.Open();
            SqlDataReader dataReader = new SqlCommand($"SELECT Пароль, id_Должности, ФИО FROM Пользователь WHERE Пользователь.Логин = '{login}'", sqlcon).ExecuteReader();
            if (!dataReader.Read())
            {
                dataReader.Close();
                Авторизация.sqlcon.Close();
                throw new Exception("no rows");
            }

            var user = new User
            {
                password = dataReader.GetString(0),
                role = (int)dataReader.GetValue(1),
                name = dataReader.GetString(2)
            };

            dataReader.Close();
            Авторизация.sqlcon.Close();
            return user;
        }
    }

    struct User
    {
        public string password;
        public int role;
        public string name;
    }
}
