using Models;

namespace WebApiCore.Domain.Interface
{
    public interface IUserRepository
    {
        User Find(string name);
    }
}
