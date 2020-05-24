using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetaDataValidationCore.Models;
using Microsoft.AspNetCore.Mvc;


namespace MetaDataValidationCore.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly DatabaseContext _context;

        public AccountController(DatabaseContext context)
        {
            _context = context;
        }


        [Route("")]
        [Route("~/")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View(new Account());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Account account)
        {
            if (account.Username != null && _context.Account.Any(a => a.Username == account.Username))
            {
                ModelState.AddModelError("Username","Username exists");
                return View("Index",account);
            }

            if (ModelState.IsValid)
            {
                account.Username = account.Username?.Trim().ToLower();
                account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
                account.Email = account.Email.Trim().ToLower();
                _context.Account.Add(account);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View("Index",account);
        }
    }
}