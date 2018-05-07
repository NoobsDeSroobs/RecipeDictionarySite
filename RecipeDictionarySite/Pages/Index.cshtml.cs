using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeDictionarySite.Models;
using Microsoft.EntityFrameworkCore;
using RecipeDictionarySite.Data;

namespace RecipeDictionarySite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        public IList<Recipe> Recipes { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGetAsync()
        {
            Recipes = await _db.Recipes.AsNoTracking().ToListAsync();
        }
    }
}
