using MetaMindsCodingTask.Models;
using MetaMindsCodingTask.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MetaMindsCodingTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Get the initial list of users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            //get initial list of users
            var data = _userRepository.Get();
            return View(data);
        }

        [HttpGet]
        public IActionResult GetUser(int userId)
        {
            var data = _userRepository.GetUser(userId);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Create a user.
        /// </summary>
        /// <param name="user">new user details</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(DataModel user)
        {
            var data = _userRepository.Create(user);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Delete a specific user.
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _userRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}