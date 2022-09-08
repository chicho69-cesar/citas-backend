using System;
using System.Collections.Generic;

namespace citas_backend.Data
{
    public partial class SocialNetwork
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Link { get; set; } = null!;
        public int IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
