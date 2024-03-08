using ServerApplication.Common;
using ServerApplication.Version1.Models;
using System.Data.SqlClient;
using System.Linq;

namespace ServerApplication.Version1.Infrastructure
{
    public class PaitentVisiteRepository : IPaitentVisiteRepository
    {
        private IConfiguration _configuration;

        public PaitentVisiteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Getpaitentvisite>> GetAllAssignPaitent(int employeeId,int paitentId)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ConHMS").ToString());
                DynamicModelConverter<Getpaitentvisite> converter = new DynamicModelConverter<Getpaitentvisite>();
                List<Getpaitentvisite> employees = new List<Getpaitentvisite>();
                string query = $"SELECT * FROM paitentvisite WHERE assigntoid = {employeeId} AND paitentId = {paitentId} ";
                employees = converter.Get(connection.ConnectionString, query);
                return employees;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<paitentvisiteInfo>> GetAllAssignPaitentInfo(int employeeId)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ConHMS").ToString());
                DynamicModelConverter<paitentvisiteInfo> converter = new DynamicModelConverter<paitentvisiteInfo>();
                List<paitentvisiteInfo> employees = new List<paitentvisiteInfo>();

                string query = $@"SELECT pv.paitentid,p.firstname as paitentname,e.employeename as assignbyname,pv.description,pv.status,pv.medicineids FROM paitentvisite pv
                                LEFT JOIN paitent p ON pv.paitentid = p.paitentid
                                LEFT JOIN employee e ON e.employeeid = pv.addedbyid
                                WHERE pv.assigntoid  = { employeeId} and pv.isactive = 1";
                employees = converter.Get(connection.ConnectionString, query);
                return employees;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> createVisite(PaitentVisite paitentvisite)
        {
            try
            {
                SqlConnection connecion = new SqlConnection(_configuration.GetConnectionString("ConHMS").ToString());
                
                DynamicModelConverter<PaitentVisite> converter = new DynamicModelConverter<PaitentVisite>();
                int visiteAdded = converter.Insert(connecion.ConnectionString, paitentvisite);

                
                return visiteAdded;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
