using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Models
{
    public class Hotel
    {
        public ReservationBook ReservationBook { get; set; }
        public string Name { get; set; }

        public Hotel(string name)
        {
            Name = name;
            ReservationBook = new ReservationBook();
        }


        public IEnumerable<Reservation> GetReservations(string userName)
        {
            return ReservationBook.GetReservations(userName);
        }

        public Reservation AddReservation(Reservation reservation)
        {
            return ReservationBook.AddReservation(reservation);
        }











    } //end of class
}
