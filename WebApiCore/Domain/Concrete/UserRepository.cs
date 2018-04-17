using Models;
using System.Collections.Generic;
using System.Linq;
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
        public List<User> Find()
        {
            return _context.Users.ToList();
        }

        public void Insert(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
