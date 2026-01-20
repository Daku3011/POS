namespace EchoPOS.Models
{
    public class Employee_Shifts
    {
        public int Shift_Id { get; set; }
        public int User_Id { get; set; }
        public string User_Name { get; set; }
        public DateTime Shift_Start { get; set; }
        public DateTime Shift_End { get; set; }
        public string Role { get; set; }
    }

}
