using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Noble_Prize
{
    public class NobelPrize
    {
        int year;
        string category;


        private List<Laureate1> laureates;

        public int Year { get => year; set => year = value; }
        public string Category { get => category; set => category = value; }
        public List<Laureate1> Laureates { get => laureates; set => laureates = value; }
    }
}