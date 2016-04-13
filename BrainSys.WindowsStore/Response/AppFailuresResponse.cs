using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSys.WindowsStore
{
    public class AppFailuresResponse
    {
        public List<AppFailure> Value { get; set; }
        public int TotalCount { get; set; }
    }

    public class AppFailure
    {
        public DateTime Date { get; set; }
        public string ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string FailureName { get; set; }
        public string FailureHash { get; set; }
        public string Symbol { get; set; }
        public string OsVersion { get; set; }
        public string EventType { get; set; }
        public string Market { get; set; }
        public string DeviceType { get; set; }
        public string PackageName { get; set; }
        public string PackageVersion { get; set; }
        public double DeviceCount { get; set; }
        public double EventCount { get; set; }
    }
}