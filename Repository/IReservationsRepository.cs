using EchoPOS.Models;

namespace EchoPOS.Repository
{
    public interface IReservationsRepository
    {
        int AddReservation(Reservations reservation);
        void UpdateReservation(Reservations reservation);
        void DeleteReservation(int reservationId);
        public Reservations GetReservationById(int reservationId);
        IEnumerable<Reservations> GetAllReservations();
    }
}
