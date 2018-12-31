using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Noble_Prize
{
    public class NobelAffiliations
    {
        private string name;
        private string city;
        private string country;

        public string Name { get => name; set => name = value; }
        public string City { get => city; set => city = value; }
        public string Country { get => country; set => country = value; }
    }
}