namespace citas_backend.Models {
    public class AddAndUpdateDate {
        public int Id { get; set; }
        public DateTime Date1 { get; set; }
        public string? Place { get; set; }
        public string? Description { get; set; }
        public double? Grade { get; set; }
        public int IdUserFirst { get; set; }
        public int IdUserSecond { get; set; }
    }
}
