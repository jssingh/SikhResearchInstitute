namespace SikhResearchInstitute.UI.Models
{
	public class PageInfo
	{
		public string Title { get; set; }
        public string SubTitle { get; set; }
        public string TrackingCode { get; set; }
	    public bool TrackingCodeExists
	    {
	        get
	        {
                return TrackingCode!=null && TrackingCode.Length > 0;
	        }
	    }
	}
}