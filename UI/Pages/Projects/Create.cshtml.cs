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

namespace UI.Pages.Projects
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
        ViewData["CompanyName"] = new SelectList(_context.Companies, "Id", "CompanyName");
            return Page();
        }

        public IActionResult OnGetConsultants()
        {
            ViewData["FullName"] = new SelectList(_context.Consultants, "Id", "FullName");
            return Page();
        }

        [BindProperty]
        public Project Project { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Projects.Add(Project);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
