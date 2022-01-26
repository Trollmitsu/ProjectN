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
    public class IndexModel : PageModel
    {
        private readonly UI.ProjectXContext _context;

        public IndexModel(UI.ProjectXContext context)
        {
            _context = context;
        }

        public IList<Consultant> Consultant { get;set; }

        public async Task OnGetAsync()
        {
            Consultant = await _context.Consultants.ToListAsync();
        }
    }
}
