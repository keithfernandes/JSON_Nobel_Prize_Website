using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Noble_Prize
{
    public partial class Affiliations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // throw away anything it has already started to write.
            Response.Clear();
            // change the content type, so the browser knows it's JSON
            Response.ContentType = "application/json; charset=utf-8";

            // get a list of NobelAffiliations
            List<NobelAffiliations> affiliations = getNobelAffiliations();

            // change the list of NobelAffiliations to a JSON stream.
            string affiliationsJson = JsonConvert.SerializeObject(affiliations);

            // write our stuff!
            Response.Write(affiliationsJson);
            // we're all done!
            Response.End();

        }

        private List<NobelAffiliations> getNobelAffiliations()
        {
            // create a collection of Nobel Prize Affiliated countries.
            List<NobelAffiliations> allNobelAffiliations = new List<NobelAffiliations>();

            NobelAffiliations LeidenUniversity = new NobelAffiliations();
            LeidenUniversity.Name = "LeidenUniversity";
            LeidenUniversity.City = "Leiden";
            LeidenUniversity.Country = "The Netherlands";
            LeidenUniversity.Name = "LeidenUniversity";
            allNobelAffiliations.Add(LeidenUniversity);

            NobelAffiliations AmsterdamUniversity = new NobelAffiliations();
            AmsterdamUniversity.Name = "AmsterdamUniversity";
            AmsterdamUniversity.City = "Amsterdam";
            AmsterdamUniversity.Country = "The Netherlands";
            allNobelAffiliations.Add(AmsterdamUniversity);

            NobelAffiliations ÉcolePolytechnique = new NobelAffiliations();
            ÉcolePolytechnique.Name = "ÉcolePolytechnique";
            ÉcolePolytechnique.City = "Paris";
            ÉcolePolytechnique.Country = "France";
            allNobelAffiliations.Add(ÉcolePolytechnique);

            NobelAffiliations ÉcoleMuncipale = new NobelAffiliations();
            ÉcoleMuncipale.Name = "ÉcoleMuncipale";
            ÉcoleMuncipale.City = "Paris";
            ÉcoleMuncipale.Country = "France";
            allNobelAffiliations.Add(ÉcoleMuncipale);

            NobelAffiliations SorbonneUniversity = new NobelAffiliations();
            SorbonneUniversity.Name = "SorbonneUniversity";
            SorbonneUniversity.City = "Paris";
            SorbonneUniversity.Country = "France";
            allNobelAffiliations.Add(SorbonneUniversity);

            return allNobelAffiliations;
        }
    }
}