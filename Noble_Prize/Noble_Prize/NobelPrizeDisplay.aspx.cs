using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace Noble_Prize
{
    public partial class NobelPrizeDisplay : System.Web.UI.Page

    {

        Boolean SearchCompleted = false;
        int dateFilter;
        string wordPart;
        Boolean isDoubleInput;

        Boolean check;


        NobelPrizeCollection nobelprizecollection;

        public NobelPrizeCollection Nobelprizecollection { get => nobelprizecollection; set => nobelprizecollection = value; }
        public bool SearchCompleted1 { get => SearchCompleted; set => SearchCompleted = value; }
        public int DateFilter { get => dateFilter; set => dateFilter = value; }
        public string WordPart { get => wordPart; set => wordPart = value; }
        public bool IsDoubleInput { get => isDoubleInput; set => isDoubleInput = value; }
        public bool Check { get => check; set => check = value; }
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var webClient = new WebClient())
            {             
                isDoubleInput = false;
                SearchCompleted = false;
                //get String representation of JSON
                String rawJSON = webClient.DownloadString("http://api.nobelprize.org/v1/prize.json");
                //convert JSON string to a series of objects
                var jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                nobelprizecollection = JsonConvert.DeserializeObject<NobelPrizeCollection>(rawJSON, jsonSerializerSettings);

            }

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            dateFilter = 0;
            WordPart = "  ";
            

            string[]
            iList = txtYear.Text.Split(null);
            if (iList.Length > 1)
            {
                isDoubleInput = true;
                if (Int32.TryParse(iList[0], out dateFilter))
                {
                    Int32.TryParse(iList[0], out dateFilter);
                    WordPart = iList[1];
                }
                else
                {
                    Int32.TryParse(iList[1], out dateFilter);
                    WordPart = iList[0];
                }
            }
            else
            {
                if (Int32.TryParse(iList[0], out dateFilter))
                {
                    Int32.TryParse(iList[0], out dateFilter);
                }
                else
                {

                    WordPart = iList[0];
                }
            }

            SearchCompleted = true;
        }

        protected void TextBox1_TextChanged1(object sender, EventArgs e)
        {

        }
    }

}
