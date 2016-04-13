using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSys.WindowsStore
{
    public abstract class BaseRequest
    {
        public string ApplicationId { get; protected set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Top { get; set; }
        public int Skip { get; set; }
        public List<OrderBy> OrderBy { get; set; }

        public BaseRequest()
        {
            this.StartDate = DateTime.Now.AddYears(-1);
            this.EndDate = DateTime.Now;
            this.Top = 100;
            this.Skip = 0;
            this.OrderBy = new List<OrderBy>();
        }
    }
}