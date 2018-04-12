using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Domain.Interface
{
    public interface IUserRepository
    {
        User Find(string name);
    }
}
