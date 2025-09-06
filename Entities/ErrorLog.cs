using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTracker.Entities
{
    [Table(name: "error_logs")]
    public class ErrorLog
    {
        public Guid Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public string StackTrace { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
