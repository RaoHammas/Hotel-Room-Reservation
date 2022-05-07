using System;

namespace HotelReservation.Models
{
    public class Reservation
    {
        public RoomID RoomId { get; set; }
        public string UserName { get; set; }
        public DateTime StarDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public TimeSpan Duration => EndDateTime.Subtract(StarDateTime);

        public Reservation()
        {
            RoomId = new RoomID {FloorNumber = 0, RoomNumber = 0};
            StarDateTime = DateTime.Now;
            EndDateTime = DateTime.Now;
            UserName = "";
        }

        public bool Conflicts(Reservation reservation)
        {
            if (reservation.RoomId.Equals(RoomId)
                && reservation.StarDateTime >= StarDateTime
                && reservation.StarDateTime <= EndDateTime)
            {
                return true;
            }


            return false;
        }
    }
}