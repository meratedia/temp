using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Helpdesk
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DbQueries queries  = new DbQueries();
            List <casesList> cases = queries.getCase10();
            string tableRows = GenerateTableRows(cases);
            LiteralCases.Text = tableRows;
            if (cases.Count>0)
            {
              List<User> users = queries.getClients(); 
            string tableRow = GenerateUserTableRows(users);
            LiteralUsers.Text = tableRow;

                int totalRows = queries.GetTotalRowCount();
                int pendingCount = queries.GetStatusCount( "pending");
                int doneCount = queries.GetStatusCount( "done");
                fresh.Text = pendingCount.ToString();
                total.Text = totalRows.ToString();
                solved.Text = doneCount.ToString();
            }
           
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

        private string GenerateUserTableRows(List<User> users)
        {
            StringBuilder htmlBuilder = new StringBuilder();

            foreach (var user in users)
            {
                htmlBuilder.Append("<tr>");
                htmlBuilder.Append("<td width='60px'>");
                htmlBuilder.Append("<div class='imgBx'><i class='fas fa-user'></i></div>");
                htmlBuilder.Append("</td>");
                htmlBuilder.Append("<td>");
                htmlBuilder.AppendFormat("<h4>{0} <br/><span>{1}</span></h4>", user.Name, user.Country);
                htmlBuilder.Append("</td>");
                htmlBuilder.Append("</tr>");
            }

            return htmlBuilder.ToString();
        }
    }
}