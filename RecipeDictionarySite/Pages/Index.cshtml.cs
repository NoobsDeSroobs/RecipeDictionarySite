﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeDictionarySite.Models;
using Microsoft.EntityFrameworkCore;

namespace RecipeDictionarySite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;
        
        public IList<Recipe> Recipes { get; set; }

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        public async Task OnGetAsync()
        {
            Recipes = await _db.Recipes.AsNoTracking().ToListAsync();
        }
    }
}
