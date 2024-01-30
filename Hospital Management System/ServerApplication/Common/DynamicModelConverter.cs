using System.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace ServerApplication.Common
{
    public class DynamicModelConverter<T>
    {
        public List<T> FatchData(string connectionString, string sqlQuery)
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
