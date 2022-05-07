using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using HotelReservation.Models;

namespace HotelReservation.Exceptions
{
    public class ReservationConflictException : Exception
    {
        public Reservation ExistingReservation { get; set; }
        public Reservation NewReservation { get; set; }

        public ReservationConflictException(Reservation existingReservation, Reservation newReservation)
        {
            ExistingReservation = existingReservation;
            NewReservation = newReservation;
        }

        public ReservationConflictException(string message, Reservation existingReservation, Reservation newReservation)
            : base(message)
        {
            ExistingReservation = existingReservation;
            NewReservation = newReservation;
        }

        public ReservationConflictException(string message, Exception innerException, Reservation existingReservation,
            Reservation newReservation) : base(message, innerException)
        {
            ExistingReservation = existingReservation;
            NewReservation = newReservation;
        }
    }
}