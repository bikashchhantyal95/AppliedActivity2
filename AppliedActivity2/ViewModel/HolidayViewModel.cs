using System;
using AppliedActivity2.Services;
using AppliedActivity2.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace AppliedActivity2.ViewModel
{
    public class HolidayViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Holiday> Holidays { get; } = new();

        public ObservableCollection<Holiday> FilteredHolidaysByProvince { get; } = new();

        public ObservableCollection<Holiday> FilteredHolidaysByFederal { get; } = new();
        HolidayService holidayService;

        public event PropertyChangedEventHandler PropertyChanged;

        public Command FetchHolidaysCommand { get; set; }

        public ObservableCollection<Province> Provinces { get; } = new();

        public Province _selectedProvince;

        public Province SelectedProvice
        {
            get
            {
                return _selectedProvince;
            }
            set
            {
                _selectedProvince = value;
                OnPropertyChanged();
                UpdateFilteredHolidays();
            }
        }

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

            Provinces.Add(new Province { Id = "All", NameEn = "All Provinces" });
            
            foreach (var holiday in holidays)
            {
                Holidays.Add(holiday);
                {
                    foreach (var province in holiday.Provinces)
                    {
                        Provinces.Add(province);
                    }
                }

            }

        }

        private void UpdateFilteredHolidays()
        {
            FilteredHolidaysByProvince.Clear();
            if(SelectedProvice != null)
            {
                foreach(var holiday in Holidays)
                {
                    if(holiday.Provinces.Any(Province=> Province.Id == SelectedProvice.Id))
                    {
                        FilteredHolidaysByProvince.Add(holiday);
                    }
                }
            }
            else
            {
                foreach (var holiday in Holidays)
                {
                   FilteredHolidaysByProvince.Add(holiday);
                }
            }
        }

        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
