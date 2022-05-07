using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using HotelReservation.Models;

namespace HotelReservation.ViewModels
{
    public class ReservationViewModel : INotifyPropertyChanged
    {
        private readonly Reservation _reservation;
        public string RoomId => _reservation.RoomId.ToString();
        public string UserName => _reservation.UserName;
        public DateTime StarDateTime => _reservation.StarDateTime;
        public DateTime EndDateTime => _reservation.EndDateTime;

        public ReservationViewModel(Reservation reservation)
        {
            _reservation = reservation;
        }







        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
