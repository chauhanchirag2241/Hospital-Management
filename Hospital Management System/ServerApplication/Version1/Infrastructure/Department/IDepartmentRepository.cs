using ServerApplication.Version1.Models;

namespace ServerApplication.Version1.Infrastructure
{
    public interface IDepartmentRepository
    {
        public Task<List<department>> GetAllDepartment();
    }
}
