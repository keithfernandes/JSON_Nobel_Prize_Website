using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Noble_Prize
{
    public class Laureatecollection
    {
        private List<NobleLaureates> laureates;

        public List<NobleLaureates> Laureates { get => laureates; set => laureates = value; }
    }
}