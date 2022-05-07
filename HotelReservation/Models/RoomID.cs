using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Models
{
    public class RoomID
    {
        public int FloorNumber { get; set; }
        public int RoomNumber { get; set; }


        public RoomID()
        {
            FloorNumber = 0;
            RoomNumber = 0;
        }

        public override string ToString()
        {
            return $"{FloorNumber} {RoomNumber}";
        }

        public override bool Equals(object obj)
        {
            var roomId = obj as RoomID;
            if (roomId != null && roomId.FloorNumber == FloorNumber && roomId.RoomNumber == RoomNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FloorNumber, RoomNumber);
        }
    }
}