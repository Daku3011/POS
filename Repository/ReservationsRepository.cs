using Dapper;
using EchoPOS.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EchoPOS.Repository
{
    public class ReservationsRepository : IReservationsRepository
    {
        private readonly string _connectionString;

        public ReservationsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public int AddReservation(Reservations reservation)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                return conn.ExecuteScalar<int>("sp_InsertReservation",
                    new { reservation.User_Id, reservation.Table_Id, reservation.Reservation_Date, reservation.Status },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateReservation(Reservations reservation)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Execute("sp_UpdateReservation",
                    new { reservation.Reservation_Id, reservation.User_Id, reservation.Table_Id, reservation.Reservation_Date, reservation.Status },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteReservation(int reservationId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Execute("sp_DeleteReservation",
                    new { Reservation_Id = reservationId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public Reservations GetReservationById(int reservationId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    // Log the ID being fetched (optional)
                    Console.WriteLine($"Fetching reservation with ID: {reservationId}");

                    var reservation = conn.QueryFirstOrDefault<Reservations>(
                        "sp_GetReservationById",
                        new { Reservation_Id = reservationId },
                        commandType: CommandType.StoredProcedure
                    );


                    if (reservation == null)
                    {
                        Console.WriteLine($"No reservation found with ID: {reservationId}");
                    }

                    return reservation;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching reservation: {ex.Message}");
                    return null;
                }
            }
        }




        public IEnumerable<Reservations> GetAllReservations()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var reservations = conn.Query<Reservations>("sp_GetAllReservations", commandType: CommandType.StoredProcedure);
                return reservations;
            }
        }

    }

}
