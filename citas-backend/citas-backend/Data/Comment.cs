using System;
using System.Collections.Generic;

namespace citas_backend.Data
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string? Comment1 { get; set; }
        public DateTime Date { get; set; }
        public int IdUser { get; set; }
        public int IdPost { get; set; }

        public virtual Post IdPostNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
