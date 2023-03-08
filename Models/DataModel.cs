using System.ComponentModel.DataAnnotations.Schema;

namespace MetaMindsCodingTask.Models
{
    public class DataModel
    {
        public int Id { get; set; }
        public string? First_Name { get; set; }
        public string? Last_name { get; set; }
        public string? Email { get; set; }
        public string? Avatar { get; set; }
        public string? Job { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<AttendanceModel>? Attendance { get; set; }
    }
}
