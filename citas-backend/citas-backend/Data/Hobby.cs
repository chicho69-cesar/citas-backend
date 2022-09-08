using System;
using System.Collections.Generic;

namespace citas_backend.Data
{
    public partial class Hobby
    {
        public Hobby()
        {
            UserHobbies = new HashSet<UserHobby>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<UserHobby> UserHobbies { get; set; }
    }
}
