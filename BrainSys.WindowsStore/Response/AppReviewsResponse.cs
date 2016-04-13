using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSys.WindowsStore
{
    public class AppReviewsResponse
    {
        public List<AppReview> Value { get; set; }
        public int TotalCount { get; set; }
    }

    public class AppReview
    {
        public DateTime Date { get; set; }
        public string ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string Market { get; set; }
        public string OsVersion { get; set; }
        public string DeviceType { get; set; }
        public bool IsRevised { get; set; }
        public string PackageVersion { get; set; }
        public string DeviceModel { get; set; }
        public string ProductFamily { get; set; }
        public int DeviceRAM { get; set; }
        public string DeviceScreenResolution { get; set; }
        public int DeviceStorageCapacity { get; set; }
        public bool IsTouchEnabled { get; set; }
        public string ReviewerName { get; set; }
        public string Rating { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewText { get; set; }
        public int HelpfulCount { get; set; }
        public int NotHelpfulCount { get; set; }
        public DateTime? ResponseDate { get; set; }
        public string ResponseText { get; set; }
    }
}