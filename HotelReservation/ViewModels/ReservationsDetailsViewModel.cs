using System;
using System.Collections.Generic;
using System.Windows.Input;
using HotelReservation.Commands;
using HotelReservation.Models;
using HotelReservation.Stores;

namespace HotelReservation.ViewModels
{
    public class ReservationsDetailsViewModel : ViewModelBase
    {
        private readonly Hotel _hotel;
        private readonly NavigationStore _navigationStore;
        public List<ReservationViewModel> Reservations { get; set; }

        #region Commands

        public ICommand NewReservationCommand { get; }

        #endregion

        public ReservationsDetailsViewModel(Hotel hotel, NavigationStore navigationStore)
        {
            _hotel = hotel;
            _navigationStore = navigationStore;

            NewReservationCommand = new NavigateCommand(navigationStore, CreateViewModel);
            Reservations = new List<ReservationViewModel>();
        }

        private ViewModelBase CreateViewModel()
        {
            return new NewReservationViewModel(_hotel, _navigationStore);
        }
    } //end of class
}