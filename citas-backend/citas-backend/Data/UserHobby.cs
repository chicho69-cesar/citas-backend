using System;
using System.Collections.Generic;

namespace citas_backend.Data
{
    public partial class UserHobby
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdHobbie { get; set; }

        public virtual Hobby IdHobbieNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
