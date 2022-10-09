using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdnWorkLog.Model
{
    public class ManualLogMessage
    {
        public DateTime Created { get; set; }
        public string Message { get; set; }

        public ManualLogMessage(DateTime created, string message)
        {
            Created = created;
            Message = message;
        }
    }
}
