using ecommerce.Models;

namespace ecommerce.Repository.IRepository
{
    public interface ICoverTypeRepository: IRepository<CoverType>
    {
        void Update(CoverType obj);
    }
}
