using ServerApplication.Version1.Models;

namespace ServerApplication.Version1.Infrastructure
{
    public interface IPaitentVisiteRepository
    {
        public Task<int> createVisite(PaitentVisite paitentvisite);
        public  Task<List<Getpaitentvisite>> GetAllAssignPaitent(int GetAllAssignPaitent, int paitentId);
        public  Task<List<paitentvisiteInfo>> GetAllAssignPaitentInfo(int GetAllAssignPaitent);
        public Task<List<paitentVisiteByPaitentId>> GetPaitentDetailByPaitentId(int paitentId,string email);
        public Task<List<medicineByPaitentId>> GetMedicineByPaitentId(int paitentId, string email);
    }
}
