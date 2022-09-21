namespace citas_backend.Models {
    public class AddAndUpdateMessage {
        public int IdMessage { get; set; }
        public string Message1 { get; set; } = null!;
        public DateTime Date { get; set; }
        public int IdUserSend { get; set; }
        public int IdUserRecieve { get; set; }
    }
}