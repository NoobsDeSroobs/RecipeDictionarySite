using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeDictionarySite.Data;
using RecipeDictionarySite.Models;

namespace RecipeDictionarySite.Pages.PracticePages
{
    [Authorize(Roles = "ADMIN")]
    public class IndexModel : PageModel
    {
        private readonly RecipeDictionarySite.Data.ApplicationDbContext _db;

        public IndexModel(RecipeDictionarySite.Data.ApplicationDbContext context)
        {
            _db = context;
        }

        public IList<Recipe> Recipe { get;set; }

        public async Task OnGetAsync()
        {
            Recipe = await _db.Recipes.ToListAsync();
        }
    }
}
