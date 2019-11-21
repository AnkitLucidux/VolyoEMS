using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;

namespace EMS.Entities
{
    public class EntityBaseClass
    {
        [DisplayName("Active")]
        public bool IsActive { get; set; }

        [DisplayName("Deleted")]
        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }
        
        public DateTime ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public EntityBaseClass()
        {
            CreatedDate = ModifiedDate = DateTime.Now;
            IsActive = true;
            IsDeleted = false;
        }
    }
}
