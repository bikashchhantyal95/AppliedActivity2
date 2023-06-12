using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AppliedActivity2.Models;

namespace AppliedActivity2.Services;

	public class HolidayService
	{
    HttpClient httpClient;
    public HolidayService()
    {
        httpClient = new HttpClient();
    }

    List<Holiday> listHoliday = new ();
    public async Task<List<Holiday>> GetHolidays()
    {
        if (listHoliday?.Count > 0)
            return listHoliday;
        // Online
        var response = await httpClient.GetAsync("https://canada-holidays.ca/api/v1/holidays?year=2022&optional=false");

        if (response.IsSuccessStatusCode)
        {
            var rootHoliday = await response.Content.ReadFromJsonAsync<ListHoliday>();
            listHoliday = rootHoliday.holidays.ToList();
        }
        return listHoliday;
    }
}

