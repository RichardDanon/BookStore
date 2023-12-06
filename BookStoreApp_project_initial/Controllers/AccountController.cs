using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BookStoreApp.Models;


namespace BookStoreApp.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public AccountController(UserManager<User> userMngr,
            SignInManager<User> signInMngr)
        {
            userManager = userMngr;
            signInManager = signInMngr;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Username };
                var result = await userManager.CreateAsync(user,
                    model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user,
                        isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            return View(model);

        }


        [HttpGet]
        public IActionResult LogIn(string returnURL = "")
        {
            var model = new LoginViewModel { ReturnUrl = returnURL };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Username, model.Password,
                    isPersistent: model.RememberMe,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) &&
                        Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid username/password.");
            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            var model = new ForgotPassword();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPassword model)
        {
            if (ModelState.IsValid)
            {
                if(model.NewPassword != model.ConfirmedPassword)
                {
                    ModelState.AddModelError("", "New password does not match confirm password");
                    return View(model);
                }

                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null && user.UserName == model.Username)
                {
                    // Generate a password reset token
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);

                    // Reset the user's password
                    var result = await userManager.ResetPasswordAsync(user, token, model.ConfirmedPassword);

                    if (result.Succeeded)
                    {
                        // Password reset successful, you can redirect to a success page or login page
                        return RedirectToAction("Login","Account");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                else
                {
                    // User not found or email/username mismatch
                    ModelState.AddModelError("", "Invalid email or username.");
                }

            }
            return View(model);
        }


    }
}
