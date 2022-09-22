using IMS.models;
using IMS.repository;
using IMS.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static user user = new user();

        private readonly IConfiguration _configuration;
        private readonly Iuserservice _userservice;
        //private readonly IHttpContextAccessor _contextAccessor;
        private readonly userdbcontext _dbContext;
        private readonly Irepo _repo;

        public AuthController(IConfiguration configuration, userdbcontext db, Irepo r )
        {
            _configuration = configuration;
           // _userservice = userservice;
            _dbContext = db;
            _repo = r;
        }

        [HttpPost]
        [Route("Register")]

        public async Task<IActionResult> Signup([FromBody] registermodel reg)
        {
            _dbContext.BuildConnectionString(_configuration.GetConnectionString("registerAppCon"));

            var status = _repo.createCustomers(reg);

            if (status == "OK")
            {
                return Ok(new { message = "Register created successfully!" });
            }
            else
            {
                return StatusCode(429, status);
            }
        }


    }

}
