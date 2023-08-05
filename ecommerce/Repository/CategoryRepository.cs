using ecommerce.DataAccess;
using ecommerce.Models;
using ecommerce.Repository.IRepository;

namespace ecommerce.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {

        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }   

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
