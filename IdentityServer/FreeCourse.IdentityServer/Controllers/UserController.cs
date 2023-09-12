using FreeCourse.IdentityServer.Dtos;
using FreeCourse.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace FreeCourse.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    public class UserController : CustomBaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignupDto singupDto)
        {
            var user = new ApplicationUser
            {
                UserName = singupDto.UserName,
                Email = singupDto.Email,
                City = singupDto.City,
            };
            var result= await _userManager.CreateAsync(user,singupDto.Password);
            if (!result.Succeeded) {
                return CreateActionResult(Response<NoContent>.Fail(result.Errors.Select(x => x.Description).ToList(), 400));
            }
            return CreateActionResult(Response<NoContent>.Success(204));
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var userIdClaim=User.Claims.FirstOrDefault(x=>x.Type==JwtRegisteredClaimNames.Sub);
            if (userIdClaim==null)
            {
                return CreateActionResult(Response<NoContent>.Fail("Böyle Bir Claim Yok",400));
            }
            var user = await _userManager.FindByIdAsync(userIdClaim.Value);
            if(user==null)
            {
                return CreateActionResult(Response<NoContent>.Fail("Böyle Bir Kullanıcı Yok", 400));
            }
            UserDto userDto = new UserDto { Id = user.Id,UserName=user.UserName,Email=user.Email,City=user.City };
            return CreateActionResult(Response<UserDto>.Success(userDto,200));
        }

    }
}
