using System;
namespace AppliedActivity2.Models;

	public class Province
	{
    public string Id { get; set; }
    public string NameEn { get; set; }
    public string NameFr { get; set; }
    public string SourceLink { get; set; }
    public string SourceEn { get; set; }
}

public class ListProvince
{
    public List<Province> provinces { get; set; }
}

