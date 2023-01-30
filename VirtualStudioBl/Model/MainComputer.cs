using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualStudioBl.Model
{
    public class MainComputer
    {
        public int MainComputerId { get; set; }

        public int? CoworkerId { get; set; }

        public int ComputerId { get; set;
        }
        public virtual Coworker Coworker { get; set; }

        public virtual Computer Computer { get; set; }

        public virtual ICollection<Streem> Streems { get; set; }

        public virtual ICollection<Screens> Screen { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
