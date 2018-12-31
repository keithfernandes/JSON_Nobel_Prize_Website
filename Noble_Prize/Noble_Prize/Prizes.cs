using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Noble_Prize
{
    public class Prizes
    {
        int year;
        string category;
        int share;
        string motivation;

        public int Year { get => year; set => year = value; }
        public string Category { get => category; set => category = value; }
        public int Share { get => share; set => share = value; }
        public string Motivation { get => motivation; set => motivation = value; }
    }
}