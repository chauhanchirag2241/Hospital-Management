using ASMSapi.Model;
using ServerApplication.Version1.Models;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace ServerApplication.Version1.Repository
{
    public class AccountRepository : IAccountRepository
    {
        
        private IConfiguration _configuration;

        public AccountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<Response> CreateUser(Account account)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> GetUser(string userName, string password)
        {
            Response response = new Response();
            SqlConnection connecion = new SqlConnection(_configuration.GetConnectionString("ConHMS").ToString());
            string query = $@"select * from serveruser ";
            SqlDataAdapter da = new SqlDataAdapter("select * from serveruser", connecion);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<Account> dataList = new List<Account>();
            dataList = ConvertDataTableToList<Account>(dt);

            if (dataList != null && dataList.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data found";
               
                response.DataList = dataList;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data found";
               ; // Set default value for model if needed
                response.DataList = null;
            }

            return await Task.FromResult(response);

        }

        public static List<T> ConvertDataTableToList<T>(DataTable dt) where T : new()
        {
            List<T> resultList = new List<T>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    T instance = new T();

                    foreach (DataColumn col in dt.Columns)
                    {
                        PropertyInfo property = instance.GetType().GetProperty(col.ColumnName);
                        if (property != null && row[col] != DBNull.Value)
                        {
                            if (property.PropertyType == typeof(bool))
                                property.SetValue(instance, Convert.ToBoolean(row[col]));
                            else if (property.PropertyType == typeof(DateOnly))
                                property.SetValue(instance, Convert.ToDateTime(row[col]));
                            else if (property.PropertyType == typeof(DateTime))
                                property.SetValue(instance, Convert.ToDateTime(row[col]));
                            else
                                property.SetValue(instance, Convert.ChangeType(row[col], property.PropertyType));
                        }
                    }

                    resultList.Add(instance);
                }
            }

            return resultList;
        }
    }
}
