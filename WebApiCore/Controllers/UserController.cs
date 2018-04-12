using Microsoft.AspNetCore.Mvc;
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
        public UserController(IUserRepository userRepository) =>_userRepository = userRepository;
        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(string name)
        {
            var item = _userRepository.Find(name);
            if (null == item)
                return NotFound();
            return new ObjectResult(item);
        }
    }
}