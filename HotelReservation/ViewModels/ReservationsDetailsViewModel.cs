using System;
using System.Collections.Generic;
using System.Windows.Input;
using HotelReservation.Commands;
using HotelReservation.Models;

namespace HotelReservation.ViewModels
{
    public class ReservationsDetailsViewModel : ViewModelBase
    {
        public List<ReservationViewModel> Reservations { get; set; }

        #region Commands

        public ICommand NewReservationCommand { get; }

        #endregion

        public ReservationsDetailsViewModel(Hotel hotel)
        {
            NewReservationCommand = new NavigateCommand();
            Reservations = new List<ReservationViewModel>();

            Reservations.Add(new ReservationViewModel(new Reservation
            {
                UserName = "Hammas",
                StarDateTime = DateTime.Now,
                EndDateTime = DateTime.Now.AddDays(1),
                RoomId = new RoomID
                {
                    RoomNumber = 1,
                    FloorNumber = 1
                },
            }));
        }



    } //end of class
}