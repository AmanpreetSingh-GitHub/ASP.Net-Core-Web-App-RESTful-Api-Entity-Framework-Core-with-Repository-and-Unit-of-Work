using FrameworkTwo.Domain;

namespace FrameworkTwo.Repository.Interface
{
    public interface IUnitOfWork
    {
        FrameworkTwoContext DbContext { get; }

        int Save();
    }
}
