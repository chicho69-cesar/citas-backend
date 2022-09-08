using System;
using System.Collections.Generic;

namespace citas_backend.Data
{
    public partial class Degree
    {
        public Degree()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
