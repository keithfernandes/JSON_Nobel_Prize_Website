using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Noble_Prize
{
    public class Laureate1
    {
        int id;
        string firstname;
        string surname;
        string motivation;
        int share;

        public int Id { get => id; set => id = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Motivation { get => motivation; set => motivation = value; }
        public int Share { get => share; set => share = value; }
    }
}