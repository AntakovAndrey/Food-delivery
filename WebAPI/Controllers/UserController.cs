using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Infrastructure;
using WebAPI.Infrastructure.Entities;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : Controller
	{

        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public UserController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost]
		[Route("authenticate")]
		public IActionResult Authenticate([FromBody]LoginModel loginModel)
		{
            try
            {
				User user;
				int cartId;
                using (ApplicationContext db = new())
				{
					user = db.Users.First(u=>u.Email== loginModel.Email&&u.Password==loginModel.Password);
					cartId = db.Carts.First(c => c.UserId == user.Id).Id;
				}
				return Json(new { loginModel.Email, user.Id,cartId});
			}
			catch (Exception ex)
			{
			return BadRequest(ex.Message);
            }
        }

		[HttpPost("Register")]
		public IActionResult Register(string username,string email, string password) 
		{
			try{ 
				using(ApplicationContext db = new ApplicationContext()) 
				{
					User user = new User();
					user.Name = username;
					user.Email=email;
					user.Password=password;
					user.Role = db.Roles.FirstOrDefault(r=>r.Name=="user");
					db.Users.Add(user);
					db.SaveChanges();
					user = db.Users.FirstOrDefault(u=>u.Email==email);
					db.SaveChanges();
					db.Carts.Add(new Cart { UserId = user.Id });
				}
				return Ok();
            }
			catch (Exception ex) 
			{
				return BadRequest(ex.Message);
			}
        }


	}
}
