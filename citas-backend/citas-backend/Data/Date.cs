using System;
using System.Collections.Generic;

namespace citas_backend.Data
{
    public partial class Date
    {
        public int Id { get; set; }
        public DateTime Date1 { get; set; }
        public string? Place { get; set; }
        public string? Description { get; set; }
        public double? Grade { get; set; }
        public int IdUserFirst { get; set; }
        public int IdUserSecond { get; set; }

        public virtual User IdUserFirstNavigation { get; set; } = null!;
        public virtual User IdUserSecondNavigation { get; set; } = null!;
    }
}
