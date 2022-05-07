using System.ComponentModel;
using System.Windows;
using HotelReservation.Exceptions;
using HotelReservation.Models;
using HotelReservation.Services;
using HotelReservation.ViewModels;

namespace HotelReservation.Commands
{
    public class AddNewReservationCommand : CommandBase
    {
        private readonly NewReservationViewModel _newReservationViewModel;
        private readonly Hotel _hotel;
        private readonly NavigateService _navigateService;

        public AddNewReservationCommand(NewReservationViewModel newReservationViewModel, Hotel hotel,
            NavigateService navigateService)
        {
            _newReservationViewModel = newReservationViewModel;
            _hotel = hotel;
            _navigateService = navigateService;

            _newReservationViewModel.PropertyChanged += NewReservationViewModelOnPropertyChanged;
        }

        private void NewReservationViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_newReservationViewModel.UserName)
                || e.PropertyName == nameof(_newReservationViewModel.FloorNumber)
                || e.PropertyName == nameof(_newReservationViewModel.RoomNumber))
            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            if (string.IsNullOrEmpty(_newReservationViewModel.UserName) || _newReservationViewModel.RoomNumber < 1 ||
                _newReservationViewModel.FloorNumber < 1)
            {
                return false;
            }

            return base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            var newReservation = new Reservation
            {
                UserName = _newReservationViewModel.UserName,
                StarDateTime = _newReservationViewModel.StarDateTime,
                EndDateTime = _newReservationViewModel.EndDateTime,
                RoomId = new RoomID
                {
                    FloorNumber = _newReservationViewModel.FloorNumber,
                    RoomNumber = _newReservationViewModel.RoomNumber,
                }
            };

            try
            {
                _hotel.AddReservation(newReservation);

                MessageBox.Show("Reservation is made successfully !");
                _navigateService.Navigate();
            }
            catch (ReservationConflictException ex)
            {
                MessageBox.Show("This room is already booked !");
            }
        }
    }
}