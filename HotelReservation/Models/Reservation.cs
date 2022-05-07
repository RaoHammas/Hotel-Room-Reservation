using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Models
{
    public class Reservation
    {
        public RoomID RoomId { get; set; }
        public string UserName { get; set; }
        public DateTime StarDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public TimeSpan Duration { get; set; }

        public Reservation(RoomID roomId, DateTime starDateTime, DateTime endDateTime, string userName)
        {
            RoomId = roomId;
            StarDateTime = starDateTime;
            EndDateTime = endDateTime;
            UserName = userName;
            Duration = EndDateTime.Subtract(StarDateTime);
        }

        public bool Conflicts(Reservation reservation)
        {
            if (reservation.RoomId.Equals(RoomId))
            {
                return true;
            }

            if (reservation.StarDateTime < StarDateTime && reservation.EndDateTime > StarDateTime)
            {
                return true;
            }

            return false;
        }
    }
}