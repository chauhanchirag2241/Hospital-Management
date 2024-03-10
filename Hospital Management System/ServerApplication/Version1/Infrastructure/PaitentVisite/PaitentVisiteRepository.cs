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

        public async Task<List<paitentVisiteByPaitentId>> GetPaitentDetailByPaitentId(int paitentId,string email)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ConHMS").ToString());
                DynamicModelConverter<paitentVisiteByPaitentId> converter = new DynamicModelConverter<paitentVisiteByPaitentId>();
                List<paitentVisiteByPaitentId> paitentvisite = new List<paitentVisiteByPaitentId>();

                string query = $@"SELECT 
                                        pv.paitentvisiteid,
                                        pv.paitentid,
                                        p.firstname AS paitentname,
                                        e.employeename AS addedbyname,
                                        e.employeecode,
                                        e.qualification,
                                        pv.description,
                                        STRING_AGG(m.medicinename, ', ') AS medicinenames -- Concatenate medicine names
                                                FROM   paitentvisite pv
                                                LEFT JOIN  paitent p ON pv.paitentid = p.paitentid
                                                LEFT JOIN  employee e ON pv.addedbyid = e.employeeid
                                                LEFT JOIN  (SELECT medicineid,medicinename FROM medicine) m ON CHARINDEX(',' + CAST(m.medicineid AS NVARCHAR(100)) + ',', ',' + pv.medicineids + ',') > 0
                                                WHERE 
                                                    pv.paitentid = {paitentId} and p.email = '{email}'
                                                    AND pv.isactive = 0
                                                GROUP BY
                                                    pv.paitentvisiteid,
                                                    pv.paitentid,
                                                    p.firstname,
                                                    e.employeename,
                                                    e.employeecode,
                                                    e.qualification,
                                                   pv.description;";

                paitentvisite = converter.Get(connection.ConnectionString, query);
                return paitentvisite;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<medicineByPaitentId>> GetMedicineByPaitentId(int paitentId, string email)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ConHMS").ToString());
                DynamicModelConverter<medicineByPaitentId> converter = new DynamicModelConverter<medicineByPaitentId>();
                List<medicineByPaitentId> medicinebill = new List<medicineByPaitentId>();

                string query = $@"SELECT mb.paitentid,p.firstname as paitentname,mb.medicinename,mb.quantity,mb.amount FROM
                                         medicinebill mb
                                         LEFT JOIN paitent p ON mb.paitentid = p.paitentid 
                                         WHERE mb.paitentid = 2 AND p.email = 'nahir@gmail.com' ";

                medicinebill = converter.Get(connection.ConnectionString, query);
                return medicinebill;
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
