﻿using System;
using AppliedActivity2.Services;
using AppliedActivity2.Models;

namespace AppliedActivity2.ViewModel
{
	public class HolidayViewModel
	{
        public System.Collections.ObjectModel.ObservableCollection<Holiday> Holidays { get; } = new();
        HolidayService holidayService;
        public Command GetHolidaysCommand { get; set; }
        public HolidayViewModel(HolidayService holidayService)
        {
            this.holidayService = holidayService;
            GetHolidaysCommand = new Command(async () => await GetHoliday());
            GetHoliday();
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
