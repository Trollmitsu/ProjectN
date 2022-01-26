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

namespace UI.Pages.Projects
{
    public class IndexModel : PageModel
    {
        private readonly UI.ProjectXContext _context;

        public IndexModel(UI.ProjectXContext context)
        {
            _context = context;
        }

        public IList<Project> Project { get;set; }
        public async Task OnGetAsync()
        {
            Project = await _context.Projects
                .Include(c => c.Consultants)
                .Include(p => p.Company)
                .ToListAsync();
        }
    }
}
