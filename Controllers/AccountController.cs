using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieMania.Models;

namespace MovieMania.Controllers
{
    public class AccountController : Controller
    {
        //private readonly IMediator _mediator;
        //private readonly SignInManager<UserModel> _signInManager;
        //private readonly UserManager<ApplicationUser> _userManager;

        public AccountController()
        {
            //_signInManager = signInManager;
            //_userManager = userManager;
            //_mediator = mediator;
        }

        [TempData]
        public string MaskedEmailAddress { get; set; }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet("/change-password")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        //[HttpPost("/change-password")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.GetUserAsync(User);
        //        if (user != null)
        //        {
        //            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        //            if (result.Succeeded)
        //            {
        //                ViewBag.Changed = true;
        //                return View();
        //            }

        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError(string.Empty, error.Description);
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "User account was not found.");
        //        }
        //    }
        //    return View(model);
        //}


        [HttpGet("/SignIn")]
        //[AllowAnonymous]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout To enable password
                // failures to trigger account lockout, set lockoutOnFailure: true
                //var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);
                //if (result.Succeeded)
                //{
                //    return RedirectToLocal(returnUrl);
                //}
                //else
                //{
                //    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                //    return View(model);
                //}
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet("/SignUp")]
        [AllowAnonymous]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult SignUp(UserCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        //[HttpGet("/create-account")]
        //[AllowAnonymous]
        //public async Task<IActionResult> SignUp([FromQuery] string code = null, [FromQuery] string email = null)
        //{
        //    if (code == null)
        //    {
        //        throw new ApplicationException("A code must be supplied for account creation.");
        //    }

        //    if (User.Identity.IsAuthenticated)
        //    {
        //        await _signInManager.SignOutAsync();
        //        return RedirectToAction(nameof(SignUp), new { code, email });
        //    }

        //    return View(await _mediator.Send(new Create.Query(code, email), HttpContext.RequestAborted));
        //}

        //[HttpPost("/create-account")]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> SignUp([FromQuery] string code = null, [FromForm(Name = nameof(Create.ViewModel.Form))] Create.FormModel model = null)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return await Failed();
        //    }

        //    var result = await _mediator.Send(new Create.Command(code, model), HttpContext.RequestAborted);

        //    //if (!result.Succeeded)
        //    //{
        //    //    foreach (var error in result.Errors)
        //    //    {
        //    //        ModelState.AddModelError(string.Empty, error);
        //    //    }
        //    //    return await Failed();
        //    //}

        //    return RedirectToAction(nameof(SignUpConfirmation));

        //    async Task<IActionResult> Failed()
        //    {
        //        return View(await _mediator.Send(new Create.Query(code, model), HttpContext.RequestAborted));
        //    }
        //}

        [HttpGet("/create-account-confirmation")]
        [AllowAnonymous]
        public IActionResult SignUpConfirmation()
        {
            return View();
        }

        [HttpGet("/forgot-password")]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        //[HttpPost("/reset-password")]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var user = await _userManager.FindByEmailAsync(model.Email);
        //    if (user == null)
        //    {
        //        // Don't reveal that the user does not exist
        //        return Confirmation();
        //    }

        //    var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
        //    if (result.Succeeded)
        //    {
        //        return Confirmation();
        //    }

        //    AddErrors(result);

        //    return View();

        //    IActionResult Confirmation()
        //    {
        //        return View("ResetPasswordConfirmation");
        //    }
        //}

        //[HttpGet(IdentityRoutes.SignIn)]
        //[AllowAnonymous]
        //public async Task<IActionResult> SignIn(string returnUrl = null)
        //{
        //    // Clear the existing external cookie to ensure a clean login process
        //    await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

        //    ViewData["ReturnUrl"] = returnUrl;
        //    return View();
        //}

        //[HttpPost(IdentityRoutes.SignIn)]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> SignIn(LoginViewModel model, string returnUrl = null)
        //{
        //    ViewData["ReturnUrl"] = returnUrl;
        //    if (ModelState.IsValid)
        //    {
        //        // This doesn't count login failures towards account lockout To enable password
        //        // failures to trigger account lockout, set lockoutOnFailure: true
        //        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToLocal(returnUrl);
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        //            return View(model);
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignOut()
        {
            //await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(AccountController.SignIn), "Account");
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        #endregion Helpers
    }
}
