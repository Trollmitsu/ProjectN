using System;
using System.Collections.Generic;

namespace UI.Models
{
    public partial class Company
    {
        public Company()
        {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string? CompanyName { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
