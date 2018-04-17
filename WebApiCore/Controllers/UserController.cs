using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading.Tasks;
using WebApiCore.Domain.Interface;

namespace WebApiCore.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userRepository"></param>
        public UserController(IUserRepository userRepository) => _userRepository = userRepository;
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <param name="name">用户名</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var item = _userRepository.Find();
            if (null == item)
                return NotFound();
            return new ObjectResult(item);
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(User user)
        {
            _userRepository.Insert(user);
            return new ObjectResult(null);
        }
    }
}