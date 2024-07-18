using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Helpdesk
{
    public partial class Attend : System.Web.UI.Page
    {
        string casedem = "";
        Boolean isDone = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["caseID"] != null)
            {
                string caseID = Request.QueryString["caseID"];
                casedem = caseID;
                DbQueries queries = new DbQueries();
                List<casesList> cases = queries.getOneCase(caseID);
                if (cases[0].status == "Done")
                {
                    isDone = true;
                    Button1.Visible = false;
                }
                else
                {
                    isDone = false;
                    Button1.Visible = true;
                }
                string tableRows = GenerateTableRows(cases);
                LiteralCases.Text = tableRows;
            }
            else{

                HttpContext.Current.Response.Redirect("/");
            }
            
        }
        private string GenerateTableRows(List<casesList> cases)
        {
            StringBuilder htmlBuilder = new StringBuilder();

            foreach (var caseItem in cases)
            {
                htmlBuilder.Append("<tr>");
                htmlBuilder.Append("<td>Username</td>");
                htmlBuilder.AppendFormat("<td>{0}</td>", caseItem.username); 
                htmlBuilder.Append("</tr>");

                htmlBuilder.Append("<tr>");
                htmlBuilder.Append("<td>Date</td>");
                htmlBuilder.AppendFormat("<td>{0}</td>", caseItem.date);
                htmlBuilder.Append("</tr>");

                htmlBuilder.Append("<tr>");
                htmlBuilder.Append("<td>Location</td>");
                htmlBuilder.AppendFormat("<td>{0}</td>", caseItem.location);
                htmlBuilder.Append("</tr>");

                htmlBuilder.Append("<tr>");
                htmlBuilder.Append("<td>Query</td>");
                htmlBuilder.AppendFormat("<td>{0}</td>", caseItem.qry);
                htmlBuilder.Append("</tr>");

                htmlBuilder.Append("<tr>");
                htmlBuilder.Append("<td>Phone</td>");
                htmlBuilder.AppendFormat("<td>{0}</td>", caseItem.phone);
                htmlBuilder.Append("</tr>");

                htmlBuilder.Append("<tr>");
                htmlBuilder.Append("<td>Email</td>");
                htmlBuilder.AppendFormat("<td>{0}</td>", caseItem.email);
                htmlBuilder.Append("</tr>");

                htmlBuilder.Append("<tr>");
                htmlBuilder.Append("<td>Status</td>");
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            DbQueries queries = new DbQueries();
            queries.markDone(casedem);
            HttpContext.Current.Response.Redirect("/all");
        }
    }
}