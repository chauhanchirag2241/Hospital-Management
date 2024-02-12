using ServerApplication.Version1.Models;

namespace ServerApplication.Version1.Infrastructure
{
    public interface IMedicineRepository
    {
        public Task<List<Medicine>> GetAllMedicine();
    }
}
