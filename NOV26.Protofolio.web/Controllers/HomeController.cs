using Microsoft.AspNetCore.Mvc;
using NOV26.Protofolio.web.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace NOV26.Protofolio.web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        Data.NOV26ProtofoliowebContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, Data.NOV26ProtofoliowebContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //HomeViewModel model = new HomeViewModel()
            //{
            //    FullName = "Binod Sapkota",
            //    Address = "Tokha, Kathmandu",
            //    Email = "binod@riddhasoft.com",
            //    Phone = "+977-9851-207299",
            //    CompletedProjects = 100,
            //    DOB = new DateTime(1990, 04, 02),
            //    Summary = "Asp.net Developer with decades of Experience",
            //    Title = "Asp.net Developer",
            //    ZipCode = "44600"


            //};

            HomeViewModel model = new HomeViewModel();
            var personalInformation = _context.PersonalInformationModel.FirstOrDefault();
            model.Address = personalInformation.Address;
            model.FullName = personalInformation.FullName;
            model.Summary = personalInformation.Summary;
            model.Email = personalInformation.Email;
            model.Phone = personalInformation.Phone;
            model.DOB = personalInformation.DOB;
            model.CompletedProjects = personalInformation.CompletedProjects;
            model.Title = personalInformation.Title;
            model.ZipCode = personalInformation.ZipCode;
            model.UserPhotoUrl = personalInformation.UserPhotoUrl;
            model.Resumes = _context.ResumeModel.ToList();
            model.Services = _context.ServiceModel.ToList();
            model.Skills = _context.SkillModel.ToList();
            model.Projects = _context.ProjectModel.Include(x => x.Service).ToList();
            model.Blogs = _context.BlogModel.OrderByDescending(x => x.DateTime).Take(3).ToList();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Blog(int id)
        {
            var blog = _context.BlogModel.Find(id);

            var comments = _context.BlogCommentModel.Where(x => x.BlogId == id).ToList();

            BlogViewModel blogvm = new BlogViewModel()
            {
                ImageUrl = blog.ImageUrl,
                DateTime = blog.DateTime,
                Id = id,
                Paragraph1 = blog.Paragraph1,
                Paragraph2 = blog.Paragraph2,
                Title = blog.Title,
                comments = comments,
            };
            return View(blogvm);
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                bool isValidLogin = _context.UserModel.Any(x => x.UserName == model.UserName && x.Password == model.Password);
                if (isValidLogin)
                {
                    addingClaimIdentity(model, "admin");
                    return RedirectToAction("index","PersonalInformationModels");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }
        private void addingClaimIdentity(LoginModel user, string roles)
        {
            //list of claims
            var userClaims = new List<Claim>()
                {
                    new Claim("UserName", user.UserName),
                    new Claim(ClaimTypes.Email,user.UserName),
                   // new Claim(ClaimTypes.Role,"user"),
                    
                    new Claim(ClaimTypes.Role,roles),

                 };


            //create a identity claims
            var claimsIdentity = new ClaimsIdentity(
            userClaims, CookieAuthenticationDefaults.AuthenticationScheme);


            //httcontext , current user is authentic user
            //sing in user to httpcontext
            HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity)
            );
        }
    }
}