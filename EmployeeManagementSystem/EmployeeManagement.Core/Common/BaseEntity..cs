using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Core.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        // Audit fields
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? ModifiedBy { get; set; }

        // Soft delete support
        public bool IsDeleted { get; set; } = false;
    }
    
}
