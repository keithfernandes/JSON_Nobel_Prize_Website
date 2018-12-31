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
    public partial class AutoCompleteCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // get the letters that the user typed (if any).
            string term = Request.QueryString["term"];

            Response.Clear();
            // change the content type, so the browser knows it's JSON
            Response.ContentType = "application/json; charset=utf-8";

            List<string> categorySuggestions = new List<string>();
            categorySuggestions.Add("chemistry");
            categorySuggestions.Add("economics");
            categorySuggestions.Add("literature");
            categorySuggestions.Add("medicine");
            categorySuggestions.Add("peace");
            categorySuggestions.Add("physics");

            List<string> matchedCategory = new List<string>();

            if (term != null && term.Length > 0) 
            {
                // iterate over these options, and show only ones that contain the user's text.
                foreach (string category in categorySuggestions)
                {
                    if (category.Contains(term))
                    {
                        matchedCategory.Add(category);
                    }
                }
            }
            // change the list of categories to a JSON stream.
            string categoryJson = JsonConvert.SerializeObject(matchedCategory);

            // write our stuff!
            Response.Write(categoryJson);
            // we're all done!
            Response.End();
        }
    }
}
        
    
