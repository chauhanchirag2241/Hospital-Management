using ServerApplication.Common;
using ServerApplication.Version1.Models;
using System.Data.SqlClient;

namespace ServerApplication.Version1.Infrastructure
{
    public class MedicineRepository : IMedicineRepository
    {
        private IConfiguration _configuration;

        public MedicineRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<Medicine>> GetAllMedicine()
        {
            try
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ConHMS").ToString());
                DynamicModelConverter<Medicine> converter = new DynamicModelConverter<Medicine>();
                List<Medicine> medicines = new List<Medicine>();
                string query = "select * from medicine";
                medicines = converter.Get(connection.ConnectionString, query);
                return medicines;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<MedicalDepartment>> GetAllPaitentForPayment()
        {
            try
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ConHMS").ToString());
                DynamicModelConverter<MedicalDepartment> converter = new DynamicModelConverter<MedicalDepartment>();
                List<MedicalDepartment> medicines = new List<MedicalDepartment>();
                string query = $@"SELECT 
                                            pv.paitentid,
                                           
                                            p.firstname AS paitentname,
                                            pv.addedbyid, 
                                            pv.status,
                                            e.employeename AS addedbyname,
                                            pv.medicineids,
                                            STRING_AGG(m.medicinename, ',') AS medicinenames
                                        FROM  paitentvisite pv
                                        LEFT JOIN   paitent p ON pv.paitentid = p.paitentid
                                        LEFT JOIN   employee e ON pv.addedbyid = e.employeeid
                                        LEFT JOIN   medicine m ON CHARINDEX(',' + CAST(m.medicineid AS VARCHAR) + ',', ',' + pv.medicineids + ',') > 0
                                        WHERE
                                            pv.assigntoid = 0
                                            AND pv.status = 'Payment'
                                        GROUP BY
                                            pv.paitentid, p.firstname, pv.addedbyid, e.employeename, pv.medicineids,pv.status; ";
                medicines = converter.Get(connection.ConnectionString, query);
               //  var medicineIds = medicines.Select(p => p.MedicineIds).ToList();
                //List<int[]> medicineIdsArrays = medicines.Select(p => p.MedicineIds.Split(',').Select(int.Parse).ToArray()).ToList();

                //SqlConnection connection1 = new SqlConnection(_configuration.GetConnectionString("ConHMS").ToString());
                //DynamicModelConverter<Medicine> converter1 = new DynamicModelConverter<Medicine>();
                //List<Medicine> medicinetable = new List<Medicine>();
                //string query1 = "select * from medicine";
                //List<Medicine> allMedicines = converter1.Get(connection1.ConnectionString, query1);
                 
                //// Find medicine names for each record in medicines
                //List<List<string>> medicineNamesForEachRecord = medicineIdsArrays.Select(ids => ids.Select(id => allMedicines.FirstOrDefault(m => m.MedicineId == id)?.MedicineName).ToList())                .ToList();
                //var combinedMedicines = medicines.Zip(medicineNamesForEachRecord, (medicine, medicineNames) => new
                //{
                //    medicine.MedicineIds,
                //    medicine.MedicineDetail,
                //    MedicineNames = medicineNames
                //}).ToList();
                return medicines;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
