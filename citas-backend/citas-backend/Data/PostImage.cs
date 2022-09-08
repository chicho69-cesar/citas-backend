using System;
using System.Collections.Generic;

namespace citas_backend.Data
{
    public partial class PostImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = null!;
        public int IdPost { get; set; }

        public virtual Post IdPostNavigation { get; set; } = null!;
    }
}
