﻿using System;
namespace AppliedActivity2.Models
{
	public class Holiday
	{
        public int Id { get; set; }
        public string Date { get; set; }
        public string NameEn { get; set; }
        public string NameFr { get; set; }
        public int Federal { get; set; }
        public string ObservedDate { get; set; }
        public List<Province> Provinces { get; set; }
    }
}

