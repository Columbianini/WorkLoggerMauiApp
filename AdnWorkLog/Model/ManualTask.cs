using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdnWorkLog.Model
{
    [Table("ManualTasks")]
    public class ManualTask
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public string Name { get; set; }
        public DateTime Created { get; set; }

    }
}
