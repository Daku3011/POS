namespace EchoPOS.Models
{
    public class OrderDetail
    {
        public int Order_Id { get; set; }
        public string Order_Status { get; set; }
        public decimal Sub_Total { get; set; }
        public string Payment_Status_Name { get; set; }
    }
}
