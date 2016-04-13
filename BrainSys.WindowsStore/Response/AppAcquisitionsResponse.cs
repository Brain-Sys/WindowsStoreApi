using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSys.WindowsStore
{
    public class AppAcquisitionsResponse
    {
        public List<AppAcquisition> Value { get; set; }
        public int TotalCount { get; set; }
    }

    public class AppAcquisition
    {
        public DateTime Date { get; set; }
        public string ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string DeviceType { get; set; }
        public string OrderName { get; set; }
        public string StoreClient { get; set; }
        public string OsVersion { get; set; }
        public string Market { get; set; }
        public string Gender { get; set; }
        public string AgeGroup { get; set; }
        public string AcquisitionType { get; set; }
        public string AcquisitionQuantity { get; set; }
    }
}