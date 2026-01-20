using EchoPOS.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EchoPOS.Repository
{
    public class Employee_ShiftsRepository : IEmployee_ShiftsRepository
    {
        private readonly string _connectionString;

        public Employee_ShiftsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void AddShift(Employee_Shifts shift)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AddShift", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@User_Id", shift.User_Id);
                cmd.Parameters.AddWithValue("@Shift_Start", shift.Shift_Start);
                cmd.Parameters.AddWithValue("@Shift_End", shift.Shift_End);
                cmd.Parameters.AddWithValue("@Role", shift.Role);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Employee_Shifts GetShiftById(int id)
        {
            Employee_Shifts shift = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetShiftById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Shift_Id", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    shift = new Employee_Shifts
                    {
                        Shift_Id = Convert.ToInt32(reader["Shift_Id"]),
                        User_Id = Convert.ToInt32(reader["User_Id"]),
                        Shift_Start = Convert.ToDateTime(reader["Shift_Start"]),
                        Shift_End = Convert.ToDateTime(reader["Shift_End"]),
                        Role = reader["Role"].ToString()
                    };
                }
            }
            return shift;
        }
        public List<Employee_Shifts> GetAllShifts()
        {
            List<Employee_Shifts> shifts = new List<Employee_Shifts>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllShifts", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    shifts.Add(new Employee_Shifts
                    {
                        Shift_Id = Convert.ToInt32(reader["Shift_Id"]),
                        User_Id = Convert.ToInt32(reader["User_Id"]),
                        Shift_Start = Convert.ToDateTime(reader["Shift_Start"]),
                        Shift_End = Convert.ToDateTime(reader["Shift_End"]),
                        Role = reader["Role"].ToString()
                    });
                }
            }
            return shifts;
        }

        public void UpdateShift(Employee_Shifts shift)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateShift", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Shift_Id", shift.Shift_Id);
                cmd.Parameters.AddWithValue("@User_Id", shift.User_Id);
                cmd.Parameters.AddWithValue("@Shift_Start", shift.Shift_Start);
                cmd.Parameters.AddWithValue("@Shift_End", shift.Shift_End);
                cmd.Parameters.AddWithValue("@Role", shift.Role);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteShift(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteShift", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Shift_Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

}
