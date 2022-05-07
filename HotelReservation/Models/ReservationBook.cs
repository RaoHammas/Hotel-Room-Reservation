using System.Collections.Generic;
using System.Linq;
using HotelReservation.Exceptions;

namespace HotelReservation.Models
{
    public class ReservationBook
    {
        private List<Reservation> Reservations { get; }

        public ReservationBook()
        {
            Reservations = new List<Reservation>();
        }

        public IEnumerable<Reservation> GetReservations(string userName)
        {
            if (userName.Trim() == "")
            {
                return Reservations;
            }
            else
            {
                return Reservations.Where(x => x.UserName.ToLower().Trim() == userName.ToLower().Trim());
            }
        }

        public Reservation AddReservation(Reservation reservation)
        {
            foreach (var existingReservation in Reservations)
            {
                if (existingReservation.Conflicts(reservation))
                {
                    throw new ReservationConflictException(existingReservation, reservation);
                }
            }


            Reservations.Add(reservation);
            return reservation;
        }
    } //end of class
}