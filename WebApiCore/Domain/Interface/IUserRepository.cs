using Models;
using System.Collections.Generic;

namespace WebApiCore.Domain.Interface
{
    public interface IUserRepository
    {
        List<User> Find();
        void Insert(User user);
    }
}
