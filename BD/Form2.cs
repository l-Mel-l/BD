using System.Data;
using System.Data.SqlClient;

namespace BD {
    public partial class Form2 : Form {

        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadCRMData();
            LoadSubscriberData();

            cmbService.Items.AddRange(new string[] { "Интернет", "Мобильная связь", "Телевидение", "Видеонаблюдение" });
            cmbStatus.Items.AddRange(new string[] { "Новая", "Требует выезда", "Закрыта" });
            cmbProblemType.Items.AddRange(new string[] { "Консультация", "Тех.обслуживание" });

            cmbService.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            cmbProblemType.SelectedIndex = 0;

            // Добавляем колонку с кнопкой "Закрыть"
            if (!dataGridViewCRM.Columns.Contains("CloseButton"))
            {
                DataGridViewButtonColumn closeButtonColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Действие",
                    Text = "Закрыть",
                    UseColumnTextForButtonValue = true,
                    Name = "CloseButton",
                };
                dataGridViewCRM.Columns.Add(closeButtonColumn);
            }
        }

        private void LoadCRMData()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string query = "SELECT id_Zayav, Creation_Date, AB_Login, Personal_Account, Service, Status, Problem_Type, Problem_Desc, Close_Date FROM CRM";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Привязываем данные к dataGridViewCRM
                dataGridViewCRM.DataSource = dataTable;
            }
        }

        private void LoadSubscriberData()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string query = "  SELECT full_name AS 'ФИО', contract_number AS 'Номер договора', personal_account AS 'Лицевой счёт', equipment AS 'Оборудование' FROM support_users";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewSubscribers.DataSource = dataTable;
            }
        }

        private void btnAddCRM_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string personalAccount = txtPersonalAccount.Text.Trim();
            string service = cmbService.SelectedItem.ToString();
            string status = cmbStatus.SelectedItem.ToString();
            string problemType = cmbProblemType.SelectedItem.ToString();
            string problemDescription = txtProblemDescription.Text.Trim();

            // Проверка полей
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(personalAccount))
            {
                MessageBox.Show("Пожалуйста, заполните обязательные поля: Логин абонента и Лицевой счёт.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = @"INSERT INTO CRM (Creation_Date, AB_Login, Personal_Account, Service, Status, Problem_Type, Problem_Desc)
            VALUES (GETDATE(), @login, @personalAccount, @service, @status, @problemType, @problemDescription";

            /*пометка для себя, если например использовать не параметризованный запрос а
            string query = "INSERT INTO CRM (problem_description) VALUES ('" + userInput + "')";
            то тогда там может сработать sql инъекция, если пользв введёт что-то типо такого '); DROP TABLE CRM; --
            и в итоге запрос будет таки в БД INSERT INTO CRM (problem_description) VALUES (''); DROP TABLE CRM; --') */


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@personalAccount", personalAccount);
                command.Parameters.AddWithValue("@service", service);
                command.Parameters.AddWithValue("@status", status);
                command.Parameters.AddWithValue("@problemType", problemType);
                command.Parameters.AddWithValue("@problemDescription", problemDescription);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Заявка успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCRMData(); // Обновляю таблицу с данными
                    }
                    else
                    {
                        MessageBox.Show("Не удалось добавить заявку. Попробуйте снова.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewCRM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewCRM.Columns["CloseButton"].Index && e.RowIndex >= 0)
            {
                // Получаем ID заявки
                int idZayav = Convert.ToInt32(dataGridViewCRM.Rows[e.RowIndex].Cells["id_Zayav"].Value);

                // Закрываем заявку
                CloseCRMRequest(idZayav);
            }
        }

        private void CloseCRMRequest(int idZayav)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Получаем данные из CRM
                    string selectQuery = "SELECT * FROM CRM WHERE id_Zayav = @id_Zayav";
                    SqlCommand selectCommand = new SqlCommand(selectQuery, connection, transaction);
                    selectCommand.Parameters.AddWithValue("@id_Zayav", idZayav);

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        // Читаем данные заявки
                        DateTime creationDate = Convert.ToDateTime(reader["creation_date"]);
                        string abonentLogin = reader["AB_Login"].ToString();
                        string personalAccount = reader["personal_account"].ToString();
                        string service = reader["service"].ToString();
                        string problemType = reader["problem_type"].ToString();
                        string problemDescription = reader["problem_desc"].ToString();
                        DateTime closingDate = DateTime.Now;

                        reader.Close();

                        // Копируем данные в Archive
                        string insertArchiveQuery = @"
                        INSERT INTO Archive (id_Zayav, creation_date, abonent_login, personal_account, service, problem_type, problem_description, closing_date)
                        VALUES (@id_Zayav, @creationDate, @abonentLogin, @personalAccount, @service, @problemType, @problemDescription, @closingDate)";
                        SqlCommand insertCommand = new SqlCommand(insertArchiveQuery, connection, transaction);
                        insertCommand.Parameters.AddWithValue("@id_Zayav", idZayav);
                        insertCommand.Parameters.AddWithValue("@creationDate", creationDate);
                        insertCommand.Parameters.AddWithValue("@abonentLogin", abonentLogin);
                        insertCommand.Parameters.AddWithValue("@personalAccount", personalAccount);
                        insertCommand.Parameters.AddWithValue("@service", service);
                        insertCommand.Parameters.AddWithValue("@problemType", problemType);
                        insertCommand.Parameters.AddWithValue("@problemDescription", problemDescription);
                        insertCommand.Parameters.AddWithValue("@closingDate", closingDate);

                        insertCommand.ExecuteNonQuery();

                        // Удаляем запись из CRM
                        string deleteCRMQuery = "DELETE FROM CRM WHERE id_Zayav = @id_Zayav";
                        SqlCommand deleteCommand = new SqlCommand(deleteCRMQuery, connection, transaction);
                        deleteCommand.Parameters.AddWithValue("@id_Zayav", idZayav);

                        deleteCommand.ExecuteNonQuery();

                        // Фиксируем транзакцию
                        transaction.Commit();

                        MessageBox.Show("Заявка успешно закрыта и перенесена в архив.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Обновляем данные в DataGridView
                        LoadCRMData();
                    }
                    else
                    {
                        reader.Close();
                        throw new Exception("Заявка не найдена.");
                    }
                }
                catch (Exception ex)
                {
                    // Если ошибка, откатываем транзакцию
                    transaction.Rollback();
                    MessageBox.Show($"Ошибка при закрытии заявки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
