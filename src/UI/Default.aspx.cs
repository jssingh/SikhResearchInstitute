using System.Web.UI;

namespace SikhResearchInstitute.UI
{
    public partial class _Default : Page
    {
        public void Page_Load(object sender, System.EventArgs e)
        {
            Response.Redirect("~/home");
        }
    }
}