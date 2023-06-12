using System;
using AppliedActivity2.Services;
using AppliedActivity2.Models;

namespace AppliedActivity2.ViewModel
{
	public class HolidayViewModel
	{
        public System.Collections.ObjectModel.ObservableCollection<Holiday> Holidays { get; } = new();
        HolidayService holidayService;

        public Command FetchHolidaysCommand { get; set; }

        public HolidayViewModel()
        {
            holidayService = new HolidayService();
            FetchHolidaysCommand = new Command(async () => await GetHoliday());
            FetchHolidaysCommand.Execute(null);
        }


        async Task GetHoliday()
        {
            
                var holidays = await holidayService.GetHolidays();

                if (Holidays.Count != 0)
                    Holidays.Clear();

                foreach (var holiday in holidays)
                    Holidays.Add(holiday);

       
        }
    }
}

