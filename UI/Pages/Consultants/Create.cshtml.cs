#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UI;
using UI.Models;

namespace UI.Pages.Consultants
{
    public class CreateModel : PageModel
    {
        private readonly UI.ProjectXContext _context;

        public CreateModel(UI.ProjectXContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Consultant Consultant { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Consultants.Add(Consultant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
