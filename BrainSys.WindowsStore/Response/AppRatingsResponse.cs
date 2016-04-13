using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSys.WindowsStore
{
    public class AppRatingsResponse
    {
        public List<AppRating> Value { get; set; }
        public int TotalCount { get; set; }
    }

    public class AppRating
    {
        public DateTime Date { get; set; }
        public string ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string Market { get; set; }
        public string OsVersion { get; set; }
        public string DeviceType { get; set; }
        public bool IsRevised { get; set; }
        public int OneStar { get; set; }
        public int TwoStars { get; set; }
        public int ThreeStars { get; set; }
        public int FourStars { get; set; }
        public int FiveStars { get; set; }
    }
}