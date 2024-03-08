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
                                            pv.paitentvisiteid,
                                            p.firstname AS paitentname,
                                            p.email,
                                            p.mobileno,
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
                                            AND PV.isactive = 1
                                        GROUP BY
                                            pv.paitentid, pv.paitentvisiteid,p.firstname,p.email,p.mobileno ,pv.addedbyid, e.employeename, pv.medicineids,pv.status; ";
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
        //    public async Task<int> CreateBill(List<medicineBill> medicineBill)
        //    {
        //        try
        //        {
        //            SqlConnection connecion = new SqlConnection(_configuration.GetConnectionString("ConHMS").ToString());

        //            DynamicModelConverter<List<medicineBill>> converter = new DynamicModelConverter<List<medicineBill>>();
        //            int billcreated = converter.Insert(connecion.ConnectionString, medicineBill);


        //            return billcreated;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw;
        //        }
        //    }
        public async Task<int> CreateBill(List<medicineBill> medicineBills)
        {
            try
            {
                int totalBillsCreated = 0;

                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ConHMS").ToString());

                foreach (var bill in medicineBills)
                {
                    DynamicModelConverter<medicineBill> converter = new DynamicModelConverter<medicineBill>();
                    int billsCreated = converter.Insert(connection.ConnectionString, bill);

                    totalBillsCreated += billsCreated;
                }           

                if(totalBillsCreated > 0)
                {
                    int paitentId = medicineBills[0].paitentId;
                    using (SqlConnection connection1 = new SqlConnection(_configuration.GetConnectionString("ConHMS").ToString()))
                    {
                        using (SqlCommand cmd1 = connection1.CreateCommand())
                        {
                            cmd1.CommandText = $"UPDATE paitentvisite set isactive = 0 WHERE paitentid = {paitentId}";
                            cmd1.Connection.Open();
                            cmd1.ExecuteNonQuery();
                        }
                       
                    }
                    using (SqlConnection connection2 = new SqlConnection(_configuration.GetConnectionString("ConHMS").ToString()))
                    {
                        using (SqlCommand cmd1 = connection2.CreateCommand())
                        {
                            cmd1.CommandText = $"UPDATE paitent set isactive = 0 WHERE paitentid = {paitentId}";
                            cmd1.Connection.Open();
                            cmd1.ExecuteNonQuery();
                        }

                    }
                    return totalBillsCreated;
                }
                else
                {
                    throw new ArgumentException("Bill Not Created.");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
