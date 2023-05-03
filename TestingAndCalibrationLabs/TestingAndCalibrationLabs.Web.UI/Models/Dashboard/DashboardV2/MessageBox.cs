using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV2
{
    public class MessageBox
    { 
        public string OwnerName { get; set; }   
        public List<ChatModel> InboxData { get; set; }
    }
}
