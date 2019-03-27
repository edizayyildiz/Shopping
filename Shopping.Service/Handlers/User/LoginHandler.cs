using Shopping.Model.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class LoginHandler : CommandHandler<Commands.Login>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        public LoginHandler(UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }
        public override async Task<dynamic> HandleAsync(Commands.Login command)
        {
            Result result;
            //UserName and Password cannot be null or whitespace
            if (string.IsNullOrWhiteSpace(command.Email) || string.IsNullOrWhiteSpace(command.Password))
            {
                result= new Result(false, command.Email, "Giriş yapmak için e-posta ve parolanızı giriniz.", true, null);
                return await Task.FromResult(result);
            }

            var user = userManager.FindByEmailAsync(command.Email).Result;
            if (user != null)
            {
                var signinResult = signInManager.PasswordSignInAsync(user, command.Password, true, false).Result;
                if (signinResult.Succeeded)
                {
                    user.AccessToken = "8d522de3-e5f6-476f-a82f-efc4a53a4443";
                    var accessData = new { User = user, AccessToken = "8d522de3-e5f6-476f-a82f-efc4a53a4443", RefreshToken = Guid.NewGuid().ToString(), Roles = new List<string>(new string[] { "ADMIN" }.ToList()) };
                    result= new Result(true, accessData, "Giriş işlemi başarılı.", false,1);
                    return await Task.FromResult(result);
                }
            }
            result = new Result(false, command,"Geçersiz giriş denemesi.", true,null);
            return await Task.FromResult(result);
        }

    }
}
