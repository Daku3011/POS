namespace EchoPOS.Models
{
    public class Audit_Log
    {
        public int Log_Id { get; set; }
        public int User_Id { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }
        public string IpAddress { get; set; }
        public string SessionId { get; set; }
    }
}
