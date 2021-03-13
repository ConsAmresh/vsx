using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCXModels.domain.UserModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CCXConnector.UI.Pages
{
    public class LoginModel : PageModel
    {
        public UserAccount UserAccount { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                return RedirectPermanent("../Account/Dashboard");
            }
            else
            {
                return Page();
            }
        }
    }
}