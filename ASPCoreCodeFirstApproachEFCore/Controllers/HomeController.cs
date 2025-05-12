using System.Diagnostics;
using ASPCoreCodeFirstApproachEFCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreCodeFirstApproachEFCore.Controllersr
{
    public class HomeController : Controller
    {
        private readonly StudentDbContext studentDb;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        // jo StudentDbContext ki class hai uska object yaha banana hai taki jo usme dbset jo databse ke table ko 
        // represent karra {waha se data fetch karra hai} wo kaam mai yaha pe karsakoo
        // mai yaha pe ek constructor banata hoon (ctor)
        public HomeController(StudentDbContext studentDb) // ye ek constructor hai aur jo class ka name hai wahi constor ka bhi name rahega
        {
            this.studentDb = studentDb;  // Initialized studentDb object
        }

        public IActionResult Index()
        {
            var stdData = studentDb.Students.ToList();
            return View(stdData);
        }
        public IActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentModel std)
        {
            if (ModelState.IsValid)  // programentor me validation ke concept me hai ye
            {
                studentDb.Students.Add(std);  // ye add apne student ke dbset me jo hamare pas jo datacontext ke obj ke ander hai
                studentDb.SaveChanges();  // success complete karne ke liye
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
