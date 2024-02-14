using ServerApplication.Version1.Models;

namespace ServerApplication.Version1.Infrastructure
{
    public interface IPaitentVisiteRepository
    {
        public Task<int> createVisite(paitentvisite paitentvisite);
        public  Task<List<paitentvisite>> GetAllAssignPaitent(int GetAllAssignPaitent);
    }
}
