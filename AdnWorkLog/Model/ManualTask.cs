using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdnWorkLog.Model
{
    public class ManualTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }

        public ManualTask(int id, string name, DateTime created)
        {
            Id = id;
            Name = name;
            Created = created;
        }
    }
}
