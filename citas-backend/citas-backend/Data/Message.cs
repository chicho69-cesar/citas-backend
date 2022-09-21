using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace citas_backend.Data
{
    public partial class Message
    {
        [Key]
        public int IdMessage { get; set; }
        public string Message1 { get; set; } = null!;
        public DateTime Date { get; set; }
        public int IdUserSend { get; set; }
        public int IdUserRecieve { get; set; }

        public virtual User IdUserRecieveNavigation { get; set; } = null!;
        public virtual User IdUserSendNavigation { get; set; } = null!;
    }
}
