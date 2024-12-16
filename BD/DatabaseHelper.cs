using System;
using System.Data;
using System.Data.SqlClient;

namespace CRMApp {
    public static class DatabaseHelper {
        private static string GetConnectionString()
        {
            // Получаем строку подключения из App.config
            return System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public static bool ValidateUser(string login, string passwordHash, string role)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();

                string query = @"
                    SELECT COUNT(*)
                    FROM Users
                    WHERE login = @login AND password_hash = @passwordHash AND role = @role";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@passwordHash", passwordHash);
                    command.Parameters.AddWithValue("@role", role);

                    int count = (int)command.ExecuteScalar();
                    return count > 0; // Если совпадение найдено
                }
            }
        }
    }
}
