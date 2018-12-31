using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Noble_Prize
{
    public partial class AutoCompleteCountries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // get the letters that the user typed (if any).
            string term = Request.QueryString["term"];

            Response.Clear();
            // change the content type, so the browser knows it's JSON
            Response.ContentType = "application/json; charset=utf-8";

            List<string> countrysuggestions = new List<string>();
            countrysuggestions.Add("Australia");
            countrysuggestions.Add("Austria");
            countrysuggestions.Add("Argentina");
            countrysuggestions.Add("Belgium");
            countrysuggestions.Add("Bangladesh");
            countrysuggestions.Add("Bavaria");
            countrysuggestions.Add("Bulgaria");
            countrysuggestions.Add("Brazil");
            countrysuggestions.Add("Czech Republic");
            countrysuggestions.Add("China");
            countrysuggestions.Add("Canada");
            countrysuggestions.Add("Colombia");
            countrysuggestions.Add("Cyprus");
            countrysuggestions.Add("Denmark");
            countrysuggestions.Add("Egypt");
            countrysuggestions.Add("East Timor");
            countrysuggestions.Add("France");
            countrysuggestions.Add("Finland");
            countrysuggestions.Add("Germany");
            countrysuggestions.Add("Guadeloupe Island");
            countrysuggestions.Add("Guatemala");
            countrysuggestions.Add("Ghana");
            countrysuggestions.Add("Hungary");
            countrysuggestions.Add("India");
            countrysuggestions.Add("Israel");
            countrysuggestions.Add("Italy");
            countrysuggestions.Add("Ireland");
            countrysuggestions.Add("Japan");
            countrysuggestions.Add("Kenya");
            countrysuggestions.Add("Korea");
            countrysuggestions.Add("Luxembourg");
            countrysuggestions.Add("Liberia");
            countrysuggestions.Add("Lithuania");
            countrysuggestions.Add("Madagascar");
            countrysuggestions.Add("Mexico");
            countrysuggestions.Add("Morocco");
            countrysuggestions.Add("Myanmar");
            countrysuggestions.Add("New Zealand");
            countrysuggestions.Add("Nigeria");
            countrysuggestions.Add("Norway");
            countrysuggestions.Add("Northern Ireland");
            countrysuggestions.Add("Republic of Macedonia");
            countrysuggestions.Add("Saint Lucia");
            countrysuggestions.Add("Scotland");
            countrysuggestions.Add("South Africa");
            countrysuggestions.Add("Spain");
            countrysuggestions.Add("Sweden");
            countrysuggestions.Add("Switzerland");
            countrysuggestions.Add("Taiwan");
            countrysuggestions.Add("Turkey");
            countrysuggestions.Add("The Netherlands");
            countrysuggestions.Add("Russia");
            countrysuggestions.Add("USA");
            countrysuggestions.Add("United Kingdom");
            countrysuggestions.Add("Venezuela");
            countrysuggestions.Add("Vietnam");
            countrysuggestions.Add("Yemen");

            List<string> matchedCountry = new List<string>();

            if (term != null && term.Length > 0)
            {
                // iterate over these options, and show only ones that contain the user's text.
                foreach (string country in countrysuggestions)
                {
                    if (country.Contains(term))
                    {
                        matchedCountry.Add(country);
                    }
                }
            }
            // change the list of categories to a JSON stream.
            string categoryJson = JsonConvert.SerializeObject(matchedCountry);

            // write our stuff!
            Response.Write(categoryJson);
            // we're all done!
            Response.End();
        }
    }
}