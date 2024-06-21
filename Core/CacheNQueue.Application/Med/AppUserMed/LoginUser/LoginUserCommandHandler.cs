using CacheNQueue.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Med.AppUserMed.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly UserManager<AppUser> userManager;
        readonly SignInManager<AppUser> signInManager;
        public LoginUserCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
             var appUser= await userManager.FindByNameAsync(request.UserNameOrEMail);
            if (appUser == null)
                appUser = await userManager.FindByEmailAsync(request.UserNameOrEMail);
            if (appUser == null)
            {
                return new()
                {
                    message = "Kullanıcı Bulunamadı"
                };
            }

            SignInResult result = await signInManager.CheckPasswordSignInAsync(appUser, request.Password, false);
            if (result.Succeeded)
            {
                //TokenResponse token = _tokenHandler.CreateAccessToken(15);
                //return new()
                //{
                //    message = "Giriş başarılı",
                //    Token = token
                //};
                //Yetkiler()
                return new() { message = "Başarılı" };

            }
            else
                return new() { message = "şifre eşleşmiyor" };
        
        }
    }
}
