using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Domain.Interface;

namespace WebApiCore.Domain.Concrete
{
    public class UserRepository:IUserRepository
    {
        private readonly TestContext _context;
        /// <summary>
        /// 构造函数
        /// sunyue
        /// </summary>
        /// <param name="context">Context.</param>
        public UserRepository(TestContext context)
        {
            _context = context;
        }
        public User Find(string name)
        {
            return _context.Users.FirstOrDefault(obj => obj.name == name);
        }
    }
}
