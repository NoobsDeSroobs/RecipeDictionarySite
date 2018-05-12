using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeDictionarySite.Models;
using Microsoft.EntityFrameworkCore;
using RecipeDictionarySite.Data;
using Microsoft.AspNetCore.Authorization;

namespace RecipeDictionarySite.Pages.PracticePages
{
    [Authorize(Roles = "ADMIN")]
    public class TestPageModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Recipe Recipe { get; set; }
        public IList<Recipe> Recipes { get; set; }

        public TestPageModel(ApplicationDbContext db)
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

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var recipe = await _db.Recipes.FindAsync(id);
            if(recipe != null)
            {
                _db.Recipes.Remove(recipe);
                await _db.SaveChangesAsync();
            }
            return RedirectToPage();
        }

    }
}