﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly RecipeDictionarySite.Data.ApplicationDbContext _db;

        public DeleteModel(RecipeDictionarySite.Data.ApplicationDbContext context)
        {
            _db = context;
        }

        [BindProperty]
        public Recipe Recipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipe = await _db.Recipes.SingleOrDefaultAsync(m => m.ID == id);

            if (Recipe == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipe = await _db.Recipes.FindAsync(id);

            if (Recipe != null)
            {
                _db.Recipes.Remove(Recipe);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
