using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Noble_Prize
{

    public partial class Laureate : System.Web.UI.Page
    {
        Boolean SearchCompleted = false;
        Boolean isDoubleInput;
        Boolean check;
        int dateFilter;
        string text;
        string country;
        Laureatecollection laureatecollection;

        public Laureatecollection Laureatecollection { get => laureatecollection; set => laureatecollection = value; }
        public bool SearchCompleted1 { get => SearchCompleted; set => SearchCompleted = value; }
        public bool IsDoubleInput { get => isDoubleInput; set => isDoubleInput = value; }
        public bool Check { get => check; set => check = value; }
        public int DateFilter { get => dateFilter; set => dateFilter = value; }
        public string Text { get => text; set => text = value; }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            using (var webclient = new WebClient())
            {
                //getting a string representation of JSON.
                string rawJSON = webclient.DownloadString("http://api.nobelprize.org/v1/laureate.json");
                //Convert JSON string to series of objects.
                var jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                laureatecollection = JsonConvert.DeserializeObject<Laureatecollection>(rawJSON, jsonSerializerSettings);
                check = false;

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrWhiteSpace(txtyear.Text) || String.IsNullOrEmpty(txtyear.Text) ||
               String.IsNullOrWhiteSpace(txtCountry.Text) || String.IsNullOrEmpty(txtCountry.Text))
            {
                isDoubleInput = false;
            }
            else
            {
                isDoubleInput = true;
            }
                country = txtCountry.Text;
            Int32.TryParse(txtyear.Text,out dateFilter);

           
            SearchCompleted = true;
        }

        protected void txtyear_TextChanged(object sender, EventArgs e)
        {
           

           
        }

        protected void txtCountry_TextChanged(object sender, EventArgs e)
        {
       
        }
    }
}

    

    
