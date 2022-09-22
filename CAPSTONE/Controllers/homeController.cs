using CAPSTONE.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Newtonsoft.Json;
using Paket;
using ServiceStack;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace CAPSTONE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class homeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly Authservice _authservice;

        private static IHttpContextAccessor _hca { get; set; }
        private readonly IWebHostEnvironment _webHostEnvironment;

        //private readonly ILogger<HomeController> _logger;

        public homeController(IConfiguration configuration, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor hpc)
        {
            _hca = hpc;
            _configuration = configuration;
            _authservice = new Authservice(_hca);
            _authservice.baseaddress = _configuration.GetSection("AppSettings").GetSection("BaseAddress").Value;

            // _logger = logger;
        }

        [HttpGet]
        [Route("fetchdata")]

        public string fetchdata()//[FromBody] register u)
        {
            string s = HttpContext.Session.GetString("cccc");
            //Asynchronous programming is very popular with the help of the async and await keywords in C#.*/
            //bool rVal = await _authService.RegisterUserAsync(u);
            // return rVal;

            return "hhhhhhhhhhhhhhhhhh";
        }


        [Route("register")]
        [HttpPost]

        public async Task<bool> register([FromBody] Register re)
        {
            bool status = await _authservice.RegisterUserAsync(re);
            return status;
        }

        [Route("LoginUser")]
        [HttpPost]
        public async Task<string> LoginUser([FromBody] CAPSTONE.models.register u)
        {
            string[] rVal = await _authservice.LoginAsync(u.USERNAME, u.PASSWORD);
            if (rVal != null)
            {
                HttpContext.Session.SetString("USERNAME", u.USERNAME);
                HttpContext.Session.SetString("AccessToken", rVal[0]);
                HttpContext.Session.SetString("AccessTokenExpirationDate", rVal[1]);
                return JsonConvert.SerializeObject(rVal);
            }
            else
            {
                return null;
            }
        }

    }
}

