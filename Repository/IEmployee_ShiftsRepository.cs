using EchoPOS.Models;

namespace EchoPOS.Repository
{
    public interface IEmployee_ShiftsRepository
    {
        void AddShift(Employee_Shifts shift);
        Employee_Shifts GetShiftById(int id);
        List<Employee_Shifts> GetAllShifts();
        void UpdateShift(Employee_Shifts shift);
        void DeleteShift(int id);
    }
}
