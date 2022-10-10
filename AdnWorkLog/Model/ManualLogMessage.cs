using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdnWorkLog.Model
{
    [Table("ManualLogMessages")]
    public class ManualLogMessage
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int TitleId { get; set; }
        public DateTime Created { get; set; }
        public string Message { get; set; }

    }
}
