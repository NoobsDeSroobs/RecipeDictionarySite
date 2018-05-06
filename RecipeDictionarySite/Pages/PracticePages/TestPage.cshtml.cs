using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeDictionarySite.Models;
using Microsoft.EntityFrameworkCore;

namespace RecipeDictionarySite.Pages.PracticePages
{
    public class TestPageModel : PageModel
    {
        private readonly AppDbContext _db;

        [BindProperty]
        public Recipe Recipe { get; set; }
        public IList<Recipe> Recipes { get; set; }

        public TestPageModel(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _db.Recipes.Add(Recipe);

            await _db.SaveChangesAsync();
            return RedirectToPage("/PracticePages/TestPage");
        }

        public async Task OnGetAsync()
        {
            Recipes = await _db.Recipes.AsNoTracking().ToListAsync();
        }

    }
}