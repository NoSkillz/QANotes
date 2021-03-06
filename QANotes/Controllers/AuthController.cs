﻿using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using QANotes.Auth;
using QANotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace QANotes.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public AuthController()
            : this (Startup.UserManagerFactory.Invoke())
        {

        }

        public AuthController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        
        public ActionResult Login(string returnUrl)
        {
            LoginModel model = new LoginModel { ReturnUrl = returnUrl };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Try to find a user in the db with the specified email and password
            var user = await userManager.FindAsync(model.Email, model.Password);

            if (user != null)
            {
                // Create a claims identity for user
                await SignIn(user);

                if (model.ReturnUrl != null)
                    return Redirect(model.ReturnUrl);
                return RedirectToAction("Index", "Notes");
            }

            ModelState.AddModelError("Password", "Invalid email or password");

            return View();
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register([Bind(Include = "Email,Password,RepeatPassword")] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = new AppUser
            {
                Email = model.Email,
                DateCreated = DateTime.Now,
                UserName = model.Email
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await SignIn(user);
                return RedirectToAction("Index", "Notes");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("Email", error);
            }

            return View();
        }

        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");

            return RedirectToAction("Index", "Notes");
        }


        private IAuthenticationManager GetAuthenticationManager()
        {
            var ctx = Request.GetOwinContext();
            return ctx.Authentication;
        }

        private async Task SignIn(AppUser user)
        {
            var identity = await userManager.CreateIdentityAsync(
                user, DefaultAuthenticationTypes.ApplicationCookie);
            GetAuthenticationManager().SignIn(identity);
        }

        public bool IsAuthenticated()
        {
            if (Request.IsAuthenticated)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && userManager != null)
            {
                userManager.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}