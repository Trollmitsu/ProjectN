#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UI;
using UI.Models;

namespace UI.Pages.Consultants
{
    public class DetailsModel : PageModel
    {
        private readonly UI.ProjectXContext _context;

        public DetailsModel(UI.ProjectXContext context)
        {
            _context = context;
        }

        public Consultant Consultant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Consultant = await _context.Consultants.FirstOrDefaultAsync(m => m.Id == id);

            if (Consultant == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
