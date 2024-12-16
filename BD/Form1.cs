using System.Text;
using System.Security.Cryptography;
using CRMApp;

namespace BD {
    public partial class Form1 : Form {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbRole.Items.Add("оператор");
            cmbRole.SelectedIndex = 0;
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;
            string role = cmbRole.SelectedItem.ToString();

            string passwordHash = HashPassword(password);

            // Проверяем в БД
            bool isValidUser = DatabaseHelper.ValidateUser(login, passwordHash, role);

            if (isValidUser)
            {
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверные данные для входа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
