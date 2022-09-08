using System;
using System.Collections.Generic;

namespace citas_backend.Data
{
    public partial class Message
    {
        public int Id { get; set; }
        public string Message1 { get; set; } = null!;
        public DateTime Date { get; set; }
        public int IdUserSend { get; set; }
        public int IdUserRecieve { get; set; }

        public virtual User IdUserRecieveNavigation { get; set; } = null!;
        public virtual User IdUserSendNavigation { get; set; } = null!;
    }
}
