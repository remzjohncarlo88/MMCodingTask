using MetaMindsCodingTask.Models;
using MetaMindsCodingTask.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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

        /// <summary>
        /// Get single user.
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns></returns>
        [HttpGet]
        public PartialViewResult GetUser(int userId)
        {
            var data = _userRepository.GetUser(userId);
            return PartialView("_SingleUserView", data);
        }

        /// <summary>
        /// Create a user.
        /// </summary>
        /// <param name="user">new user details</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(string name, string job)
        {
            dynamic user = new JObject();
            user.Name = name;
            user.Job = job;

            var userJson = Newtonsoft.Json.JsonConvert.SerializeObject(user);

            var data = _userRepository.Create(userJson);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Delete a specific user.
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns></returns>
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            _userRepository.Delete(id);
            return Json(true);
        }
    }
}