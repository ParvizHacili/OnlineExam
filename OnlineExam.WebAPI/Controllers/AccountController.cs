using Exam.Core.Domain.Abstract;
using Exam.Core.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.CommonModels;
using OnlineExam.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.WebAPI.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseApiController
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        
        public AccountController(IUnitOfWork db, UserManager<User> userManager, SignInManager<User> signInManager) : base(db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        [Route("Authenticate")]
        public async Task<IActionResult> Authenticate(LoginDto loginDto)
        {
            User user = DB.UserRepository.Get(loginDto.Username);

            if (user != null)
            {
                var passwordIsOk = await userManager.CheckPasswordAsync(user, loginDto.Password);

                if (passwordIsOk == false)
                {
                    return BadRequest("Username or password is incorrect");
                }
            }
            else
            {
                return BadRequest("Username or password is incorrect");
            }

            var result = await signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, true, true);

            if (result.Succeeded)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest("Username or password is incorrect");
            }
        }
    }
}
