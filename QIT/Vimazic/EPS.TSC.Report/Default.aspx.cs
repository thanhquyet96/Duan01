using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EPS.TSC.Report
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new Entities.ReportContext())
            {
                var test = db.RPT_08A_DK_TSC_01.ToList();
            }
        }
    }
}