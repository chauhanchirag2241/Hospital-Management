using ASMSapi.Model;
using ServerApplication.Common;
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

        public Task<List<Account>> CreateUser(Account account)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Account>> GetUser(string userName, string password)
        {
            Response response = new Response();
            SqlConnection connecion = new SqlConnection(_configuration.GetConnectionString("ConHMS").ToString());
            string query = $@"select * from serveruser where username = '{userName}' and password = '{password}' ";

            DynamicModelConverter<Account> converter = new DynamicModelConverter<Account>();
            List<Account> accountList = converter.Get(connecion.ConnectionString,query);

            // return await accountList;
            return accountList;

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
