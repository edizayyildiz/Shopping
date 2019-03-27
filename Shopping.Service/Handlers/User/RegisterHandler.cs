using Shopping.Model.Entities; 
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class RegisterHandler : CommandHandler<Commands.Register>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        public RegisterHandler(UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }
        public override async Task<dynamic> HandleAsync(Commands.Register command)
        {
            Result result;
            var user = new ApplicationUser() { Fullname = command.Fullname, Email = command.Email, UserName = command.Email, EmailConfirmed = true };
            var identityResult = userManager.CreateAsync(user, command.Password).Result;
            if (identityResult.Succeeded)
            {
                result= new Result(true, identityResult,"Kullanıcı başarıyla oluşturuldu. ",true,1);
                return await Task.FromResult(result);
            }
            result= new Result(false, identityResult,"Kullanıcı oluşturulurken bir hata oldu: " + identityResult.Errors.FirstOrDefault()?.Description ?? "mesaj yok", true,null);
            return await Task.FromResult(result);
        }

    }
}
