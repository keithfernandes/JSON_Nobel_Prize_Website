using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Noble_Prize
{
    public class NobelPrizeCollection
    {
        private List<NobelPrize> prizes;

        public List<NobelPrize> Prizes { get => prizes; set => prizes = value; }
    }
}