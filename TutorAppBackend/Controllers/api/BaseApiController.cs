using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TutorAppBackend.Models;

namespace TutorAppBackend.Controllers.api
{
    public class BaseApiController : ApiController
    {
        protected TutorAppDbContext _context;
        protected ApplicationUserManager _userManager;

        protected string UserId => User.Identity.GetUserId();

        protected Task<ApplicationUser> UserAsync => _userManager.FindByIdAsync(User.Identity.GetUserId());

        public BaseApiController()
        {
            _context = new TutorAppDbContext();
            var userStore = new ApplicationUserStore(_context);
            _userManager = new ApplicationUserManager(userStore);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
