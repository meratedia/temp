using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Helpdesk
{
    public partial class All : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DbQueries queries = new DbQueries();
            List<casesList> cases = queries.getCase();
            string tableRows = GenerateTableRows(cases);
            LiteralCases.Text = tableRows;
            
        }

       
        private string GenerateTableRows(List<casesList> cases)
        {
            StringBuilder htmlBuilder = new StringBuilder();

            foreach (var caseItem in cases)
            {
                htmlBuilder.AppendFormat("<tr onclick='redi(\"{0}\")'>", caseItem.caseID);
                htmlBuilder.AppendFormat("<td>{0}</td>", caseItem.username);
                htmlBuilder.AppendFormat("<td>{0}</td>", caseItem.priority);
                htmlBuilder.AppendFormat("<td>{0}</td>", caseItem.date.ToString("yyyy-MM-dd"));
                if (caseItem.status == "Done")
                {
                    htmlBuilder.AppendFormat("<td><span class='status delivered'>{0}</td>", caseItem.status);
                }
                else
                {
                    htmlBuilder.AppendFormat("<td><span class='status return'>{0}</td>", caseItem.status);
                }

                htmlBuilder.Append("</tr>");
            }

            return htmlBuilder.ToString();
        }
    }
}