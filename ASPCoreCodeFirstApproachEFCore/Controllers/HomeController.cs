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

        public async Task<IActionResult> Index()
        {
            var stdData = await studentDb.Students.ToListAsync();
            return View(stdData);
        }
        public IActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentModel std)
        {
            if (ModelState.IsValid)  // programentor me validation ke concept me hai ye
            {
                await studentDb.Students.AddAsync(std);  // ye add apne student ke dbset me jo hamare pas jo datacontext ke obj ke ander hai
                await studentDb.SaveChangesAsync();  // success complete karne ke liye
                return RedirectToAction("Index", "Home");
            }
            return View(std);
            //return View();
        }
        public async Task<IActionResult> Details(int? id) // int ki Default value 0 hoti hai isliye
                         // Default value null set karne keliye int ke aage ? ye mark lagana padta
        {
            if (id == null || studentDb.Students == null) // Validation lagaya gaya hai.
            {
                return NotFound();
            }  
            var stdData = await studentDb.Students.FirstOrDefaultAsync(x => x.Id == id);
            if(stdData == null)  // Validation lagaya gaya hai
            {
                return NotFound();
            }
            return View(stdData);
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
