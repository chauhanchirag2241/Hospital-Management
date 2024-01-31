using System.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace ServerApplication.Common
{
    public class DynamicModelConverter<T>
    {
        private string GetTableName()
        {
            // Assuming the table name is the same as the model name
            return typeof(T).Name;
        }

        public void Insert(string connectionString, T model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string tableName = GetTableName();
                string columns = string.Join(", ", typeof(T).GetProperties().Select(prop => prop.Name));
                string values = string.Join(", ", typeof(T).GetProperties().Select(prop => $"@{prop.Name}"));

                string insertQuery = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    foreach (var property in typeof(T).GetProperties())
                    {
                        command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(model) ?? DBNull.Value);
                    }

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(string connectionString, T model, int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string tableName = GetTableName();
                string setClause = string.Join(", ", typeof(T).GetProperties().Select(prop => $"{prop.Name} = @{prop.Name}"));

                string updateQuery = $"UPDATE {tableName} SET {setClause} WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    foreach (var property in typeof(T).GetProperties())
                    {
                        command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(model) ?? DBNull.Value);
                    }

                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(string connectionString, int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string tableName = GetTableName();
                string deleteQuery = $"DELETE FROM {tableName} WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<T> Get(string connectionString, string sqlQuery)
        {
            List<T> resultList = new List<T>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            T model = Activator.CreateInstance<T>();

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string columnName = reader.GetName(i);
                                var property = typeof(T).GetProperty(columnName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                                if (property != null && !reader.IsDBNull(i))
                                {
                                    property.SetValue(model, Convert.ChangeType(reader.GetValue(i), property.PropertyType));
                                }
                            }

                            resultList.Add(model);
                        }
                    }
                }
            }

            return resultList;
        }
    
    }

}



   

