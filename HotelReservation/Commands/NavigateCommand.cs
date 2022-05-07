using System;
using HotelReservation.Services;
using HotelReservation.Stores;
using HotelReservation.ViewModels;

namespace HotelReservation.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigateService _navigateService;

        public NavigateCommand(NavigateService navigateService)
        {
            _navigateService = navigateService;
        }
        public override void Execute(object parameter)
        {
            _navigateService.Navigate();
        }
    }
}
