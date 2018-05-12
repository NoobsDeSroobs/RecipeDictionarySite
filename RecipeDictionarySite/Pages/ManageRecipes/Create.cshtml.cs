using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeDictionarySite.Data;
using RecipeDictionarySite.Models;

namespace RecipeDictionarySite.Pages.PracticePages
{
    [Authorize(Roles = "ADMIN")]
    public class CreateModel : PageModel
    {
        private readonly RecipeDictionarySite.Data.ApplicationDbContext _db;

        public CreateModel(RecipeDictionarySite.Data.ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Recipe Recipe { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Recipes.Add(Recipe);
            await _db.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}