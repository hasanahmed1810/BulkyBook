using ecommerce.DataAccess;
using ecommerce.Models;
using ecommerce.Repository.IRepository;

namespace ecommerce.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
