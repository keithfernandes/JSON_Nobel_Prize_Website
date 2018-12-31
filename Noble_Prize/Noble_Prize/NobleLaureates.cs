using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Noble_Prize
{
    public class NobleLaureates
    {
        private int id;
        string firstname;
        string surname;
        string born;
        string died;
        string borncountry;
        string borncountrycode;
        string borncity;
        string diedcountry;
        string diedcountrycode;
        string diedcity;
        string gender;

        private List<Prizes> prizes;

        public int Id { get => id; set => id = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Born { get => born; set => born = value; }
        public string Died { get => died; set => died = value; }
        public string Borncountry { get => borncountry; set => borncountry = value; }
        public string Borncountrycode { get => borncountrycode; set => borncountrycode = value; }
        public string Borncity { get => borncity; set => borncity = value; }
        public string Diedcountry { get => diedcountry; set => diedcountry = value; }
        public string Diedcountrycode { get => diedcountrycode; set => diedcountrycode = value; }
        public string Diedcity { get => diedcity; set => diedcity = value; }
        public string Gender { get => gender; set => gender = value; }
        public List<Prizes> Prizes { get => prizes; set => prizes = value; }
    }
}