using System;
using System.Collections.Generic;

namespace UI.Models
{
    public partial class Project
    {
        public Project()
        {
            Consultants = new HashSet<Consultant>();
        }

        public int Id { get; set; }
        public DateTime? AssignDate { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }
        public int? CompanyId { get; set; }

        public virtual Company? Company { get; set; }

        public virtual ICollection<Consultant> Consultants { get; set; }
    }
}
